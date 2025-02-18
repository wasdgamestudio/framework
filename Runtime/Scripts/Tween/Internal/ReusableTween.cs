using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

[Serializable]
public class ReusableTween
{
    enum State : byte
    {
        Before, Running, After
    }

    object onUpdateTarget;
    object onUpdateCallback;
    Action<ReusableTween> onUpdate;
#if UNITY_EDITOR
    [SerializeField, HideInInspector] internal string debugDescription;
    [SerializeField] internal UnityEngine.Object unityTarget;
#endif
    internal long id = -1;
    /// Holds a reference to tween's target. If the target is UnityEngine.Object, the tween will gracefully stop when the target is destroyed. That is, destroying object with running tweens is perfectly ok.
    /// Keep in mind: when animating plain C# objects (not derived from UnityEngine.Object), the plugin will hold a strong reference to the object for the entire tween Duration.
    ///     If plain C# target holds a reference to UnityEngine.Object and animates its properties, then it's user's responsibility to ensure that UnityEngine.Object still exists.
    internal object target;
    [SerializeField] internal bool _isPaused;
    internal bool _isAlive;
    [SerializeField] internal float elapsedTimeTotal;
    [SerializeField] internal float easedInterpolationFactor;
    internal float loopDuration;

    [NonSerialized] PropType propType;
    internal void setPropType(PropType value) => propType = value;

    [SerializeField] internal ValueContainerStartEnd startEndValue;
    internal PropType getPropType() => Utils.TweenTypeToTweenData(startEndValue.tweenType).Item1; // todo rename to propType
    internal ref TweenType tweenType => ref startEndValue.tweenType;
    internal ref ValueContainer startValue => ref startEndValue.startValue;
    internal ref ValueContainer endValue => ref startEndValue.endValue;
    internal ValueContainer diff;
    internal bool isAdditive;
    internal ValueContainer prevVal;
    [SerializeField] internal TweenSettings settings;
    [SerializeField] int loopsDone;
    const int iniLoopsDone = -1;
    bool isUpdating; // todo place this check only on calls that come from W_Tween.Custom()? no, then it would not be possible to call .Complete() on custom tweens

    internal object customOnValueChange;
    internal long longParam;
    internal int intParam
    {
        get => (int)longParam;
        set => longParam = value;
    }
    Action<ReusableTween> onValueChange;

    Action<ReusableTween> onComplete;
    object onCompleteCallback;
    object onCompleteTarget;

    internal float waitDelay;
    internal W_Sequence sequence;
    internal W_Tween prev;
    internal W_Tween next;
    internal W_Tween prevSibling;
    internal W_Tween nextSibling;

    internal Func<ReusableTween, ValueContainer> getter;
    internal ref bool startFromCurrent => ref startEndValue.startFromCurrent;

    bool stoppedEmergently;
    internal readonly TweenCoroutineEnumerator coroutineEnumerator = new TweenCoroutineEnumerator();
    internal float timeScale = 1f;
    bool warnIgnoredOnCompleteIfTargetDestroyed = true;
    internal ShakeData shakeData;
    State state;
    bool warnEndValueEqualsCurrent;

    internal float FloatVal => startValue.x + diff.x * easedInterpolationFactor;
    internal double DoubleVal => startValue.DoubleVal + diff.DoubleVal * easedInterpolationFactor;
    internal Vector2 Vector2Val
    {
        get
        {
            var easedT = easedInterpolationFactor;
            return new Vector2(
                startValue.x + diff.x * easedT,
                startValue.y + diff.y * easedT);
        }
    }
    internal Vector3 Vector3Val
    {
        get
        {
            var easedT = easedInterpolationFactor;
            return new Vector3(
                startValue.x + diff.x * easedT,
                startValue.y + diff.y * easedT,
                startValue.z + diff.z * easedT);
        }
    }
    internal Vector4 Vector4Val
    {
        get
        {
            var easedT = easedInterpolationFactor;
            return new Vector4(
                startValue.x + diff.x * easedT,
                startValue.y + diff.y * easedT,
                startValue.z + diff.z * easedT,
                startValue.w + diff.w * easedT);
        }
    }
    internal Color ColorVal
    {
        get
        {
            var easedT = easedInterpolationFactor;
            return new Color(
                startValue.x + diff.x * easedT,
                startValue.y + diff.y * easedT,
                startValue.z + diff.z * easedT,
                startValue.w + diff.w * easedT);
        }
    }
    internal Rect RectVal
    {
        get
        {
            var easedT = easedInterpolationFactor;
            return new Rect(
                startValue.x + diff.x * easedT,
                startValue.y + diff.y * easedT,
                startValue.z + diff.z * easedT,
                startValue.w + diff.w * easedT);
        }
    }
    internal Quaternion QuaternionVal => Quaternion.SlerpUnclamped(startValue.QuaternionVal, endValue.QuaternionVal, easedInterpolationFactor);
    internal bool UpdateAndCheckIfRunning(float dt)
    {
        if(!_isAlive)
        {
            return sequence.IsCreated; // don't release a tween until sequence.releaseTweens()
        }
        if(!_isPaused)
        {
            SetElapsedTimeTotal(elapsedTimeTotal + dt * timeScale);
        }
        else if(IsUnityTargetDestroyed())
        {
            EmergencyStop(true);
            return false;
        }
        return _isAlive;
    }
    internal void SetElapsedTimeTotal(float newElapsedTimeTotal, bool earlyExitSequenceIfPaused = true)
    {
        if(isUpdating)
        {
            return;
        }
        isUpdating = true;
        if(!sequence.IsCreated)
        {
            SetElapsedTimeTotal(newElapsedTimeTotal, out int loopsDiff);
            if(!stoppedEmergently && _isAlive && IsDone(loopsDiff))
            {
                if(!_isPaused)
                {
                    Kill();
                }
                ReportOnComplete();
            }
        }
        else
        {
            Assert.IsTrue(sequence.isAlive, id);
            if(IsMainSequenceRoot())
            {
                Assert.IsTrue(sequence.root.Id == id, id);
                UpdateSequence(newElapsedTimeTotal, false, earlyExitSequenceIfPaused);
            }
        }
        isUpdating = false;
    }
    internal void UpdateSequence(float _elapsedTimeTotal, bool isRestart, bool earlyExitSequenceIfPaused = true, bool allowSkipChildrenUpdate = true)
    {
        Assert.IsTrue(IsSequenceRoot());
        float prevEasedT = easedInterpolationFactor;
        if(!SetElapsedTimeTotal(_elapsedTimeTotal, out int loopsDiff) && allowSkipChildrenUpdate)
        { // update sequence root
            return;
        }

        bool isRestartToBeginning = isRestart && loopsDiff < 0;
        Assert.IsTrue(!isRestartToBeginning || loopsDone == 0 || loopsDone == iniLoopsDone);
        if(loopsDiff != 0 && !isRestartToBeginning)
        {
            if(isRestart)
            {
                Assert.IsTrue(loopsDiff > 0 && loopsDone == settings.loops);
                loopsDiff = 1;
            }
            int loopsDiffAbs = Mathf.Abs(loopsDiff);
            int newLoopsDone = loopsDone;
            loopsDone -= loopsDiff;
            int loopsDelta = loopsDiff > 0 ? 1 : -1;
            var interpolationFactor = loopsDelta > 0 ? 1f : 0f;
            for(int i = 0; i < loopsDiffAbs; i++)
            {
                Assert.IsTrue(!isRestart || i == 0);
                if(loopsDone == settings.loops || loopsDone == iniLoopsDone)
                {
                    // do nothing when moving backward from the last loop or forward from the -1 loop
                    loopsDone += loopsDelta;
                    continue;
                }

                var easedT = CalcEasedT(interpolationFactor, loopsDone);
                var isForwardCycle = easedT > 0.5f;
                const float negativeElapsedTime = -1000f;
                if(!forceChildrenToPos())
                {
                    return;
                }
                bool forceChildrenToPos()
                {
                    // complete the previous loops by forcing all children tweens to 0f or 1f
                    // print($" (i:{i}) force to pos: {isForwardCycle}");
                    var simulatedSequenceElapsedTime = isForwardCycle ? float.MaxValue : negativeElapsedTime;
                    foreach(var t in getSequenceSelfChildren(isForwardCycle))
                    {
                        var tween = t.tween;
                        tween.UpdateSequenceChild(simulatedSequenceElapsedTime, isRestart);
                        if(isEarlyExitAfterChildUpdate())
                        {
                            return false;
                        }
                    }
                    return true;
                }

                loopsDone += loopsDelta;
                var sequenceloopMode = settings.loopMode;
                if(sequenceloopMode == W_LoopMode.Restart && loopsDone != settings.loops && loopsDone != iniLoopsDone)
                { 
                    if(!restartChildren())
                    {
                        return;
                    }
                    bool restartChildren()
                    {
                        var simulatedSequenceElapsedTime = !isForwardCycle ? float.MaxValue : negativeElapsedTime;
                        prevEasedT = simulatedSequenceElapsedTime;
                        foreach(var t in getSequenceSelfChildren(!isForwardCycle))
                        {
                            var tween = t.tween;
                            tween.UpdateSequenceChild(simulatedSequenceElapsedTime, true);
                            if(isEarlyExitAfterChildUpdate())
                            {
                                return false;
                            }
                            Assert.IsTrue(isForwardCycle || tween.loopsDone == tween.settings.loops, id);
                            Assert.IsTrue(!isForwardCycle || tween.loopsDone <= 0, id);
                            Assert.IsTrue(isForwardCycle || tween.state == State.After, id);
                            Assert.IsTrue(!isForwardCycle || tween.state == State.Before, id);
                        }
                        return true;
                    }
                }
            }
            Assert.IsTrue(newLoopsDone == loopsDone, id);
            if(IsDone(loopsDiff))
            {
                if(IsMainSequenceRoot() && !_isPaused)
                {
                    sequence.releaseTweens();
                }
                ReportOnComplete();
                return;
            }
        }

        easedInterpolationFactor = Mathf.Clamp01(easedInterpolationFactor);
        bool isForward = easedInterpolationFactor > prevEasedT;
        float sequenceElapsedTime = easedInterpolationFactor * loopDuration;
        foreach(var t in getSequenceSelfChildren(isForward))
        {
            t.tween.UpdateSequenceChild(sequenceElapsedTime, isRestart);
            if(isEarlyExitAfterChildUpdate())
            {
                return;
            }
        }

        bool isEarlyExitAfterChildUpdate()
        {
            if(!sequence.isAlive)
            {
                return true;
            }
            return earlyExitSequenceIfPaused && sequence.root.tween._isPaused; // access isPaused via root tween to bypass the cantManipulateNested check
        }
    }
    W_Sequence.SequenceDirectEnumerator getSequenceSelfChildren(bool isForward)
    {
        Assert.IsTrue(sequence.isAlive, id);
        return sequence.getSelfChildren(isForward);
    }
    bool IsDone(int loopsDiff)
    {
        Assert.IsTrue(settings.loops == -1 || loopsDone <= settings.loops);
        if(timeScale > 0f)
        {
            return loopsDiff > 0 && loopsDone == settings.loops;
        }
        return loopsDiff < 0 && loopsDone == iniLoopsDone;
    }
    void UpdateSequenceChild(float encompassingElapsedTime, bool isRestart)
    {
        if(IsSequenceRoot())
        {
            UpdateSequence(encompassingElapsedTime, isRestart);
        }
        else
        {
            SetElapsedTimeTotal(encompassingElapsedTime, out var loopsDiff);
            if(!stoppedEmergently && _isAlive && IsDone(loopsDiff))
            {
                ReportOnComplete();
            }
        }
    }
    internal bool IsMainSequenceRoot() => tweenType == TweenType.MainSequence;
    internal bool IsSequenceRoot() => tweenType == TweenType.MainSequence || tweenType == TweenType.NestedSequence;
    bool SetElapsedTimeTotal(float _elapsedTimeTotal, out int loopsDiff)
    {
        elapsedTimeTotal = _elapsedTimeTotal;
        int oldLoopsDone = loopsDone;
        float t = CalcTFromElapsedTimeTotal(_elapsedTimeTotal, out var newState);
        loopsDiff = loopsDone - oldLoopsDone;
        if(newState == State.Running || state != newState)
        {
            if(IsUnityTargetDestroyed())
            {
                EmergencyStop(true);
                return false;
            }
            float easedT = CalcEasedT(t, loopsDone);
            state = newState;
            ReportOnValueChange(easedT);
            return true;
        }
        return false;
    }
    float CalcTFromElapsedTimeTotal(float _elapsedTimeTotal, out State newState)
    {
        // key timeline points: 0 | StartDelay | Duration | 1 | EndDelay | onComplete
        var loopsTotal = settings.loops;
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if(_elapsedTimeTotal == float.MaxValue)
        {
            Assert.AreNotEqual(-1, loopsTotal);
            Assert.IsTrue(loopsDone <= loopsTotal);
            loopsDone = loopsTotal;
            newState = State.After;
            return 1f;
        }
        _elapsedTimeTotal -= waitDelay; // waitDelay is applied before calculating loops
        if(_elapsedTimeTotal < 0f)
        {
            loopsDone = iniLoopsDone;
            newState = State.Before;
            return 0f;
        }
        Assert.IsTrue(_elapsedTimeTotal >= 0f);
        Assert.AreNotEqual(float.MaxValue, _elapsedTimeTotal);
        var duration = settings.Duration;
        if(duration == 0f)
        {
            if(loopsTotal == -1)
            {
                // add max one cycle per frame
                if(timeScale > 0f)
                {
                    if(loopsDone == iniLoopsDone)
                    {
                        loopsDone = 1;
                    }
                    else
                    {
                        loopsDone++;
                    }
                }
                else if(timeScale != 0f)
                {
                    loopsDone--;
                    if(loopsDone == iniLoopsDone)
                    {
                        newState = State.Before;
                        return 0f;
                    }
                }
                newState = State.Running;
                return 1f;
            }
            Assert.AreNotEqual(-1, loopsTotal);
            if(_elapsedTimeTotal == 0f)
            {
                loopsDone = iniLoopsDone;
                newState = State.Before;
                return 0f;
            }
            Assert.IsTrue(loopsDone <= loopsTotal);
            loopsDone = loopsTotal;
            newState = State.After;
            return 1f;
        }
        Assert.AreNotEqual(0f, loopDuration);
        loopsDone = (int)(_elapsedTimeTotal / loopDuration);
        if(loopsTotal != -1 && loopsDone > loopsTotal)
        {
            loopsDone = loopsTotal;
        }
        if(loopsTotal != -1 && loopsDone == loopsTotal)
        {
            newState = State.After;
            return 1f;
        }
        var elapsedTimeInCycle = _elapsedTimeTotal - loopDuration * loopsDone - settings.startDelay;
        if(elapsedTimeInCycle < 0f)
        {
            newState = State.Before;
            return 0f;
        }
        Assert.IsTrue(elapsedTimeInCycle >= 0f);
        Assert.AreNotEqual(0f, duration);
        var result = elapsedTimeInCycle / duration;
        if(result > 1f)
        {
            newState = State.After;
            return 1f;
        }
        newState = State.Running;
        Assert.IsTrue(result >= 0f);
        return result;
    }
    internal void Reset()
    {
        Assert.IsFalse(isUpdating);
        Assert.IsFalse(_isAlive);
        Assert.IsFalse(sequence.IsCreated);
        Assert.IsFalse(prev.IsCreated);
        Assert.IsFalse(next.IsCreated);
        Assert.IsFalse(prevSibling.IsCreated);
        Assert.IsFalse(nextSibling.IsCreated);
        Assert.IsFalse(IsInSequence());
        if(shakeData.isAlive)
        {
            shakeData.Reset(this);
        }
#if UNITY_EDITOR
        debugDescription = null;
        unityTarget = null;
#endif
        id = -1;
        target = null;
        setPropType(PropType.None);
        settings.customEase = null;
        customOnValueChange = null;
        onValueChange = null;
        onComplete = null;
        onCompleteCallback = null;
        onCompleteTarget = null;
        getter = null;
        stoppedEmergently = false;
        waitDelay = 0f;
        coroutineEnumerator.resetEnumerator();
        tweenType = TweenType.None;
        timeScale = 1f;
        warnIgnoredOnCompleteIfTargetDestroyed = true;
        ClearOnUpdate();
    }
    internal void OnComplete(Action _onComplete, bool warnIfTargetDestroyed)
    {
        Assert.IsNotNull(_onComplete);
        ValidateOnCompleteAssignment();
        warnIgnoredOnCompleteIfTargetDestroyed = warnIfTargetDestroyed;
        onCompleteCallback = _onComplete;
        onComplete = tween =>
        {
            var callback = tween.onCompleteCallback as Action;
            Assert.IsNotNull(callback);
            try
            {
                callback();
            }
            catch(Exception e)
            {
                tween.HandleOnCompleteException(e);
            }
        };
    }
    internal void OnComplete<T>(T _target, Action<T> _onComplete, bool warnIfTargetDestroyed) where T : class
    {
        if(_target == null || IsDestroyedUnityObject(_target))
        {          
            return;
        }
        Assert.IsNotNull(_onComplete);
        ValidateOnCompleteAssignment();
        warnIgnoredOnCompleteIfTargetDestroyed = warnIfTargetDestroyed;
        onCompleteTarget = _target;
        onCompleteCallback = _onComplete;
        onComplete = tween =>
        {
            var callback = tween.onCompleteCallback as Action<T>;
            Assert.IsNotNull(callback);
            var _onCompleteTarget = tween.onCompleteTarget as T;
            if(IsDestroyedUnityObject(_onCompleteTarget))
            {
                tween.WarnOnCompleteIgnored(true);
                return;
            }
            try
            {
                callback(_onCompleteTarget);
            }
            catch(Exception e)
            {
                tween.HandleOnCompleteException(e);
            }
        };
    }
    void HandleOnCompleteException(Exception e)
    {
        // Design decision: if a tween is inside a W_Sequence and user's tween.OnComplete() throws an exception, the W_Sequence should continue
        Assert.LogError($"Tween's onComplete callback raised exception, tween: {GetDescription()}, exception:\n{e}\n", id, target as UnityEngine.Object);
    }
    static bool IsDestroyedUnityObject<T>(T obj) where T : class => obj is UnityEngine.Object unityObject && unityObject == null;
    void ValidateOnCompleteAssignment()
    {
        const string msg = "Tween already has an onComplete callback. Adding more callbacks is not allowed.\n" +
                           "Workaround: wrap a tween in a Sequence by calling Sequence.Create(tween) and use multiple ChainCallback().\n";
        Assert.IsNull(onCompleteTarget, msg);
        Assert.IsNull(onCompleteCallback, msg);
        Assert.IsNull(onComplete, msg);
    }
    /// _getter is null for custom tweens
    internal void Setup(object _target, ref TweenSettings _settings, Action<ReusableTween> _onValueChange, Func<ReusableTween, ValueContainer> _getter, bool _startFromCurrent, TweenType _tweenType)
    {
        Assert.IsTrue(_settings.loops >= -1);
        Assert.IsNotNull(_onValueChange);
        Assert.IsNull(getter);
        tweenType = _tweenType;
        var propertyType = getPropType();
        Assert.AreNotEqual(PropType.None, propertyType);
        Assert.AreEqual(propType, getPropType());

        if(_settings.EaseType == W_Ease.Default)
        {
            _settings.EaseType = TweenManager.Instance.defaultEase;
        }
        else if(_settings.EaseType == W_Ease.Custom && _settings.parametricEase == ParametricEase.None)
        {
            if(_settings.customEase == null || !TweenSettings.ValidateCustomCurveKeyframes(_settings.customEase))
            {
                Debug.LogError($"Ease type is Ease.Custom, but {nameof(TweenSettings.customEase)} is not configured correctly.");
                _settings.EaseType = TweenManager.Instance.defaultEase;
            }
        }
        state = State.Before;
        target = _target;
        SetUnityTarget(_target);
        elapsedTimeTotal = 0f;
        easedInterpolationFactor = float.MinValue;
        _isPaused = false;
        Revive();

        loopsDone = iniLoopsDone;
        _settings.SetValidValues();
        settings.CopyFrom(ref _settings);
        RecalculateTotalDuration();
        Assert.IsTrue(loopDuration >= 0);
        onValueChange = _onValueChange;
        Assert.IsFalse(_startFromCurrent && _getter == null);
        startFromCurrent = _startFromCurrent;
        getter = _getter;
        if(!_startFromCurrent)
        {
            CacheDiff();
        }
        if(propertyType == PropType.Quaternion)
        {
            prevVal.QuaternionVal = Quaternion.identity;
        }
        else
        {
            prevVal.Reset();
        }
        warnEndValueEqualsCurrent = TweenManager.Instance.warnEndValueEqualsCurrent;
    }

    internal void SetUnityTarget(object _target)
    {
#if UNITY_EDITOR
        unityTarget = _target as UnityEngine.Object;
#endif
    }

    /// W_Tween.Custom and W_Tween.ShakeCustom try-catch the <see cref="onValueChange"/> and calls <see cref="ReusableTween.EmergencyStop"/> if an exception occurs.
    /// <see cref="ReusableTween.EmergencyStop"/> sets <see cref="stoppedEmergently"/> to true.
    internal void ReportOnValueChange(float _easedInterpolationFactor)
    {
        Assert.IsFalse(IsUnityTargetDestroyed());
        if(startFromCurrent)
        {
            startFromCurrent = false;
            if(!ShakeData.TryTakeStartValueFromOtherShake(this))
            {
                startValue = getter(this);
            }           
            CacheDiff();
        }
        easedInterpolationFactor = _easedInterpolationFactor;
        onValueChange(this);
        if(stoppedEmergently || !_isAlive)
        {
            return;
        }
        onUpdate?.Invoke(this);
    }
    void ReportOnComplete()
    {
        Assert.IsFalse(startFromCurrent);
        Assert.IsTrue(timeScale < 0 || loopsDone == settings.loops);
        Assert.IsTrue(timeScale >= 0 || loopsDone == iniLoopsDone);
        onComplete?.Invoke(this);
    }
    internal bool IsUnityTargetDestroyed()
    {
        return IsDestroyedUnityObject(target);
    }
    internal bool HasOnComplete => onComplete != null;
    internal string GetDescription()
    {
        string result = "";
        if(!_isAlive)
        {
            result += " - ";
        }
        if(target != TweenManager.dummyTarget)
        {
            result += $"{(target is UnityEngine.Object unityObject && unityObject != null ? unityObject.name : target?.GetType().Name)} / ";
        }
        var duration = settings.Duration;
        if(tweenType == TweenType.Delay)
        {
            if(duration == 0f && onComplete != null)
            {
                result += "Callback";
            }
            else
            {
                result += $"Delay / duration {duration}";
            }
        }
        else
        {
            if(tweenType == TweenType.MainSequence)
            {
                result += $"Sequence {id}";
            }
            else if(tweenType == TweenType.NestedSequence)
            {
                result += $"Sequence {id} (nested)";
            }
            else
            {
                result += tweenType.ToString();
            }
            result += " / duration ";

            result += $"{duration}";
        }
        result += $" / id {id}";
        if(sequence.IsCreated && tweenType != TweenType.MainSequence)
        {
            result += $" / sequence {sequence.root.Id}";
        }
        return result;
    }
    internal float CalcDurationWithWaitDependencies()
    {
        var loops = settings.loops;
        Assert.AreNotEqual(-1, loops, "It's impossible to calculate the duration of an infinite tween (loops == -1).");
        Assert.AreNotEqual(0, loops);
        return waitDelay + loopDuration * loops;
    }
    internal void RecalculateTotalDuration()
    {
        loopDuration = settings.startDelay + settings.Duration + settings.endDelay;
    }
    float CalcEasedT(float t, int loopsDone)
    {
        switch(settings.loopMode)
        {
            case W_LoopMode.Restart:
                return Evaluate(t);
            case W_LoopMode.Incremental:
                return Evaluate(t) + clampLoopsDone();
            case W_LoopMode.Yoyo:
                {
                    var isForwardCycle = clampLoopsDone() % 2 == 0;
                    return isForwardCycle ? Evaluate(t) : 1 - Evaluate(t);
                }
            case W_LoopMode.Rewind:
                {
                    var isForwardCycle = clampLoopsDone() % 2 == 0;
                    return isForwardCycle ? Evaluate(t) : Evaluate(1 - t);
                }
            default:
                throw new Exception();
        }

        int clampLoopsDone()
        {
            if(loopsDone == iniLoopsDone)
            {
                return 0;
            }
            int loopsTotal = settings.loops;
            if(loopsDone == loopsTotal)
            {
                Assert.AreNotEqual(-1, loopsTotal);
                return loopsTotal - 1;
            }
            return loopsDone;
        }
    }
    float Evaluate(float t)
    {
        if(settings.EaseType == W_Ease.Custom)
        {
            if(settings.parametricEase != ParametricEase.None)
            {
                return W_Easing.Evaluate(t, this);
            }
            return settings.customEase.Evaluate(t);
        }
        return StandardEasing.Evaluate(t, settings.EaseType);
    }
    internal void CacheDiff()
    {
        Assert.IsFalse(startFromCurrent);
        var propertyType = getPropType();
        Assert.AreNotEqual(PropType.None, propertyType);
        switch(propertyType)
        {
            case PropType.Quaternion:
                startValue.QuaternionVal.Normalize();
                endValue.QuaternionVal.Normalize();
                break;
            case PropType.Double:
                diff.DoubleVal = endValue.DoubleVal - startValue.DoubleVal;
                diff.z = 0;
                diff.w = 0;
                break;
            default:
                diff.x = endValue.x - startValue.x;
                diff.y = endValue.y - startValue.y;
                diff.z = endValue.z - startValue.z;
                diff.w = endValue.w - startValue.w;
                break;
        }
    }
    internal void ForceComplete()
    {
        Assert.IsFalse(sequence.IsCreated);
        Kill(); // protects from recursive call
        if(IsUnityTargetDestroyed())
        {
            WarnOnCompleteIgnored(true);
            return;
        }
        var loopsTotal = settings.loops;
        if(loopsTotal == -1)
        {
            // same as SetRemainingLoops(1)
            loopsTotal = GetLoopsDone() + 1;
            settings.loops = loopsTotal;
        }
        loopsDone = loopsTotal;
        ReportOnValueChange(CalcEasedT(1f, loopsTotal));
        if(stoppedEmergently)
        {
            return;
        }
        ReportOnComplete();
        Assert.IsFalse(_isAlive);
    }
    internal void WarnOnCompleteIgnored(bool isTargetDestroyed)
    {
        if(HasOnComplete && warnIgnoredOnCompleteIfTargetDestroyed)
        {
            onComplete = null;            
        }
    }
    internal void EmergencyStop(bool isTargetDestroyed = false)
    {
        if(sequence.IsCreated)
        {
            var mainSequence = sequence;
            while(true)
            {
                var _prev = mainSequence.root.tween.prev;
                if(!_prev.IsCreated)
                {
                    break;
                }
                var parent = _prev.tween.sequence;
                if(!parent.IsCreated)
                {
                    break;
                }
                mainSequence = parent;
            }
            Assert.IsTrue(mainSequence.root.tween.IsMainSequenceRoot());
            mainSequence.emergencyStop();
        }
        else if(_isAlive)
        {
            // EmergencyStop() can be called after ForceComplete() and a caught exception in W_Tween.Custom()
            Kill();
        }
        stoppedEmergently = true;
        WarnOnCompleteIgnored(isTargetDestroyed);
        Assert.IsFalse(_isAlive);
        Assert.IsFalse(sequence.isAlive);
    }
    internal void Kill()
    {
        Assert.IsTrue(_isAlive);
        _isAlive = false;
#if UNITY_EDITOR
        debugDescription = null;
#endif
    }
    void Revive()
    {
        Assert.IsFalse(_isAlive);
        _isAlive = true;
#if UNITY_EDITOR
        debugDescription = null;
#endif
    }
    internal bool IsInSequence()
    {
        var result = sequence.IsCreated;
        Assert.IsTrue(result || !nextSibling.IsCreated);
        return result;
    }
    internal bool CanManipulate() => !IsInSequence() || IsMainSequenceRoot();
    internal bool TrySetPause(bool isPaused)
    {
        if(_isPaused == isPaused)
        {
            return false;
        }
        _isPaused = isPaused;
        return true;
    }
    internal void SetOnUpdate<T>(T _target, Action<T, W_Tween> _onUpdate) where T : class
    {
        Assert.IsNull(onUpdate, "Only one OnUpdate() is allowed for one tween.");
        Assert.IsNotNull(_onUpdate, nameof(_onUpdate) + " is null!");
        onUpdateTarget = _target;
        onUpdateCallback = _onUpdate;
        onUpdate = reusableTween => reusableTween.InvokeOnUpdate<T>();
    }
    void InvokeOnUpdate<T>() where T : class
    {
        var callback = onUpdateCallback as Action<T, W_Tween>;
        Assert.IsNotNull(callback);
        var _onUpdateTarget = onUpdateTarget as T;
        if(IsDestroyedUnityObject(_onUpdateTarget))
        {
            Assert.LogError($"OnUpdate() will not be called again because OnUpdate()'s target has been destroyed, tween: {GetDescription()}", id, target as UnityEngine.Object);
            ClearOnUpdate();
            return;
        }
        try
        {
            callback(_onUpdateTarget, new W_Tween(this));
        }
        catch(Exception e)
        {
            Assert.LogError($"OnUpdate() will not be called again because it thrown exception, tween: {GetDescription()}, exception:\n{e}", id, target as UnityEngine.Object);
            ClearOnUpdate();
        }
    }
    void ClearOnUpdate()
    {
        onUpdateTarget = null;
        onUpdateCallback = null;
        onUpdate = null;
    }
    internal float GetElapsedTimeTotal()
    {
        var result = elapsedTimeTotal;
        var durationTotal = GetDurationTotal();
        if(result == float.MaxValue)
        {
            return durationTotal;
        }
        return Mathf.Clamp(result, 0f, durationTotal);
    }
    internal float GetDurationTotal()
    {
        var loopsTotal = settings.loops;
        if(loopsTotal == -1)
        {
            return float.PositiveInfinity;
        }
        Assert.AreNotEqual(0, loopsTotal);
        return loopDuration * loopsTotal;
    }
    internal int GetLoopsDone()
    {
        int result = loopsDone;
        if(result == iniLoopsDone)
        {
            return 0;
        }
        Assert.IsTrue(result >= 0);
        return result;
    }
    public override string ToString()
    {
        return GetDescription();
    }
}