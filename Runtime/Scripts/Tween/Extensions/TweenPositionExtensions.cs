using System;
using UnityEngine;

public static class TweenPositionExtensions
{
    #region Position
    public static W_Tween Position<T>(this T target, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => Position(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Position<T>(this T target, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => Position(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Position<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component => Position(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Position<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Position(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Position<T>(this T target, Vector3 endValue, TweenSettings settings) where T : Component => Position(target, new TweenSettings<Vector3>(endValue, settings));
    public static W_Tween Position<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => Position(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween Position<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.Vector3Val;
            _target.position = val;
        }, t => (t.target as Component).transform.position.ToContainer(), TweenType.Position);
    }
    #endregion
    #region Position X
    public static W_Tween PositionX<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionX<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionX<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionX<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionX<T>(this T target, Single endValue, TweenSettings settings) where T : Component => PositionX(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween PositionX<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => PositionX(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween PositionX<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.position = _target.position.WithComponent(0, val);
        }, t => (t.target as Component).transform.position.x.ToContainer(), TweenType.PositionX);
    }
    #endregion
    #region Position Y
    public static W_Tween PositionY<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionY<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionY<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionY<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionY<T>(this T target, Single endValue, TweenSettings settings) where T : Component => PositionY(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween PositionY<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => PositionY(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween PositionY<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.position = _target.position.WithComponent(1, val);
        }, t => (t.target as Transform).transform.position.y.ToContainer(), TweenType.PositionY);
    }
    #endregion
    #region  Position Z
    public static W_Tween PositionZ<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionZ<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionZ<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionZ<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionZ<T>(this T target, Single endValue, TweenSettings settings) where T : Component => PositionZ(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween PositionZ<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => PositionZ(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween PositionZ<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.position = _target.position.WithComponent(2, val);
        }, t => (t.target as Transform).transform.position.z.ToContainer(), TweenType.PositionZ);
    }
    #endregion
    #region Local Position
    public static W_Tween LocalPosition<T>(this T target, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPosition(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPosition<T>(this T target, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPosition(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPosition<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPosition(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPosition<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPosition(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPosition<T>(this T target, Vector3 endValue, TweenSettings settings) where T : Component => LocalPosition(target, new TweenSettings<Vector3>(endValue, settings));
    public static W_Tween LocalPosition<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => LocalPosition(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween LocalPosition<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.Vector3Val;
            _target.localPosition = val;
        }, t => (t.target as Component).transform.localPosition.ToContainer(), TweenType.LocalPosition);
    }
    #endregion
    #region Local Position X
    public static W_Tween LocalPositionX<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionX<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionX<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionX<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionX<T>(this T target, Single endValue, TweenSettings settings) where T : Component => LocalPositionX(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween LocalPositionX<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => LocalPositionX(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween LocalPositionX<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.localPosition = _target.localPosition.WithComponent(0, val);
        }, t => (t.target as Component).transform.localPosition.x.ToContainer(), TweenType.LocalPositionX);
    }
    #endregion
    #region Local Position Y
    public static W_Tween LocalPositionY<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionY<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionY<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionY<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionY<T>(this T target, Single endValue, TweenSettings settings) where T : Component => LocalPositionY(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween LocalPositionY<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => LocalPositionY(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween LocalPositionY<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.localPosition = _target.localPosition.WithComponent(1, val);
        }, t => (t.target as Component).transform.localPosition.y.ToContainer(), TweenType.LocalPositionY);
    }
    #endregion
    #region Local Position Z
    public static W_Tween LocalPositionZ<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionZ<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionZ<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionZ<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionZ<T>(this T target, Single endValue, TweenSettings settings) where T : Component => LocalPositionZ(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween LocalPositionZ<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => LocalPositionZ(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween LocalPositionZ<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.localPosition = _target.localPosition.WithComponent(2, val);
        }, t => (t.target as Component).transform.localPosition.z.ToContainer(), TweenType.LocalPositionZ);
    }
    #endregion
    #region Position At Speed
    public static W_Tween PositionAtSpeed<T>(this T target, Vector3 endValue, float averageSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionAtSpeed(target, new TweenSettings<Vector3>(endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionAtSpeed<T>(this T target, Vector3 endValue, float averageSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionAtSpeed(target, new TweenSettings<Vector3>(endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionAtSpeed<T>(this T target, Vector3 startValue, Vector3 endValue, float averageSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionAtSpeed(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionAtSpeed<T>(this T target, Vector3 startValue, Vector3 endValue, float averageSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionAtSpeed(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween PositionAtSpeed<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        var speed = settings.settings.Duration;
        if(speed <= 0)
        {
            Debug.LogError($"Invalid speed provided to the Tween.{nameof(PositionAtSpeed)}() method: {speed}.");
            return default;
        }
        if(settings.startFromCurrent)
        {
            settings.startFromCurrent = false;
            settings.startValue = target.transform.position;
        }
        settings.settings.Duration = TweenExtensions.CalcDistance(settings.startValue, settings.endValue) / speed;
        return Position(target, settings);
    }
    #endregion
    #region Local Position At Speed
    public static W_Tween LocalPositionAtSpeed<T>(this T target, Vector3 endValue, float averageSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionAtSpeed(target, new TweenSettings<Vector3>(endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionAtSpeed<T>(this T target, Vector3 endValue, float averageSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionAtSpeed(target, new TweenSettings<Vector3>(endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionAtSpeed<T>(this T target, Vector3 startValue, Vector3 endValue, float averageSpeed, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionAtSpeed(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionAtSpeedA<T>(this T target, Vector3 startValue, Vector3 endValue, float averageSpeed, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionAtSpeed(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(averageSpeed, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LocalPositionAtSpeed<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        var speed = settings.settings.Duration;
        if(speed <= 0)
        {
            Debug.LogError($"Invalid speed provided to the Tween.{nameof(LocalPositionAtSpeed)}() method: {speed}.");
            return default;
        }
        if(settings.startFromCurrent)
        {
            settings.startFromCurrent = false;
            settings.startValue = target.transform.localPosition;
        }
        settings.settings.Duration = TweenExtensions.CalcDistance(settings.startValue, settings.endValue) / speed;
        return LocalPosition(target, settings);
    }
    #endregion
    #region Position Additive
    public static W_Tween PositionAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
       => PositionAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween PositionAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => PositionAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween PositionAdditive<T>(this T target, Vector3 deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.position += delta);
    public static W_Tween LocalPositionAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween LocalPositionAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => LocalPositionAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween LocalPositionAdditive<T>(this T target, Vector3 deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.localPosition += delta);
    #endregion
}