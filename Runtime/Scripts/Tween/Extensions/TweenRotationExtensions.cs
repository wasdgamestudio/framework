using UnityEngine;

public static class TweenRotationExtensions
{   
    #region Rotation Additive
    public static W_Tween RotationAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
       => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween RotationAdditive<T>(T target, Vector3 deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween RotationAdditive<T>(T target, Vector3 deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.rotation *= Quaternion.Euler(delta));
    public static W_Tween RotationAdditive<T>(T target, Quaternion deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween RotationAdditive<T>(T target, Quaternion deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween RotationAdditive<T>(T target, Quaternion deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.rotation *= delta);
    #endregion
    #region Local Rotation Additive
    public static W_Tween LocalRotationAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
      => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween LocalRotationAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween LocalRotationAdditive<T>(this T target, Vector3 deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.localRotation *= Quaternion.Euler(delta));
    public static W_Tween LocalRotationAdditive<T>(this T target, Quaternion deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween LocalRotationAdditive<T>(this T target, Quaternion deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween LocalRotationAdditive<T>(this T target, Quaternion deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.localRotation *= delta);
    #endregion
    #region Rotation
    public static W_Tween Rotation<T>(this T target, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => Rotation(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Rotation(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => Rotation(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => Rotation(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Vector3 endValue, TweenSettings settings) where T : Component => Rotation(target, new TweenSettings<Vector3>(endValue, settings));
    public static W_Tween Rotation<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => Rotation(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween Rotation<T>(this T target, Quaternion endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
       => Rotation(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Quaternion endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Rotation(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Quaternion startValue, Quaternion endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Rotation(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Quaternion startValue, Quaternion endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Rotation(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Rotation<T>(this T target, Quaternion endValue, TweenSettings settings) where T : Component => Rotation(target, new TweenSettings<Quaternion>(endValue, settings));
    public static W_Tween Rotation<T>(this T target, Quaternion startValue, Quaternion endValue, TweenSettings settings) where T : Component => Rotation(target, new TweenSettings<Quaternion>(startValue, endValue, settings));
    public static W_Tween Rotation<T>(this T target, TweenSettings<Vector3> eulerAnglesSettings) where T : Component => Rotation(target, toQuaternion(eulerAnglesSettings));
    public static W_Tween Rotation<T>(this T target, TweenSettings<Quaternion> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.QuaternionVal;
            _target.rotation = val;
        }, t => (t.target as Component).transform.rotation.ToContainer(), TweenType.RotationQuaternion);
    }
    #endregion
    #region Local Rotation
    public static W_Tween LocalRotation<T>(this T target, Quaternion endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotation(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Quaternion endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotation(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Quaternion startValue, Quaternion endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotation(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Quaternion startValue, Quaternion endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotation(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Quaternion endValue, TweenSettings settings) where T : Component => LocalRotation(target, new TweenSettings<Quaternion>(endValue, settings));
    public static W_Tween LocalRotation<T>(this T target, Quaternion startValue, Quaternion endValue, TweenSettings settings) where T : Component => LocalRotation(target, new TweenSettings<Quaternion>(startValue, endValue, settings));
    public static W_Tween LocalRotation<T>(this T target, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => LocalRotation(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => LocalRotation(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => LocalRotation(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => LocalRotation(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotation<T>(this T target, Vector3 endValue, TweenSettings settings) where T : Component
    => LocalRotation(target, new TweenSettings<Vector3>(endValue, settings));
    public static W_Tween LocalRotation<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => LocalRotation(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween LocalRotation<T>(T target, TweenSettings<Vector3> localEulerAnglesSettings) where T : Component => LocalRotation(target, toQuaternion(localEulerAnglesSettings));
    public static W_Tween LocalRotation<T>(this T target, TweenSettings<Quaternion> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.QuaternionVal;
            _target.localRotation = val;
        }, t => (t.target as Component).transform.localRotation.ToContainer(), TweenType.LocalRotationQuaternion);
    }
    #endregion  
    #region Rotation At Speed
    public static W_Tween RotationAtSpeed<T>(this T target, Quaternion endValue, float averageAngularSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAtSpeed(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween RotationAtSpeed<T>(this T target, Quaternion endValue, float averageAngularSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAtSpeed(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween RotationAtSpeed<T>(this T target, Quaternion startValue, Quaternion endValue, float averageAngularSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAtSpeed(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween RotationAtSpeed<T>(this T target, Quaternion startValue, Quaternion endValue, float averageAngularSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => RotationAtSpeed(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween RotationAtSpeed<T>(this T target, TweenSettings<Quaternion> settings) where T : Component
    {
        var speed = settings.settings.Duration;
        if(speed <= 0)
        {
            Debug.LogError($"Invalid speed provided to the Tween.{nameof(RotationAtSpeed)}() method: {speed}.");
            return default;
        }
        if(settings.startFromCurrent)
        {
            settings.startFromCurrent = false;
            settings.startValue = target.transform.rotation;
        }
        settings.settings.Duration = TweenExtensions.CalcDistance(settings.startValue, settings.endValue) / speed;
        return Rotation(target, settings);
    }
    #endregion
    #region Local Rotation At Speed
    public static W_Tween LocalRotationAtSpeed<T>(this T target, Quaternion endValue, float averageAngularSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAtSpeed(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotationAtSpeed<T>(this T target, Quaternion endValue, float averageAngularSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAtSpeed(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotationAtSpeed<T>(this T target, Quaternion startValue, Quaternion endValue, float averageAngularSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAtSpeed(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotationAtSpeed<T>(this T target, Quaternion startValue, Quaternion endValue, float averageAngularSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalRotationAtSpeed(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(averageAngularSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalRotationAtSpeed<T>(this T target, TweenSettings<Quaternion> settings) where T : Component
    {
        var speed = settings.settings.Duration;
        if(speed <= 0)
        {
            Debug.LogError($"Invalid speed provided to the Tween.{nameof(LocalRotationAtSpeed)}() method: {speed}.");
            return default;
        }
        if(settings.startFromCurrent)
        {
            settings.startFromCurrent = false;
            settings.startValue = target.transform.localRotation;
        }
        settings.settings.Duration = TweenExtensions.CalcDistance(settings.startValue, settings.endValue) / speed;
        return LocalRotation(target, settings);
    }
    #endregion
    #region EulerAngles
    public static W_Tween EulerAngles<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
     => EulerAngles(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween EulerAngles<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => EulerAngles(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween EulerAngles<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => EulerAngles(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween EulerAngles<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        validateEulerAnglesData(ref settings);
        return TweenAnimateExtensions.Animate(target, ref settings, _ => { (_.target as Transform).eulerAngles = _.Vector3Val; }, _ => (_.target as Component).transform.eulerAngles.ToContainer(), TweenType.EulerAngles);
    }
    #endregion
    #region Local EulerAngles
    public static W_Tween LocalEulerAngles<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalEulerAngles(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalEulerAngles<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalEulerAngles(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalEulerAngles<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => LocalEulerAngles(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween LocalEulerAngles<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        validateEulerAnglesData(ref settings);
        return TweenAnimateExtensions.Animate(target, ref settings, _ => { (_.target as Transform).localEulerAngles = _.Vector3Val; }, _ => (_.target as Component).transform.localEulerAngles.ToContainer(), TweenType.LocalEulerAngles);
    }
    #endregion
    static void validateEulerAnglesData(ref TweenSettings<Vector3> settings)
    {
        if(settings.startFromCurrent)
        {
            settings.startFromCurrent = false;
            Debug.LogWarning("Animating euler angles from the current value may produce unexpected results because there is more than one way to represent the current rotation using Euler angles.\n" +
                             "'" + nameof(TweenSettings<float>.startFromCurrent) + "' was ignored.");
        }
    }
    static TweenSettings<Quaternion> toQuaternion(TweenSettings<Vector3> s) => new TweenSettings<Quaternion>(Quaternion.Euler(s.startValue), Quaternion.Euler(s.endValue), s.settings) { startFromCurrent = s.startFromCurrent };
    
}
