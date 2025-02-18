using System;
using UnityEngine;

[Serializable]
public struct TweenSettings<T> where T : struct
{
    public bool startFromCurrent;
    public T startValue;
    public T endValue;
    public TweenSettings settings;

    public TweenSettings(T endValue, TweenSettings settings)
    {
        startFromCurrent = true;
        startValue = default;
        this.endValue = endValue;
        this.settings = settings;
    }

    public TweenSettings(T startValue, T endValue, TweenSettings settings)
    {
        startFromCurrent = false;
        this.startValue = startValue;
        this.endValue = endValue;
        this.settings = settings;
    }

    public TweenSettings(T endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
        : this(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate))
    {
    }

    public TweenSettings(T startValue, T endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
        : this(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate))
    {
    }
    public TweenSettings(T endValue, float duration, W_Easing customEase, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
        : this(endValue, new TweenSettings(duration, customEase, loops, loopMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate))
    {
    }

    public TweenSettings(T startValue, T endValue, float duration, W_Easing customEase, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
        : this(startValue, endValue, new TweenSettings(duration, customEase, loops, loopMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate))
    {
    }

    public readonly TweenSettings<T> WithDirection(bool toEndValue, bool _startFromCurrent = true)
    {
        if(startFromCurrent)
        {
            Debug.LogWarning(nameof(startFromCurrent) + " is already enabled on this TweenSettings. The " + nameof(WithDirection) + "() should be called on the TweenSettings once to choose the direction.");
        }
        var result = this;
        result.startFromCurrent = _startFromCurrent;
        if(toEndValue)
        {
            return result;
        }
        (result.startValue, result.endValue) = (result.endValue, result.startValue);
        return result;
    }

    public readonly TweenSettings<T> WithDirection(bool toEndValue, T currentValue)
    {
        var result = this;
        if(result.startFromCurrent)
        {
            result.startFromCurrent = false;
        }
        result.startValue = currentValue;
        result.endValue = toEndValue ? endValue : startValue;
        return result;
    }
}