using System;
using UnityEngine;

/// <summary>
/// ShakeSettings contains all properties needed for a shake or punch (Frequency, Strength per axis, Duration, etc.). Can be serialized and tweaked from the Inspector.<br/>
/// Shake methods are: W_Tween.ShakeLocalPosition(), W_Tween.ShakeLocalRotation(), W_Tween.ShakeScale(), and W_Tween.ShakeCustom().<br/><br/>
/// Punch is a special case of a shake that a has a punch 'direction'. The punched value will oscillate back and forth in the direction of a punch.<br/>
/// Punch methods are: W_Tween.PunchLocalPosition(), W_Tween.PunchLocalRotation(), W_Tween.PunchScale(), and W_Tween.PunchCustom().<br/>
/// </summary>
[Serializable]
public struct ShakeSettings
{
    internal const float DefaultFrequency = 10;

    [Tooltip("Strength is applied per-axis in local space coordinates.\n\n" +
             "Shakes: the strongest strength component will be used as the main frequency axis. Shakes on secondary axes happen randomly instead of following the frequency.\n\n" +
             "Punches: strength determines punch direction.\n\n" +
             "Strength is measured in units (position/scale) or Euler angles (rotation).")]
    public Vector3 Strength;
    public float Duration;
    [Tooltip("Number of shakes per second.")]
    public float Frequency;
    [Tooltip("With enabled falloff shake starts at the highest strength and fades to the end.")]
    public bool EnableFalloff;
    [Tooltip("Falloff ease is inverted to achieve the effect of shake 'fading' over time. Typically, eases go from 0 to 1, but falloff ease goes from 1 to 0.\n\n" +
             "Default is Ease.Linear.\n\n" +
             "Set to " + nameof(W_Ease) + "." + nameof(W_Ease.Custom) + " to have manual control over shake's 'strength' over time.")]
    public W_Ease FalloffEase;
    [Tooltip("Shake's 'strength' over time.")]
    public AnimationCurve StrengthOverTime;
    [Tooltip("Represents how asymmetrical the shake is.\n\n" +
             "'0' means the shake is symmetrical around the initial value.\n\n" +
             "'1' means the shake is asymmetrical and will happen between the initial position and the value of the '" + nameof(Strength) + "' vector.\n\n" +
             "When used with punches, can be treated as the resistance to 'recoil': '0' is full recoil, '1' is no recoil.")]
    [Range(0f, 1f)] public float Asymmetry;
    /// <see cref="TweenManager.defaultShakeEase"/>
    [Tooltip("Ease between adjacent shake points.\n\n" +
             "Default is Ease.OutQuad.")]
    public W_Ease EaseBetweenShakes;
    public int Loops;
    public float StartDelay;
    public float EndDelay;
    public bool UseUnscaledTime;
    public bool UseFixedUpdate;
    internal bool IsPunch { get; private set; }

    internal ShakeSettings(Vector3 strength, float duration, float frequency, W_Ease? falloffEase, AnimationCurve strengthOverTime, W_Ease easeBetweenShakes, float asymmetryFactor, int loops, float startDelay, float endDelay, bool useUnscaledTime, bool useFixedUpdate)
    {
        this.Frequency = frequency;
        this.Strength = strength;
        this.Duration = duration;
        if(falloffEase == W_Ease.Custom)
        {
            if(strengthOverTime == null || !TweenSettings.ValidateCustomCurve(strengthOverTime))
            {
                Debug.LogError($"Shake falloff is Ease.Custom, but {nameof(this.StrengthOverTime)} is not configured correctly. Using Ease.Linear instead.");
                falloffEase = W_Ease.Linear;
            }
        }
        this.FalloffEase = falloffEase ?? default;
        this.StrengthOverTime = falloffEase == W_Ease.Custom ? strengthOverTime : null;
        EnableFalloff = falloffEase != null;
        this.EaseBetweenShakes = easeBetweenShakes;
        this.Loops = loops;
        this.StartDelay = startDelay;
        this.EndDelay = endDelay;
        this.UseUnscaledTime = useUnscaledTime;
        Asymmetry = asymmetryFactor;
        IsPunch = false;
        this.UseFixedUpdate = useFixedUpdate;
    }

    public ShakeSettings(Vector3 strength, float duration = 0.5f, float frequency = DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes, bool useFixedUpdate = false)
        // ReSharper disable once RedundantCast
        : this(strength, duration, frequency, enableFalloff ? W_Ease.Default : (W_Ease?)null, null, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime, useFixedUpdate) { }

    public ShakeSettings(Vector3 strength, float duration, float frequency, AnimationCurve strengthOverTime, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes, bool useFixedUpdate = false)
        : this(strength, duration, frequency, W_Ease.Custom, strengthOverTime, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime, useFixedUpdate) { }

    internal TweenSettings tweenSettings => new TweenSettings(Duration, W_Ease.Linear, Loops, W_LoopMode.Restart, StartDelay, EndDelay, UseUnscaledTime, UseFixedUpdate);

    internal readonly ShakeSettings WithPunch()
    {
        var result = this;
        result.IsPunch = true;
        return result;
    }
}