using System;
using UnityEngine;

public partial struct W_Tween
{
    /// <summary>Returns the number of alive tweens.</summary>
    /// <param name="onTarget">If specified, returns the number of running tweens on the target. Please note: if target is specified, this method call has O(n) complexity where n is the total number of running tweens.</param>
    public static int GetTweensCount(object onTarget = null)
    {
        var manager = TweenManager.Instance;
        if(onTarget == null && manager.updateDepth == 0)
        {
            int result = manager.tweensCount;
            Assert.AreEqual(result, TweenManager.ProcessAll(null, _ => true, true));
            return result;
        }
        return TweenManager.ProcessAll(onTarget, _ => true, true); // call processAll to filter null tweens
    }

    public static int GetTweensCapacity()
    {
        var instance = TweenConfig.Instance;
        if(instance == null)
        {
            return TweenManager.customInitialCapacity;
        }
        return instance.currentPoolCapacity;
    }

    /// <summary>Stops all tweens and sequences.<br/>
    /// If <see cref="onTarget"/> is provided, stops only tweens on this target (stopping a tween inside a W_Sequence is not allowed).</summary>
    /// <returns>The number of stopped tweens.</returns>
    public static int StopAll(object onTarget = null)
    {
        var result = TweenManager.ProcessAll(onTarget, tween =>
        {
            if(tween.IsInSequence())
            {
                if(tween.IsMainSequenceRoot())
                {
                    tween.sequence.Stop();
                }
                // do nothing with nested tween or sequence. The main sequence root will process it
            }
            else
            {
                tween.Kill();
            }
            return true;
        }, false);
        forceUpdateManagerIfTargetIsNull(onTarget);
        return result;
    }

    /// <summary>Completes all tweens and sequences.<br/>
    /// If <see cref="onTarget"/> is provided, completes only tweens on this target (completing a tween inside a W_Sequence is not allowed).</summary>
    /// <returns>The number of completed tweens.</returns>
    public static int CompleteAll(object onTarget = null)
    {
        var result = TweenManager.ProcessAll(onTarget, tween =>
        {
            if(tween.IsInSequence())
            {
                if(tween.IsMainSequenceRoot())
                {
                    tween.sequence.Complete();
                }
                // do nothing with nested tween or sequence. The main sequence root will process it
            }
            else
            {
                tween.ForceComplete();
            }
            return true;
        }, false);
        forceUpdateManagerIfTargetIsNull(onTarget);
        return result;
    }

    static void forceUpdateManagerIfTargetIsNull(object onTarget)
    {
        if(onTarget == null)
        {
            var manager = TweenManager.Instance;
            if(manager != null)
            {
                if(manager.updateDepth == 0)
                {
                    manager.OnFixedUpdate();
                    manager.OnUpdate();
                }
                // Assert.AreEqual(0, manager.tweens.Count); // fails if user's OnComplete() creates new tweens
            }
        }
    }

    /// <summary>Pauses/unpauses all tweens and sequences.<br/>
    /// If <see cref="onTarget"/> is provided, pauses/unpauses only tweens on this target (pausing/unpausing a tween inside a W_Sequence is not allowed).</summary>
    /// <returns>The number of paused/unpaused tweens.</returns>
    public static int SetPausedAll(bool isPaused, object onTarget = null)
    {
        if(isPaused)
        {
            return TweenManager.ProcessAll(onTarget, tween =>
            {
                return tween.TrySetPause(true);
            }, false);
        }
        return TweenManager.ProcessAll(onTarget, tween =>
        {
            return tween.TrySetPause(false);
        }, false);
    }

    /// <summary>Please note: delay may outlive the caller (the calling UnityEngine.Object may already be destroyed).
    /// When using this overload, it's user's responsibility to ensure that <see cref="onComplete"/> is safe to execute once the delay is finished.
    /// It's preferable to use the <see cref="Delay{T}"/> overload because it checks if the UnityEngine.Object target is still alive before calling the <see cref="onComplete"/>.</summary>
    /// <param name="warnIfTargetDestroyed"></param>
    public static W_Tween Delay(float duration, Action onComplete = null, bool useUnscaledTime = false, bool warnIfTargetDestroyed = true)
    {
        return delay(TweenManager.dummyTarget, duration, onComplete, useUnscaledTime, warnIfTargetDestroyed);
    }
    /// <param name="warnIfTargetDestroyed"></param>
    public static W_Tween Delay(object target, float duration, Action onComplete = null, bool useUnscaledTime = false, bool warnIfTargetDestroyed = true)
    {
        return delay(target, duration, onComplete, useUnscaledTime, warnIfTargetDestroyed);
    }
    static W_Tween delay(object target, float duration, Action onComplete, bool useUnscaledTime, bool warnIfTargetDestroyed)
    {
        var result = delayInternal(target, duration, useUnscaledTime);
        if(onComplete != null)
        {
            result?.tween.OnComplete(onComplete, warnIfTargetDestroyed);
        }
        return result ?? default;
    }
   
    public static W_Tween Delay<T>(T target, float duration, Action<T> onComplete, bool useUnscaledTime = false, bool warnIfTargetDestroyed = true) where T : class
    {
        var maybeDelay = delayInternal(target, duration, useUnscaledTime);
        if(!maybeDelay.HasValue)
        {
            return default;
        }
        var delay = maybeDelay.Value;
        delay.tween.OnComplete(target, onComplete, warnIfTargetDestroyed);
        return delay;
    }

    static W_Tween? delayInternal(object target, float duration, bool useUnscaledTime)
    {
        return TweenManager.DelayWithoutDurationCheck(target, duration, useUnscaledTime);
    }   
   
}