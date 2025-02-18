using System;
using UnityEngine;

[Serializable]
public partial struct W_Tween : IEquatable<W_Tween>
{
    /// Uniquely identifies the tween.
    internal long Id;

    internal readonly ReusableTween tween;

    internal bool IsCreated => Id != 0;

    internal W_Tween(ReusableTween tween)
    {
        Assert.IsNotNull(tween);
        Assert.AreNotEqual(-1, tween.id);
        Id = tween.id;
        this.tween = tween;
    }

    /// A tween is 'alive' when it has been created and is not stopped or completed yet. Paused tween is also considered 'alive'.
    public bool IsAlive => Id != 0 && tween.id == Id && tween._isAlive;

    /// Elapsed time of the current cycle.
    public float ElapsedTime
    {
        get
        {
            if(!ValidateIsAlive())
            {
                return 0;
            }
            if(LoopsDone == loopsTotal)
            {
                return Duration;
            }
            var result = ElapsedTimeTotal - Duration * LoopsDone;
            if(result < 0f)
            {
                return 0f;
            }
            Assert.IsTrue(result >= 0f);
            return result;
        }
        set => SetElapsedTime(value);
    }

    void SetElapsedTime(float value)
    {
        if(!TryManipulate())
        {
            return;
        }
        if(value < 0f || float.IsNaN(value))
        {
            Debug.LogError($"Invalid elapsedTime value: {value}, tween: {ToString()}");
            return;
        }
        var cycleDuration = Duration;
        if(value > cycleDuration)
        {
            value = cycleDuration;
        }
        var _loopsDone = LoopsDone;
        if(_loopsDone == loopsTotal)
        {
            _loopsDone -= 1;
        }
        SetElapsedTimeTotal(value + cycleDuration * _loopsDone);
    }

    /// The total number of Loops. Returns -1 to indicate infinite number Loops.
    public int loopsTotal => ValidateIsAlive() ? tween.settings.loops : 0;

    public int LoopsDone => ValidateIsAlive() ? tween.GetLoopsDone() : 0;
    /// The Duration of one cycle.
    public float Duration
    {
        get
        {
            if(!ValidateIsAlive())
            {
                return 0;
            }
            var result = tween.loopDuration;
            return result;
        }
    }

    public override string ToString() => IsAlive ? tween.GetDescription() : $"DEAD / id {Id}";

    /// Elapsed time of all Loops.
    public float ElapsedTimeTotal
    {
        get => ValidateIsAlive() ? tween.GetElapsedTimeTotal() : 0;
        set => SetElapsedTimeTotal(value);
    }

    void SetElapsedTimeTotal(float value)
    {
        if(!TryManipulate())
        {
            return;
        }
        if(value < 0f || float.IsNaN(value) || (loopsTotal == -1 && value >= float.MaxValue))
        { // >= tests for positive infinity, see SetInfiniteTweenElapsedTime() test
            Debug.LogError($"Invalid elapsedTimeTotal value: {value}, tween: {ToString()}");
            return;
        }
        tween.SetElapsedTimeTotal(value, false);
        // SetElapsedTimeTotal may complete the tween, so isAlive check is needed
        if(IsAlive && value > DurationTotal)
        {
            tween.elapsedTimeTotal = DurationTotal;
        }
    }

    /// <summary>The Duration of all Loops. If Loops == -1, returns <see cref="float.PositiveInfinity"/>.</summary>
    public float DurationTotal => ValidateIsAlive() ? tween.GetDurationTotal() : 0;

    /// Normalized progress of the current cycle expressed in 0..1 range.
    public float Progress
    {
        get
        {
            if(!ValidateIsAlive())
            {
                return 0;
            }
            if(Duration == 0)
            {
                return 0;
            }
            return Mathf.Min(ElapsedTime / Duration, 1f);
        }
        set
        {
            value = Mathf.Clamp01(value);
            if(value == 1f)
            {
                bool isLastCycle = LoopsDone == loopsTotal - 1;
                if(isLastCycle)
                {
                    SetElapsedTimeTotal(float.MaxValue);
                    return;
                }
            }
            SetElapsedTime(value * Duration);
        }
    }

    /// Normalized progress of all Loops expressed in 0..1 range.
    public float ProgressTotal
    {
        get
        {
            if(!ValidateIsAlive())
            {
                return 0;
            }
            if(loopsTotal == -1)
            {
                return 0;
            }
            var _totalDuration = DurationTotal;
            Assert.IsFalse(float.IsInfinity(_totalDuration));
            if(_totalDuration == 0)
            {
                return 0;
            }
            return Mathf.Min(ElapsedTimeTotal / _totalDuration, 1f);
        }
        set
        {
            if(loopsTotal == -1)
            {
                Debug.LogError($"It's not allowed to set progressTotal on infinite tween (loopsTotal == -1), tween: {ToString()}.");
                return;
            }
            value = Mathf.Clamp01(value);
            if(value == 1f)
            {
                SetElapsedTimeTotal(float.MaxValue);
                return;
            }
            SetElapsedTimeTotal(value * DurationTotal);
        }
    }

    /// <summary>The current percentage of change between 'startValue' and 'endValue' values in 0..1 range.</summary>
    public float InterpolationFactor => ValidateIsAlive() ? Mathf.Max(0f, tween.easedInterpolationFactor) : 0f;

    public bool IsPaused
    {
        get => TryManipulate() && tween._isPaused;
        set
        {
            if(TryManipulate() && tween.TrySetPause(value))
            {
                if(value)
                {
                    return;
                }
                if((TimeScale > 0 && ProgressTotal >= 1f) ||
                    (TimeScale < 0 && ProgressTotal == 0f))
                {
                    if(tween.IsMainSequenceRoot())
                    {
                        tween.sequence.releaseTweens();
                    }
                    else
                    {
                        tween.Kill();
                    }
                }
            }
        }
    }

    /// Interrupts the tween, ignoring onComplete callback.
    public void Stop()
    {
        if(IsAlive && TryManipulate())
        {
            tween.Kill();
        }
    }

    /// <summary>Immediately completes the tween.<br/>
    /// If the tween has infinite Loops (Loops == -1), completes only the current cycle. To choose between 'startValue' and 'endValue' in the case of infinite Loops, use <see cref="SetRemainingLoops(bool stopAtEndValue)"/> before calling Complete().</summary>
    public void Complete()
    {
        // don't warn that tween is dead because dead tween means that it's already 'completed'
        if(IsAlive && TryManipulate())
        {
            tween.ForceComplete();
        }
    }

    internal bool TryManipulate()
    {
        if(!ValidateIsAlive())
        {
            return false;
        }
        if(!tween.CanManipulate())
        {
            return false;
        }
        return true;
    }

    /// <summary>Stops the tween when it reaches 'startValue' or 'endValue' for the next time.<br/>
    /// For example, if you have an infinite tween (Loops == -1) with W_LoopMode.Yoyo/Rewind, and you wish to stop it when it reaches the 'endValue', then set <see cref="stopAtEndValue"/> to true.
    /// To stop the animation at the 'startValue', set <see cref="stopAtEndValue"/> to false.</summary>
    public void SetRemainingLoops(bool stopAtEndValue)
    {
        if(!TryManipulate())
        {
            return;
        }
        if(tween.settings.loopMode == W_LoopMode.Restart || tween.settings.loopMode == W_LoopMode.Incremental)
        {
            Debug.LogWarning(nameof(SetRemainingLoops) + "(bool " + nameof(stopAtEndValue) + ") is meant to be used with loopMode.Yoyo or Rewind. Please consider using the overload that accepts int instead.");
        }
        SetRemainingLoops(tween.GetLoopsDone() % 2 == 0 == stopAtEndValue ? 1 : 2);
    }

    /// <summary>Sets the number of remaining Loops.<br/>
    /// This method modifies the <see cref="loopsTotal"/> so that the tween will complete after the number of <see cref="loops"/>.<br/>
    /// To set the initial number of Loops, pass the 'Loops' parameter to 'W_Tween.' methods instead.<br/><br/>
    /// Setting Loops to -1 will repeat the tween indefinitely.<br/></summary>
    public void SetRemainingLoops(int loops)
    {
        Assert.IsTrue(loops >= -1);
        if(!TryManipulate())
        {
            return;
        }
        if(tween.timeScale < 0f)
        {
            Debug.LogError(nameof(SetRemainingLoops) + "() doesn't work with negative " + nameof(tween.timeScale));
        }
        if(tween.tweenType == TweenType.Delay && tween.HasOnComplete)
        {
            Debug.LogError("Applying loops to Delay will not repeat the OnComplete() callback, but instead will increase the Delay duration.\n" +
                           "OnComplete() is called only once when ALL tween loops complete. To repeat the OnComplete() callback, please use the Sequence.Create(loops: numLoops) and put the tween inside a Sequence.");
        }
        if(loops == -1)
        {
            tween.settings.loops = -1;
        }
        else
        {
            TweenSettings.SetLoopsTo1If0(ref loops);
            tween.settings.loops = tween.GetLoopsDone() + loops;
        }
    }

    /// <summary>Adds completion callback. Please consider using <see cref="OnComplete{T}"/> to prevent a possible capture of variable into a closure.</summary>
    /// <param name="warnIfTargetDestroyed">Set to 'false' to disable the error about target's destruction. Please note that the the <see cref="onComplete"/> callback will be silently ignored in the case of target's destruction.</param>
    public W_Tween OnComplete(Action onComplete, bool warnIfTargetDestroyed = true)
    {
        if(ValidateIsAlive())
        {
            tween.OnComplete(onComplete, warnIfTargetDestroyed);
        }
        return this;
    }

    /// <summary>Adds completion callback.</summary>
    /// <param name="warnIfTargetDestroyed">Set to 'false' to disable the error about target's destruction. Please note that the the <see cref="onComplete"/> callback will be silently ignored in the case of target's destruction.</param>
    /// <example>The example shows how to destroy the object after the completion of a tween.
    /// Please note: we're using the '_transform' variable from the onComplete callback to prevent garbage allocation. Using the 'transform' variable directly will capture it into a closure and generate garbage.
    /// <code>
    /// W_Tween.PositionX(transform, endValue: 1.5f, Duration: 1f)
    ///     .OnComplete(transform, _transform =&gt; Destroy(_transform.gameObject));
    /// </code></example>
    public W_Tween OnComplete<T>(T target, Action<T> onComplete, bool warnIfTargetDestroyed = true) where T : class
    {
        if(ValidateIsAlive())
        {
            tween.OnComplete(target, onComplete, warnIfTargetDestroyed);
        }
        return this;
    }

    public W_Sequence Group(W_Tween _tween) => TryManipulate() ? W_Sequence.Create(this).Group(_tween) : default;
    public W_Sequence Chain(W_Tween _tween) => TryManipulate() ? W_Sequence.Create(this).Chain(_tween) : default;
    public W_Sequence Group(W_Sequence sequence) => TryManipulate() ? W_Sequence.Create(this).Group(sequence) : default;
    public W_Sequence Chain(W_Sequence sequence) => TryManipulate() ? W_Sequence.Create(this).Chain(sequence) : default;

    bool ValidateIsAlive()
    {        
        return IsAlive;
    }

    /// <summary>Custom timeScale. To smoothly Animate timeScale over time, use <see cref="W_Tween.TweenTimeScale"/> method.</summary>
    public float TimeScale
    {
        get => TryManipulate() ? tween.timeScale : 1;
        set
        {
            if(TryManipulate())
            {
                Assert.IsFalse(float.IsNaN(value));
                Assert.IsFalse(float.IsInfinity(value));
                tween.timeScale = value;
            }
        }
    }

    public W_Tween OnUpdate<T>(T target, Action<T, W_Tween> onUpdate) where T : class
    {
        if(ValidateIsAlive())
        {
            tween.SetOnUpdate(target, onUpdate);
        }
        return this;
    }

    internal float DurationWithWaitDelay => tween.CalcDurationWithWaitDependencies();

    public override int GetHashCode() => Id.GetHashCode();
    public bool Equals(W_Tween other) => IsAlive && other.IsAlive && Id == other.Id;
}