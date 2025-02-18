using System;
using UnityEngine;
using Random = UnityEngine.Random;

public partial struct W_Tween
{
    /// <summary>Shakes the camera.<br/>
    /// If the camera is perspective, shakes all angles.<br/>
    /// If the camera is orthographic, shakes the z angle and x/y coordinates.<br/>
    /// Reference strengthFactor values - light: 0.2, medium: 0.5, heavy: 1.0.</summary>
    public static W_Sequence ShakeCamera(Camera camera, float strengthFactor, float duration = 0.5f, float frequency = ShakeSettings.DefaultFrequency, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
    {
        var transform = camera.transform;
        if(camera.orthographic)
        {
            var orthoPosStrength = strengthFactor * camera.orthographicSize * 0.03f;
            return ShakeLocalPosition(transform, new ShakeSettings(new Vector3(orthoPosStrength, orthoPosStrength), duration, frequency, startDelay: startDelay, endDelay: endDelay, useUnscaledTime: useUnscaledTime))
                .Group(ShakeLocalRotation(transform, new ShakeSettings(new Vector3(0, 0, strengthFactor * 0.6f), duration, frequency, startDelay: startDelay, endDelay: endDelay, useUnscaledTime: useUnscaledTime)));
        }
        return W_Sequence.Create(ShakeLocalRotation(transform, new ShakeSettings(strengthFactor * Vector3.one, duration, frequency, startDelay: startDelay, endDelay: endDelay, useUnscaledTime: useUnscaledTime)));
    }

    public static W_Tween ShakeLocalPosition(Transform target, Vector3 strength, float duration, float frequency = ShakeSettings.DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1,
        float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
        => ShakeLocalPosition(target, new ShakeSettings(strength, duration, frequency, enableFalloff, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime));
    public static W_Tween ShakeLocalPosition(Transform target, ShakeSettings settings)
    {
        return shake(TweenType.ShakeLocalPosition, PropType.Vector3, target, settings, (state, shakeVal) =>
        {
            (state.target as Transform).localPosition = state.startValue.Vector3Val + shakeVal;
        }, _ => (_.target as Transform).localPosition.ToContainer());
    }
    public static W_Tween PunchLocalPosition(Transform target, Vector3 strength, float duration, float frequency = ShakeSettings.DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1,
        float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
        => PunchLocalPosition(target, new ShakeSettings(strength, duration, frequency, enableFalloff, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime));
    public static W_Tween PunchLocalPosition(Transform target, ShakeSettings settings) => ShakeLocalPosition(target, settings.WithPunch());

    public static W_Tween ShakeLocalRotation(Transform target, Vector3 strength, float duration, float frequency = ShakeSettings.DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1,
        float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
        => ShakeLocalRotation(target, new ShakeSettings(strength, duration, frequency, enableFalloff, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime));
    public static W_Tween ShakeLocalRotation(Transform target, ShakeSettings settings)
    {
        return shake(TweenType.ShakeLocalRotation, PropType.Quaternion, target, settings, (state, shakeVal) =>
        {
            (state.target as Transform).localRotation = state.startValue.QuaternionVal * Quaternion.Euler(shakeVal);
        }, t => (t.target as Transform).localRotation.ToContainer());
    }
    public static W_Tween PunchLocalRotation(Transform target, Vector3 strength, float duration, float frequency = ShakeSettings.DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1,
        float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
        => PunchLocalRotation(target, new ShakeSettings(strength, duration, frequency, enableFalloff, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime));
    public static W_Tween PunchLocalRotation(Transform target, ShakeSettings settings) => ShakeLocalRotation(target, settings.WithPunch());

    public static W_Tween ShakeScale(Transform target, Vector3 strength, float duration, float frequency = ShakeSettings.DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1,
        float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
        => ShakeScale(target, new ShakeSettings(strength, duration, frequency, enableFalloff, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime));
    public static W_Tween ShakeScale(Transform target, ShakeSettings settings)
    {
        return shake(TweenType.ShakeScale, PropType.Vector3, target, settings, (state, shakeVal) =>
        {
            (state.target as Transform).localScale = state.startValue.Vector3Val + shakeVal;
        }, t => (t.target as Transform).localScale.ToContainer());
    }
    public static W_Tween PunchScale(Transform target, Vector3 strength, float duration, float frequency = ShakeSettings.DefaultFrequency, bool enableFalloff = true, W_Ease easeBetweenShakes = W_Ease.Default, float asymmetryFactor = 0f, int loops = 1,
        float startDelay = 0, float endDelay = 0, bool useUnscaledTime = TweenConfig.DefaultUseUnscaledTimeForShakes)
        => PunchScale(target, new ShakeSettings(strength, duration, frequency, enableFalloff, easeBetweenShakes, asymmetryFactor, loops, startDelay, endDelay, useUnscaledTime));
    public static W_Tween PunchScale(Transform target, ShakeSettings settings) => ShakeScale(target, settings.WithPunch());

    static W_Tween shake(TweenType tweenType, PropType propType, Transform target, ShakeSettings settings, Action<ReusableTween, Vector3> onValueChange, Func<ReusableTween, ValueContainer> getter)
    {
        Assert.IsNotNull(onValueChange);
        Assert.IsNotNull(getter);
        var tween = TweenManager.FetchTween();
        tween.setPropType(propType);
        prepareShakeData(settings, tween);
        tween.customOnValueChange = onValueChange;
        var tweenSettings = settings.tweenSettings;
        tween.Setup(target, ref tweenSettings, state =>
        {
            var _onValueChange = state.customOnValueChange as Action<ReusableTween, Vector3>;
            Assert.IsNotNull(_onValueChange);
            var shakeVal = getShakeVal(state);
            _onValueChange(state, shakeVal);
        }, getter, true, tweenType);
        return TweenManager.Animate(tween);
    }

    public static W_Tween ShakeCustom<T>(T target, Vector3 startValue, ShakeSettings settings, Action<T, Vector3> onValueChange) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.setPropType(PropType.Vector3);
        tween.startValue.CopyFrom(ref startValue);
        prepareShakeData(settings, tween);
        tween.customOnValueChange = onValueChange;
        var tweenSettings = settings.tweenSettings;
        tween.Setup(target, ref tweenSettings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Vector3>;
            Assert.IsNotNull(_onValueChange);
            var _target = _tween.target as T;
            var val = _tween.startValue.Vector3Val + getShakeVal(_tween);
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Debug.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}", _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.ShakeCustom);
        return TweenManager.Animate(tween);
    }
    public static W_Tween PunchCustom<T>(T target, Vector3 startValue, ShakeSettings settings, Action<T, Vector3> onValueChange) where T : class => ShakeCustom(target, startValue, settings.WithPunch(), onValueChange);

    static void prepareShakeData(ShakeSettings settings, ReusableTween tween)
    {
        tween.endValue.Reset(); // not used
        tween.shakeData.Setup(settings);
    }

    static Vector3 getShakeVal(ReusableTween tween)
    {
        return tween.shakeData.getNextVal(tween) * calcFadeInOutFactor();
        float calcFadeInOutFactor()
        {
            var elapsedTimeInterpolating = tween.easedInterpolationFactor * tween.settings.Duration;
            Assert.IsTrue(elapsedTimeInterpolating >= 0f);
            var duration = tween.settings.Duration;
            if(duration == 0f)
            {
                return 0f;
            }
            Assert.IsTrue(duration > 0f);
            float halfDuration = duration * 0.5f;
            var oneShakeDuration = 1f / tween.shakeData.frequency;
            if(oneShakeDuration > halfDuration)
            {
                oneShakeDuration = halfDuration;
            }
            float fadeInDuration = oneShakeDuration * 0.5f;
            if(elapsedTimeInterpolating < fadeInDuration)
            {
                return Mathf.InverseLerp(0f, fadeInDuration, elapsedTimeInterpolating);
            }
            var fadeoutStartTime = duration - oneShakeDuration;
            Assert.IsTrue(fadeoutStartTime > 0f, tween.id);
            if(elapsedTimeInterpolating > fadeoutStartTime)
            {
                return Mathf.InverseLerp(duration, fadeoutStartTime, elapsedTimeInterpolating);
            }
            return 1f;
        }
    }
}

internal struct ShakeData
{
    float t;
    bool sign;
    Vector3 from, to;
    float symmetryFactor;
    int falloffEaseInt;
    AnimationCurve customStrengthOverTime;
    W_Ease easeBetweenShakes;
    bool isPunch;
    const int disabledFalloff = -42;
    internal bool isAlive => frequency != 0f;
    internal Vector3 strengthPerAxis { get; private set; }
    internal float frequency { get; private set; }
    float prevInterpolationFactor;
    int prevloopsDone;

    internal void Setup(ShakeSettings settings)
    {
        isPunch = settings.IsPunch;
        symmetryFactor = Mathf.Clamp01(1 - settings.Asymmetry);
        {
            var _strength = settings.Strength;
            if(_strength == Vector3.zero)
            {
                Debug.LogError("Shake's strength is (0, 0, 0).");
            }
            strengthPerAxis = _strength;
        }
        {
            var _frequency = settings.Frequency;
            if(_frequency <= 0)
            {
                Debug.LogError($"Shake's frequency should be > 0f, but was {_frequency}.");
                _frequency = ShakeSettings.DefaultFrequency;
            }
            frequency = _frequency;
        }
        {
            if(settings.EnableFalloff)
            {
                var _falloffEase = settings.FalloffEase;
                var _customStrengthOverTime = settings.StrengthOverTime;
                if(_falloffEase == W_Ease.Default)
                {
                    _falloffEase = W_Ease.Linear;
                }
                if(_falloffEase == W_Ease.Custom)
                {
                    if(_customStrengthOverTime == null || !TweenSettings.ValidateCustomCurve(_customStrengthOverTime))
                    {
                        Debug.LogError($"Shake falloff is Ease.Custom, but {nameof(ShakeSettings.StrengthOverTime)} is not configured correctly. Using Ease.Linear instead.");
                        _falloffEase = W_Ease.Linear;
                    }
                }
                falloffEaseInt = (int)_falloffEase;
                customStrengthOverTime = _customStrengthOverTime;
            }
            else
            {
                falloffEaseInt = disabledFalloff;
            }
        }
        {
            var _easeBetweenShakes = settings.EaseBetweenShakes;
            if(_easeBetweenShakes == W_Ease.Custom)
            {
                Debug.LogError($"{nameof(ShakeSettings.EaseBetweenShakes)} doesn't support Ease.Custom.");
                _easeBetweenShakes = W_Ease.OutQuad;
            }
            if(_easeBetweenShakes == W_Ease.Default)
            {
                _easeBetweenShakes = TweenManager.defaultShakeEase;
            }
            easeBetweenShakes = _easeBetweenShakes;
        }
        onCycleComplete();
    }

    internal void onCycleComplete()
    {
        Assert.IsTrue(isAlive);
        resetAfterCycle();
        sign = isPunch || Random.value < 0.5f;
        to = generateShakePoint();
    }

    static int getMainAxisIndex(Vector3 strengthByAxis)
    {
        int mainAxisIndex = -1;
        float maxStrength = float.NegativeInfinity;
        for(int i = 0; i < 3; i++)
        {
            var strength = Mathf.Abs(strengthByAxis[i]);
            if(strength > maxStrength)
            {
                maxStrength = strength;
                mainAxisIndex = i;
            }
        }
        Assert.IsTrue(mainAxisIndex >= 0);
        return mainAxisIndex;
    }

    internal Vector3 getNextVal(ReusableTween tween)
    {
        var interpolationFactor = tween.easedInterpolationFactor;
        Assert.IsTrue(interpolationFactor <= 1);

        int loopsDiff = tween.GetLoopsDone() - prevloopsDone;
        prevloopsDone = tween.GetLoopsDone();
        if(interpolationFactor == 0f || (loopsDiff > 0 && tween.GetLoopsDone() != tween.settings.loops))
        {
            onCycleComplete();
            prevInterpolationFactor = interpolationFactor;
        }

        var dt = (interpolationFactor - prevInterpolationFactor) * tween.settings.Duration;
        prevInterpolationFactor = interpolationFactor;

        var strengthOverTime = calcStrengthOverTime(interpolationFactor);
        var frequencyFactor = Mathf.Clamp01(strengthOverTime * 3f); // handpicked formula that describes the relationship between Strength and Frequency
        float getIniVelFactor()
        {
            // The initial velocity should twice as big because the first shake starts from zero (twice as short as total range).
            var elapsedTimeInterpolating = tween.easedInterpolationFactor * tween.settings.Duration;
            var halfShakeDuration = 0.5f / tween.shakeData.frequency;
            return elapsedTimeInterpolating < halfShakeDuration ? 2f : 1f;
        }
        t += frequency * dt * frequencyFactor * getIniVelFactor();
        if(t < 0f || t >= 1f)
        {
            sign = !sign;
            if(t < 0f)
            {
                t = 1f;
                to = from;
                from = generateShakePoint();
            }
            else
            {
                t = 0f;
                from = to;
                to = generateShakePoint();
            }
        }

        Vector3 result = default;
        for(int i = 0; i < 3; i++)
        {
            result[i] = Mathf.Lerp(from[i], to[i], StandardEasing.Evaluate(t, easeBetweenShakes)) * strengthOverTime;
        }
        return result;
    }

    Vector3 generateShakePoint()
    {
        var mainAxisIndex = getMainAxisIndex(strengthPerAxis);
        Vector3 result = default;
        float signFloat = sign ? 1f : -1f;
        for(int i = 0; i < 3; i++)
        {
            var strength = strengthPerAxis[i];
            if(isPunch)
            {
                result[i] = clampBySymmetryFactor(strength * signFloat, strength, symmetryFactor);
            }
            else
            {
                result[i] = i == mainAxisIndex ? calcMainAxisEndVal(signFloat, strength, symmetryFactor) : calcNonMainAxisEndVal(strength, symmetryFactor);
            }
        }
        return result;
    }

    float calcStrengthOverTime(float interpolationFactor)
    {
        if(falloffEaseInt == disabledFalloff)
        {
            return 1;
        }
        var falloffEase = (W_Ease)falloffEaseInt;
        if(falloffEase != W_Ease.Custom)
        {
            return 1 - StandardEasing.Evaluate(interpolationFactor, falloffEase);
        }
        Assert.IsNotNull(customStrengthOverTime);
        return customStrengthOverTime.Evaluate(interpolationFactor);
    }

    static float calcMainAxisEndVal(float velocity, float strength, float symmetryFactor)
    {
        var result = Mathf.Sign(velocity) * strength * Random.Range(0.6f, 1f); // doesn't matter if we're using Strength or its abs because velocity alternates
        return clampBySymmetryFactor(result, strength, symmetryFactor);
    }

    static float clampBySymmetryFactor(float val, float strength, float symmetryFactor)
    {
        if(strength > 0)
        {
            return Mathf.Clamp(val, -strength * symmetryFactor, strength);
        }
        return Mathf.Clamp(val, strength, -strength * symmetryFactor);
    }

    static float calcNonMainAxisEndVal(float strength, float symmetryFactor)
    {
        if(strength > 0)
        {
            return Random.Range(-strength * symmetryFactor, strength);
        }
        return Random.Range(strength, -strength * symmetryFactor);
    }

    internal static bool TryTakeStartValueFromOtherShake(ReusableTween newTween)
    {
        if(!newTween.shakeData.isAlive)
        {
            return false;
        }
        var shakeTransform = newTween.target as Transform;
        if(shakeTransform == null)
        {
            return false;
        }
        var shakes = TweenManager.Instance.shakes;
        var key = (shakeTransform, newTween.tweenType);
        if(!shakes.TryGetValue(key, out var data))
        {
            shakes.Add(key, (newTween.getter(newTween), 1));
            return false;
        }
        Assert.IsTrue(data.count >= 1);
        newTween.startValue = data.startValue;
        // Debug.Log($"tryTakeStartValueFromOtherShake {data.startValue.Vector4Val}");
        data.count++;
        shakes[key] = data;
        return true;
    }

    internal void Reset(ReusableTween tween)
    {
        Assert.IsTrue(isAlive);
        var shakeTransform = tween.target as Transform;
        if(shakeTransform != null)
        {
            var key = (shakeTransform, tween.tweenType);
            var shakes = TweenManager.Instance.shakes;
            if(shakes.TryGetValue(key, out var data))
            {
                // no key present if it's a ShakeCustom() with Transform target because custom shakes have startFromCurrent == false and aren't added to shakes dict
                Assert.IsTrue(data.count >= 1);
                data.count--;
                if(data.count == 0)
                {
                    bool isRemoved = shakes.Remove(key);
                    Assert.IsTrue(isRemoved);
                }
                else
                {
                    shakes[key] = data;
                }
            }
        }

        resetAfterCycle();
        customStrengthOverTime = null;
        frequency = 0f;
        prevInterpolationFactor = 0f;
        prevloopsDone = 0;
        Assert.IsFalse(isAlive);
    }

    void resetAfterCycle()
    {
        t = 0f;
        from = Vector3.zero;
    }
}