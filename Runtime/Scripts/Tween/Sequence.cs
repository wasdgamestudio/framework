using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>An ordered group of tweens and callbacks. Tweens in a sequence can run in parallel to one another with <see cref="Group"/> and sequentially with <see cref="Chain"/>.<br/>
/// To make tweens in a W_Sequence overlap each other, use <see cref="TweenSettings.startDelay"/> and <see cref="TweenSettings.endDelay"/>.</summary>
/// <example><code>
/// W_Sequence.Create()
///     .Group(W_Tween.PositionX(transform, endValue: 10f, Duration: 1.5f))
///     .Group(W_Tween.Scale(transform, endValue: 2f, Duration: 0.5f)) // position and localScale tweens will run in parallel because they are 'grouped'
///     .Chain(W_Tween.Rotation(transform, endValue: new Vector3(0f, 0f, 45f), Duration: 1f)) // rotation tween is 'chained' so it will start when both previous tweens are finished (after 1.5 seconds)
///     .ChainCallback(() =&gt; Debug.Log("W_Sequence completed"));
/// </code></example>
public partial struct W_Sequence : IEquatable<W_Sequence>
{
    const int emptySequenceTag = -43;
    internal W_Tween root;
    internal bool IsCreated => root.IsCreated;
    long id => root.Id;

    /// W_Sequence is 'alive' when any of its tweens is 'alive'.
    public bool isAlive => root.IsAlive;

    /// Elapsed time of the current cycle.
    public float elapsedTime
    {
        get => root.ElapsedTime;
        set => root.ElapsedTime = value;
    }

    /// The total number of loops. Returns -1 to indicate infinite number loops.
    public int loopsTotal => root.loopsTotal;
    public int loopsDone => root.LoopsDone;
    /// The Duration of one cycle.
    public float duration
    {
        get => root.Duration;
        private set
        {
            Assert.IsTrue(isAlive);
            Assert.IsTrue(root.tween.IsMainSequenceRoot());
            var rootTween = root.tween;
            Assert.AreEqual(0f, elapsedTimeTotal);
            Assert.IsTrue(value >= rootTween.loopDuration);
            Assert.IsTrue(value >= rootTween.settings.Duration);
            Assert.AreEqual(0f, rootTween.settings.startDelay);
            Assert.AreEqual(0f, rootTween.settings.endDelay);
            rootTween.settings.Duration = value;
            rootTween.loopDuration = value;
        }
    }

    /// Elapsed time of all loops.
    public float elapsedTimeTotal
    {
        get => root.ElapsedTimeTotal;
        set => root.ElapsedTimeTotal = value;
    }

    /// <summary>The Duration of all loops. If loops == -1, returns <see cref="float.PositiveInfinity"/>.</summary>
    public float durationTotal => root.DurationTotal;

    /// Normalized progress of the current cycle expressed in 0..1 range.
    public float progress
    {
        get => root.Progress;
        set => root.Progress = value;
    }

    /// Normalized progress of all loops expressed in 0..1 range.
    public float progressTotal
    {
        get => root.ProgressTotal;
        set => root.ProgressTotal = value;
    }

    bool tryManipulate() => root.TryManipulate();

    bool ValidateCanManipulateSequence()
    {
        if(!tryManipulate())
        {
            return false;
        }
        if(root.ElapsedTimeTotal != 0f)
        {
            return false;
        }
        return true;
    }

    public static W_Sequence Create(int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, W_Ease sequenceEase = W_Ease.Linear, bool useUnscaledTime = false, bool useFixedUpdate = false)
    {
        var tween = TweenManager.FetchTween();
        tween.setPropType(PropType.Float);
        if(loopMode == W_LoopMode.Incremental)
        {
            Debug.LogError($"Sequence doesn't support loopMode.Incremental. Parameter {nameof(sequenceEase)} is applied to the sequence's 'timeline', and incrementing the 'timeline' doesn't make sense. For the same reason, {nameof(sequenceEase)} is clamped to [0:1] range.");
            loopMode = W_LoopMode.Restart;
        }
        if(sequenceEase == W_Ease.Custom)
        {
            Debug.LogError("Sequence doesn't support Ease.Custom.");
            sequenceEase = W_Ease.Linear;
        }
        if(sequenceEase == W_Ease.Default)
        {
            sequenceEase = W_Ease.Linear;
        }
        var settings = new TweenSettings(0f, sequenceEase, loops, loopMode, 0f, 0f, useUnscaledTime, useFixedUpdate);
        tween.Setup(TweenManager.dummyTarget, ref settings, _ => { }, null, false, TweenType.MainSequence);
        tween.intParam = emptySequenceTag;
        var root = TweenManager.AddTween(tween);
        Assert.IsTrue(root.IsAlive);
        return new W_Sequence(root);
    }

    public static W_Sequence Create(W_Tween firstTween)
    {
        return Create().Group(firstTween);
    }

    W_Sequence(W_Tween rootTween)
    {
        root = rootTween;
        setSequence(rootTween);
        Assert.IsTrue(isAlive);
        Assert.AreEqual(0f, duration);
        Assert.IsTrue(durationTotal == 0f || float.IsPositiveInfinity(durationTotal));
    }

    /// <summary>Groups <paramref name="tween"/> with the 'previous' animation in this W_Sequence.<br/>
    /// The 'previous' animation is the animation used in the preceding Group/Chain/Insert() method call.<br/>
    /// Grouped animations start at the same time and run in parallel.</summary>
    public W_Sequence Group(W_Tween tween)
    {
        if(tryManipulate())
        {
            Insert(getLastInSelfOrRoot().tween.waitDelay, tween);
        }
        return this;
    }

    void addLinkedReference(W_Tween tween)
    {
        W_Tween last;
        if(root.tween.next.IsCreated)
        {
            last = getLast();
            var lastInSelf = getLastInSelfOrRoot();
            Assert.AreNotEqual(root.Id, lastInSelf.Id);
            Assert.IsFalse(lastInSelf.tween.nextSibling.IsCreated);
            lastInSelf.tween.nextSibling = tween;
            Assert.IsFalse(tween.tween.prevSibling.IsCreated);
            tween.tween.prevSibling = lastInSelf;
        }
        else
        {
            last = root;
        }

        Assert.IsFalse(last.tween.next.IsCreated);
        Assert.IsFalse(tween.tween.prev.IsCreated);
        last.tween.next = tween;
        tween.tween.prev = last;
        root.tween.intParam = 0;
    }

    W_Tween getLast()
    {
        W_Tween result = default;
        foreach(var current in getAllTweens())
        {
            result = current;
        }
        Assert.IsTrue(result.IsCreated);
        Assert.IsFalse(result.tween.next.IsCreated);
        return result;
    }

    /// <summary>Places <paramref name="tween"/> after all previously added animations in this sequence. Chained animations run sequentially after one another.</summary>
    public W_Sequence Chain(W_Tween tween)
    {
        if(tryManipulate())
        {
            Insert(duration, tween);
        }
        return this;
    }

    /// <summary>Places <paramref name="tween"/> inside this W_Sequence at time <paramref name="atTime"/>, overlapping with other animations.<br/>
    /// The total sequence Duration is increased if the inserted <paramref name="tween"/> doesn't fit inside the current sequence Duration.</summary>
    public W_Sequence Insert(float atTime, W_Tween tween)
    {
        if(!ValidateCanAdd(tween))
        {
            return this;
        }
        if(tween.tween.sequence.IsCreated)
        {           
            return this;
        }
        setSequence(tween);
        Insert_internal(atTime, tween);
        return this;
    }

    void Insert_internal(float atTime, W_Tween other)
    {
        Assert.AreEqual(0f, other.tween.waitDelay);
        other.tween.waitDelay = atTime;
        duration = Mathf.Max(duration, other.DurationWithWaitDelay);
        addLinkedReference(other);
    }

    /// <summary>Schedules <see cref="callback"/> after all previously added tweens.</summary>
    /// <param name="warnIfTargetDestroyed"></param>
    public W_Sequence ChainCallback(Action callback, bool warnIfTargetDestroyed = true)
    {
        if(tryManipulate())
        {
            InsertCallback(duration, callback, warnIfTargetDestroyed);
        }
        return this;
    }

    public W_Sequence InsertCallback(float atTime, Action callback, bool warnIfTargetDestroyed = true)
    {
        if(!tryManipulate())
        {
            return this;
        }
        var delay = TweenManager.DelayWithoutDurationCheck(TweenManager.dummyTarget, 0f, false);
        Assert.IsTrue(delay.HasValue);
        delay.Value.tween.OnComplete(callback, warnIfTargetDestroyed);
        return Insert(atTime, delay.Value);
    }

    /// <summary>Schedules <see cref="callback"/> after all previously added tweens. Passing 'target' allows to write a non-allocating callback.</summary>
    /// <param name="warnIfTargetDestroyed"></param>
    public W_Sequence ChainCallback<T>(T target, Action<T> callback, bool warnIfTargetDestroyed = true) where T : class
    {
        if(tryManipulate())
        {
            InsertCallback(duration, target, callback, warnIfTargetDestroyed);
        }
        return this;
    }

    public W_Sequence InsertCallback<T>(float atTime, T target, Action<T> callback, bool warnIfTargetDestroyed = true) where T : class
    {
        if(!tryManipulate())
        {
            return this;
        }
        var delay = TweenManager.DelayWithoutDurationCheck(target, 0f, false);
        if(!delay.HasValue)
        {
            return this;
        }
        delay.Value.tween.OnComplete(target, callback, warnIfTargetDestroyed);
        return Insert(atTime, delay.Value);
    }

    /// <summary>Schedules delay after all previously added tweens.</summary>
    public W_Sequence ChainDelay(float duration)
    {
        return Chain(W_Tween.Delay(duration));
    }

    W_Tween getLastInSelfOrRoot()
    {
        Assert.IsTrue(isAlive);
        var result = root;
        foreach(var current in getSelfChildren())
        {
            result = current;
        }
        Assert.IsTrue(result.IsCreated);
        Assert.IsFalse(result.tween.nextSibling.IsCreated);
        return result;
    }

    void setSequence(W_Tween handle)
    {
        Assert.IsTrue(IsCreated);
        Assert.IsTrue(handle.IsAlive);
        var tween = handle.tween;
        Assert.IsFalse(tween.sequence.IsCreated);
        tween.sequence = this;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
    bool ValidateCanAdd(W_Tween other)
    {
        if(!ValidateCanManipulateSequence())
        {
            return false;
        }
        if(!other.IsAlive)
        {
            return false;
        }
        var tween = other.tween;
        if(tween.settings.loops == -1)
        {
            return false;
        }
        var rootTween = root.tween;
        if(tween._isPaused && tween._isPaused != rootTween._isPaused)
        {
            warnIgnoredChildrenSetting(nameof(isPaused));
        }
        if(tween.timeScale != 1f && tween.timeScale != rootTween.timeScale)
        {
            warnIgnoredChildrenSetting(nameof(timeScale));
        }
        if(tween.settings.useUnscaledTime && tween.settings.useUnscaledTime != rootTween.settings.useUnscaledTime)
        {
            warnIgnoredChildrenSetting(nameof(TweenSettings.useUnscaledTime));
        }
        if(tween.settings.UseFixedUpdate && tween.settings.UseFixedUpdate != rootTween.settings.UseFixedUpdate)
        {
            warnIgnoredChildrenSetting(nameof(TweenSettings.UseFixedUpdate));
        }
        void warnIgnoredChildrenSetting(string settingName)
        {
            Debug.LogError($"'{settingName}' was ignored after adding child animation to the Sequence. Parent Sequence controls '{settingName}' of all its children animations.\n" +
                           "To prevent this error:\n" +
                           $"- Use the default value of '{settingName}' in child animation.\n" +
                           $"- OR use the same '{settingName}' in child animation.\n\n");
        }
        return true;
    }

    /// Stops all tweens in the W_Sequence, ignoring callbacks.
    public void Stop()
    {
        if(isAlive && tryManipulate())
        {
            Assert.IsTrue(root.tween.IsMainSequenceRoot());
            releaseTweens();
            Assert.IsFalse(isAlive);
        }
    }

    /// <summary>Immediately completes the sequence.<br/>
    /// If the sequence has infinite loops (loops == -1), completes only the current cycle. To choose where the sequence should stop (at the 'start' or at the 'end') in the case of infinite loops, use <see cref="SetRemainingloops(bool stopAtEndValue)"/> before calling Complete().</summary>
    public void Complete()
    {
        if(isAlive && tryManipulate())
        {
            if(loopsTotal == -1 || root.tween.settings.loopMode == W_LoopMode.Restart)
            {
                SetRemainingLoops(1);
            }
            else
            {
                int loopsLeft = loopsTotal - loopsDone;
                SetRemainingLoops(loopsLeft % 2 == 1 ? 1 : 2);
            }
            root.IsPaused = false;
            Assert.IsTrue(root.tween.IsMainSequenceRoot());
            root.tween.UpdateSequence(float.MaxValue, false, allowSkipChildrenUpdate: false);
            Assert.IsFalse(isAlive);
        }
    }

    internal void emergencyStop()
    {
        Assert.IsTrue(isAlive);
        Assert.IsTrue(root.tween.IsMainSequenceRoot());
        releaseTweens(t => t.WarnOnCompleteIgnored(false));
    }

    internal void releaseTweens(Action<ReusableTween> beforeKill = null)
    {
        var enumerator = getAllTweens();
        enumerator.MoveNext();
        var current = enumerator.Current;
        Assert.IsTrue(current.IsAlive);
        while(true)
        {
            // ReSharper disable once RedundantCast
            W_Tween? next = enumerator.MoveNext() ? enumerator.Current : (W_Tween?)null;
            var tween = current.tween;
            Assert.IsTrue(tween._isAlive);
            beforeKill?.Invoke(tween);
            tween.Kill();
            Assert.IsFalse(tween._isAlive);
            releaseTween(tween);
            if(!next.HasValue)
            {
                break;
            }
            current = next.Value;
        }
        Assert.IsFalse(isAlive); // not IsCreated because this may be a local variable in the user's codebase
    }

    static void releaseTween(ReusableTween tween)
    {
        // Debug.Log($"[{Time.frameCount}] releaseTween {tween.id}");
        Assert.AreNotEqual(0, tween.sequence.root.Id);
        tween.next = default;
        tween.prev = default;
        tween.prevSibling = default;
        tween.nextSibling = default;
        tween.sequence = default;
        if(tween.IsSequenceRoot())
        {
            tween.tweenType = TweenType.None;
            Assert.IsFalse(tween.IsSequenceRoot());
        }
    }

    internal SequenceChildrenEnumerator getAllChildren()
    {
        var enumerator = getAllTweens();
        var movedNext = enumerator.MoveNext(); // skip self
        Assert.IsTrue(movedNext);
        Assert.AreEqual(root, enumerator.Current);
        return enumerator;
    }

    /// <summary>Stops the sequence when it reaches the 'end' or returns to the 'start' for the next time.<br/>
    /// For example, if you have an infinite sequence (loops == -1) with W_LoopMode.Yoyo/Rewind, and you wish to stop it when it reaches the 'end', then set <see cref="stopAtEndValue"/> to true.
    /// To stop the animation at the 'beginning', set <see cref="stopAtEndValue"/> to false.</summary>
    public void SetRemainingLoops(bool stopAtEndValue)
    {
        root.SetRemainingLoops(stopAtEndValue);
    }

    /// <summary>Sets the number of remaining loops.<br/>
    /// This method modifies the <see cref="loopsTotal"/> so that the sequence will complete after the number of <see cref="loops"/>.<br/>
    /// To set the initial number of loops, use W_Sequence.Create(loops: numloops) instead.<br/><br/>
    /// Setting loops to -1 will repeat the sequence indefinitely.<br/>
    /// </summary>
    public void SetRemainingLoops(int loops)
    {
        root.SetRemainingLoops(loops);
    }

    public bool isPaused
    {
        get => root.IsPaused;
        set => root.IsPaused = value;
    }

    internal SequenceDirectEnumerator getSelfChildren(bool isForward = true) => new SequenceDirectEnumerator(this, isForward);
    internal SequenceChildrenEnumerator getAllTweens() => new SequenceChildrenEnumerator(this);

    public override string ToString() => root.ToString();

    internal struct SequenceDirectEnumerator
    {
        readonly W_Sequence sequence;
        W_Tween current;
        readonly bool isEmpty;
        readonly bool isForward;
        bool isStarted;

        internal SequenceDirectEnumerator(W_Sequence s, bool isForward)
        {
            Assert.IsTrue(s.isAlive, s.id);
            sequence = s;
            this.isForward = isForward;
            isStarted = false;
            isEmpty = isSequenceEmpty(s);
            if(isEmpty)
            {
                current = default;
                return;
            }
            current = sequence.root.tween.next;
            Assert.IsTrue(current.IsCreated && current.Id != sequence.root.tween.nextSibling.Id);
            if(!isForward)
            {
                while(true)
                {
                    var next = current.tween.nextSibling;
                    if(!next.IsCreated)
                    {
                        break;
                    }
                    current = next;
                }
            }
            Assert.IsTrue(current.IsCreated);
        }

        static bool isSequenceEmpty(W_Sequence s)
        {
            // tests: SequenceNestingDifferentSettings(), TestSequenceEnumeratorWithEmptySequences()
            return s.root.tween.intParam == emptySequenceTag;
        }

        public readonly SequenceDirectEnumerator GetEnumerator()
        {
            Assert.IsTrue(sequence.isAlive);
            return this;
        }

        public readonly W_Tween Current
        {
            get
            {
                Assert.IsTrue(sequence.isAlive);
                Assert.IsTrue(current.IsCreated);
                Assert.IsNotNull(current.tween);
                Assert.AreEqual(current.Id, current.tween.id);
                Assert.IsTrue(current.tween.sequence.IsCreated);
                return current;
            }
        }

        public bool MoveNext()
        {
            if(isEmpty)
            {
                return false;
            }
            Assert.IsTrue(current.IsAlive);
            if(!isStarted)
            {
                isStarted = true;
                return true;
            }
            current = isForward ? current.tween.nextSibling : current.tween.prevSibling;
            return current.IsCreated;
        }
    }

    internal struct SequenceChildrenEnumerator
    {
        readonly W_Sequence sequence;
        W_Tween current;
        bool isStarted;

        internal SequenceChildrenEnumerator(W_Sequence s)
        {
            Assert.IsTrue(s.isAlive);
            Assert.IsTrue(s.root.tween.IsMainSequenceRoot());
            sequence = s;
            current = default;
            isStarted = false;
        }

        public readonly SequenceChildrenEnumerator GetEnumerator()
        {
            Assert.IsTrue(sequence.isAlive);
            return this;
        }

        public            readonly            W_Tween Current
        {
            get
            {
                Assert.IsTrue(current.IsCreated);
                Assert.IsNotNull(current.tween);
                Assert.AreEqual(current.Id, current.tween.id);
                Assert.IsTrue(current.tween.sequence.IsCreated);
                return current;
            }
        }

        public bool MoveNext()
        {
            if(!isStarted)
            {
                Assert.IsFalse(current.IsCreated);
                current = sequence.root;
                isStarted = true;
                return true;
            }
            Assert.IsTrue(current.IsAlive);
            current = current.tween.next;
            return current.IsCreated;
        }
    }

    /// <summary>Places <paramref name="sequence"/> after all previously added animations in this sequence. Chained animations run sequentially after one another.</summary>
    public W_Sequence Chain(W_Sequence sequence)
    {
        if(tryManipulate())
        {
            Insert(duration, sequence);
        }
        return this;
    }

    /// <summary>Groups <paramref name="sequence"/> with the 'previous' animation in this W_Sequence.<br/>
    /// The 'previous' animation is the animation used in the preceding Group/Chain/Insert() method call.<br/>
    /// Grouped animations start at the same time and run in parallel.</summary>
    public W_Sequence Group(W_Sequence sequence)
    {
        if(tryManipulate())
        {
            Insert(getLastInSelfOrRoot().tween.waitDelay, sequence);
        }
        return this;
    }

    /// <summary>Places <paramref name="sequence"/> inside this W_Sequence at time <paramref name="atTime"/>, overlapping with other animations.<br/>
    /// The total sequence Duration is increased if the inserted <paramref name="sequence"/> doesn't fit inside the current sequence Duration.</summary>
    public W_Sequence Insert(float atTime, W_Sequence sequence)
    {
        if(!ValidateCanAdd(sequence.root))
        {
            return this;
        }

        ref var otherTweenType = ref sequence.root.tween.tweenType;
        if(otherTweenType != TweenType.MainSequence)
        {
            return this;
        }
        otherTweenType = TweenType.NestedSequence;

        Insert_internal(atTime, sequence.root);
        validateSequenceEnumerator();
        return this;
    }

    /// <summary>Custom timeScale. To smoothly Animate timeScale over time, use <see cref="W_Tween.TweenTimeScale"/> method.</summary>
    public float timeScale
    {
        get => root.TimeScale;
        set => root.TimeScale = value;
    }

    [System.Diagnostics.Conditional("SAFETY_CHECKS")]
    void validateSequenceEnumerator()
    {
        var buffer = new List<ReusableTween> {
                root.tween
            };
        foreach(var t in getAllTweens())
        {
            // Debug.Log($"----- {t}");
            if(t.tween.IsSequenceRoot())
            {
                foreach(var ch in t.tween.sequence.getSelfChildren())
                {
                    // Debug.Log(ch);
                    buffer.Add(ch.tween);
                }
            }
        }
        if(buffer.Count != buffer.Select(_ => _.id).Distinct().Count())
        {
            Debug.LogError($"{root.Id}, duplicates in validateSequenceEnumerator():\n{string.Join("\n", buffer)}");
        }
    }

    public W_Sequence OnComplete(Action onComplete, bool warnIfTargetDestroyed = true)
    {
        root.OnComplete(onComplete, warnIfTargetDestroyed);
        return this;
    }

    public W_Sequence OnComplete<T>(T target, Action<T> onComplete, bool warnIfTargetDestroyed = true) where T : class
    {
        root.OnComplete(target, onComplete, warnIfTargetDestroyed);
        return this;
    }

    public override int GetHashCode() => root.GetHashCode();
    public bool Equals(W_Sequence other) => root.Equals(other.root);
}