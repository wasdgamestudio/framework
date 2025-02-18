using UnityEngine;

/// <summary>
/// A wrapper struct that encapsulates three available easing methods: standard W_Ease, AnimationCurve, or Parametric W_Easing.<br/>
/// Use static methods to create an W_Easing struct, for example: W_Easing.Standard(W_Ease.OutBounce), W_Easing.Curve(animationCurve),
/// W_Easing.Elastic(Strength, period), etc.
/// </summary>
public readonly struct W_Easing
{
    internal readonly W_Ease ease;
    internal readonly AnimationCurve curve;
    internal readonly ParametricEase parametricEase;
    internal readonly float parametricEaseStrength;
    internal readonly float parametricEasePeriod;

    W_Easing(ParametricEase type, float strength, float period = float.NaN)
    {
        ease = W_Ease.Custom;
        curve = null;
        parametricEase = type;
        parametricEaseStrength = strength;
        parametricEasePeriod = period;
    }

    W_Easing(W_Ease ease,  AnimationCurve curve)
    {
        if(ease == W_Ease.Custom)
        {
            if(curve == null || !TweenSettings.ValidateCustomCurveKeyframes(curve))
            {
                Debug.LogError("Ease is Ease.Custom, but AnimationCurve is not configured correctly. Using Ease.Default instead.");
                ease = W_Ease.Default;
            }
        }
        this.ease = ease;
        this.curve = curve;
        parametricEase = ParametricEase.None;
        parametricEaseStrength = float.NaN;
        parametricEasePeriod = float.NaN;
    }

    public static implicit operator W_Easing(W_Ease ease) => Standard(ease);

    /// <summary>Standard Robert Penner's easing method. Or simply use W_Ease enum instead.</summary>
    public static W_Easing Standard(W_Ease ease)
    {
        Assert.AreNotEqual(W_Ease.Custom, ease);
        if(ease == W_Ease.Default)
        {
            ease = TweenConfig.DefaultEase;
        }
        return new W_Easing(ease, null);
    }

    public static implicit operator W_Easing( AnimationCurve curve) => Curve(curve);

    /// <summary>AnimationCurve to use as an easing function. Or simply use AnimationCurve instead.</summary>
    public static W_Easing Curve( AnimationCurve curve) => new W_Easing(W_Ease.Custom, curve);

    /// <summary>Customizes the bounce <see cref="strength"/> of W_Ease.OutBounce.</summary>
    public static W_Easing Bounce(float strength) => new W_Easing(ParametricEase.Bounce, strength);

    /// <summary>Customizes the exact <see cref="amplitude"/> of the first bounce in meters/angles.</summary>
    public static W_Easing BounceExact(float amplitude) => new W_Easing(ParametricEase.BounceExact, amplitude);

    /// <summary>Customizes the overshoot <see cref="strength"/> of W_Ease.OutBack.</summary>
    public static W_Easing Overshoot(float strength) => new W_Easing(ParametricEase.Overshoot, strength * StandardEasing.BackEaseConst);

    /// <summary>Customizes the <see cref="strength"/> and oscillation <see cref="period"/> of W_Ease.OutElastic.</summary>
    public static W_Easing Elastic(float strength, float period = StandardEasing.DefaultElasticEasePeriod)
    {
        if(strength < 1)
        {
            strength = Mathf.Lerp(0.2f, 1f, strength); // remap Strength to limit decayFactor
        }
        return new W_Easing(ParametricEase.Elastic, strength, Mathf.Max(0.1f, period));
    }

    internal static float Evaluate(float t, ParametricEase parametricEase, float strength, float period, float duration)
    {
        switch(parametricEase)
        {
            case ParametricEase.Overshoot:
                t -= 1.0f;
                return t * t * ((strength + 1) * t + strength) + 1.0f;
            case ParametricEase.Elastic:
                const float twoPi = 2 * Mathf.PI;
                float decayFactor;
                if(strength >= 1)
                {
                    decayFactor = 1f;
                }
                else
                {
                    decayFactor = 1 / strength;
                    strength = 1;
                }
                float decay = Mathf.Pow(2, -10f * t * decayFactor);
                if(duration == 0)
                {
                    return 1;
                }
                period /= duration;
                float phase = period / twoPi * Mathf.Asin(1f / strength);
                return t > 0.9999f ? 1 : strength * decay * Mathf.Sin((t - phase) * twoPi / period) + 1f;
            case ParametricEase.Bounce:
                return Bounce(t, strength);
            case ParametricEase.BounceExact:
            case ParametricEase.None:
            default:
                throw new System.Exception();
        }
    }

    internal static float Evaluate(float t,  ReusableTween tween)
    {
        var settings = tween.settings;
        var parametricEase = settings.parametricEase;
        var strength = settings.parametricEaseStrength;
        if(parametricEase == ParametricEase.BounceExact)
        {
            var fullAmplitude = tween.getPropType() == PropType.Quaternion ?
                Quaternion.Angle(tween.startValue.QuaternionVal, tween.endValue.QuaternionVal) :
                tween.diff.Vector4Val.magnitude;
            float strengthFactor = fullAmplitude < 0.0001f ? 1f : 1f / (fullAmplitude * (1f - firstBounceAmpl));
            return Bounce(t, strength * strengthFactor);
        }
        return Evaluate(t, parametricEase, strength, settings.parametricEasePeriod, settings.Duration);
    }

    const float firstBounceAmpl = 0.75f;
    static float Bounce(float t, float strength)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;
        if(t < 1 / d1)
        {
            return n1 * t * t;
        }
        return 1 - (1 - bounce()) * strength;
        float bounce()
        {
            if(t < 2 / d1)
            {
                return n1 * (t -= 1.5f / d1) * t + firstBounceAmpl;
            }
            if(t < 2.5 / d1)
            {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            }
            return n1 * (t -= 2.625f / d1) * t + 0.984375f;
        }
    }
    public static float Evaluate(float interpolationFactor, W_Ease ease)
    {
        switch(ease)
        {
            case W_Ease.Custom:
                Debug.LogError("Ease.Custom is an invalid type for Easing.Evaluate(). Please choose another Ease type instead.");
                return interpolationFactor;
            case W_Ease.Default:
                return StandardEasing.Evaluate(interpolationFactor, TweenManager.Instance.defaultEase);
            default:
                return StandardEasing.Evaluate(interpolationFactor, ease);
        }
    }
}

internal enum ParametricEase
{
    None = 0,
    Overshoot = 5,
    Bounce = 7,
    Elastic = 11,
    BounceExact
}