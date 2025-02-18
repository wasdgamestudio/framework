using System;
using UnityEngine;

/// <summary>TweenSettings contains animation properties (Duration, ease, delay, etc.). Can be serialized and tweaked from the Inspector.<br/>
/// Use this struct when the 'start' and 'end' values of an animation are NOT known in advance and determined at runtime.<br/>
/// When the 'start' and 'end' values ARE known, consider using <see cref="TweenSettings{T}"/> instead.</summary>
/// <example>
/// Tweak an animation settings from the Inspector, then pass the settings to the W_Tween method:
/// <code>
/// [SerializeField] TweenSettings animationSettings;
/// public void AnimatePositionX(float targetPosX) {
///     W_Tween.PositionX(transform, targetPosX, animationSettings);
/// }
/// </code>
/// </example>
[Serializable]
public struct TweenSettings
{
    public float Duration;
    [Tooltip("The easing curve of an animation.\n\n" +
             "Default is Ease." + nameof(W_Ease.OutQuad) + ". The Default ease can be modified via '" + nameof(TweenConfig) + "." + nameof(TweenConfig.DefaultEase) + "' setting.\n\n" +
             "Set to " + nameof(W_Ease) + "." + nameof(W_Ease.Custom) + " to control the easing with custom " + nameof(AnimationCurve) + ".")]
    public W_Ease EaseType;
    [Tooltip("A custom Animation Curve that will work as an easing curve.")]
    [ShowIf(nameof(isCustomEase))]
    public AnimationCurve customEase;
    public int loops;
    [Tooltip("See the documentation of each cycle mode by hoovering the dropdown.")]
    public W_LoopMode loopMode;
    public float startDelay;
    public float endDelay;
    public bool useUnscaledTime;
    public bool UseFixedUpdate;
    [NonSerialized] internal ParametricEase parametricEase;
    [NonSerialized] internal float parametricEaseStrength;
    [NonSerialized] internal float parametricEasePeriod;

    internal const float minDuration = 0.0001f;
    bool isCustomEase() => EaseType == W_Ease.Custom;
    internal TweenSettings(float duration, W_Ease ease, W_Easing? customEasing, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
    {
        this.Duration = duration;
        var curve = customEasing?.curve;
        if(ease == W_Ease.Custom && customEasing?.parametricEase == ParametricEase.None)
        {
            if(curve == null || !ValidateCustomCurveKeyframes(curve))
            {
                Debug.LogError("Ease is Ease.Custom, but AnimationCurve is not configured correctly. Using Ease.Default instead.");
                ease = W_Ease.Default;
            }
        }
        this.EaseType = ease;
        customEase = ease == W_Ease.Custom ? curve : null;
        this.loops = loops;
        this.loopMode = loopMode;
        this.startDelay = startDelay;
        this.endDelay = endDelay;
        this.useUnscaledTime = useUnscaledTime;
        parametricEase = customEasing?.parametricEase ?? ParametricEase.None;
        parametricEaseStrength = customEasing?.parametricEaseStrength ?? float.NaN;
        parametricEasePeriod = customEasing?.parametricEasePeriod ?? float.NaN;
        this.UseFixedUpdate = useFixedUpdate;
    }

    public TweenSettings(float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
        : this(duration, ease, null, loops, loopMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate)
    {
    }

    public TweenSettings(float duration, W_Easing easing, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false, bool useFixedUpdate = false)
        : this(duration, easing.ease, easing, loops, loopMode, startDelay, endDelay, useUnscaledTime, useFixedUpdate) { }

    internal static void SetLoopsTo1If0(ref int loops)
    {
        if(loops == 0)
        {
            loops = 1;
        }
    }

    internal void CopyFrom(ref TweenSettings other)
    {
        Duration = other.Duration;
        EaseType = other.EaseType;
        customEase = other.customEase;
        loops = other.loops;
        loopMode = other.loopMode;
        startDelay = other.startDelay;
        endDelay = other.endDelay;
        useUnscaledTime = other.useUnscaledTime;
        parametricEase = other.parametricEase;
        parametricEaseStrength = other.parametricEaseStrength;
        parametricEasePeriod = other.parametricEasePeriod;
        UseFixedUpdate = other.UseFixedUpdate;
    }

    internal void SetValidValues()
    {
        SetLoopsTo1If0(ref loops);
        if(Duration != 0f)
        {
            Duration = Mathf.Max(minDuration, Duration);
        }
        startDelay = Mathf.Max(0f, startDelay);
        endDelay = Mathf.Max(0f, endDelay);
        if(loops == 1)
        {
            loopMode = W_LoopMode.Restart;
        }
    }

    internal static bool ValidateCustomCurve(AnimationCurve curve)
    {
        if(curve.length < 2)
        {
            Debug.LogError("Custom animation curve should have at least 2 keyframes, please edit the curve in Inspector.");
            return false;
        }
        return true;
    }

    internal static bool ValidateCustomCurveKeyframes(AnimationCurve curve)
    {
        if(!ValidateCustomCurve(curve))
        {
            return false;
        }
        var instance = TweenManager.Instance;
      
        return true;
    }
}

/// <summary>The standard animation easing types. Different easing curves produce a different animation 'feeling'.<br/>
/// Play around with different ease types to choose one that suites you the best.
/// You can also provide a custom AnimationCurve as an ease function or parametrize eases with the W_Easing.Overshoot/Elastic/BounceExact(...) methods.</summary>
public enum W_Ease
{
    Custom = -1, Default = 0, Linear = 1,
    InSine, OutSine, InOutSine,
    InQuad, OutQuad, InOutQuad,
    InCubic, OutCubic, InOutCubic,
    InQuart, OutQuart, InOutQuart,
    InQuint, OutQuint, InOutQuint,
    InExpo, OutExpo, InOutExpo,
    InCirc, OutCirc, InOutCirc,
    InElastic, OutElastic, InOutElastic,
    InBack, OutBack, InOutBack,
    InBounce, OutBounce, InOutBounce
}

/// <summary>Controls the behavior of subsequent Loops when a tween has more than one cycle.</summary>
public enum W_LoopMode
{
    [Tooltip("Restarts the tween from the beginning.")]
    Restart,
    [Tooltip("Animates forth and back, like a yoyo. Easing is the same on the backward cycle.")]
    Yoyo,
    [Tooltip("At the end of a cycle increments the `endValue` by the difference between `startValue` and `endValue`.\n\n" +
             "For example, if a tween moves position.x from 0 to 1, then after the first cycle, the tween will move the position.x from 1 to 2, and so on.")]
    Incremental,
    [Tooltip("Rewinds the tween as if time was reversed. Easing is reversed on the backward cycle.")]
    Rewind
}
