using System;
using UnityEngine;

public static class TweenScaleExtensions
{
    #region Scale   
    public static W_Tween Scale<T>(this T target, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
       => Scale(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Scale(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Scale(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Scale(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Vector3 endValue, TweenSettings settings) where T : Component => Scale(target, new TweenSettings<Vector3>(endValue, settings));
    public static W_Tween Scale<T>(this T target, Vector3 startValue, Vector3 endValue, TweenSettings settings) where T : Component => Scale(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween Scale<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
      => Scale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Scale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Scale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => Scale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Scale<T>(this T target, Single endValue, TweenSettings settings) where T : Component => Scale(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween Scale<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => Scale(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween Scale<T>(this T target, TweenSettings<float> uniformScaleSettings) where T : Component
    {
        var remapped = new TweenSettings<Vector3>(uniformScaleSettings.startValue * Vector3.one, uniformScaleSettings.endValue * Vector3.one, uniformScaleSettings.settings) { startFromCurrent = uniformScaleSettings.startFromCurrent };
        return Scale(target, remapped);
    }
    public static W_Tween Scale<T>(this T target, TweenSettings<Vector3> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.Vector3Val;
            _target.localScale = val;
        }, t => (target as Component).transform.localScale.ToContainer(), TweenType.Scale);
    }
    #endregion
    #region Scale X
    public static W_Tween ScaleX<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleX<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleX(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleX<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleX<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleX(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleX<T>(this T target, Single endValue, TweenSettings settings) where T : Component => ScaleX(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween ScaleX<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => ScaleX(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween ScaleX<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.localScale = _target.localScale.WithComponent(0, val);
        }, t => (target as Component).transform.localScale.x.ToContainer(), TweenType.ScaleX);
    }
    #endregion
    #region Scale Y
    public static W_Tween ScaleY<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleY<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleY(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleY<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleY<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleY(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleY<T>(this T target, Single endValue, TweenSettings settings) where T : Component => ScaleY(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween ScaleY<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => ScaleY(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween ScaleY<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.localScale = _target.localScale.WithComponent(1, val);
        }, t => (target as Component).transform.localScale.y.ToContainer(), TweenType.ScaleY);
    }
    #endregion
    #region Scale Z
    public static W_Tween ScaleZ<T>(this T target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleZ<T>(this T target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleZ(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleZ<T>(this T target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleZ<T>(this T target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleZ(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween ScaleZ<T>(this T target, Single endValue, TweenSettings settings) where T : Component => ScaleZ(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween ScaleZ<T>(this T target, Single startValue, Single endValue, TweenSettings settings) where T : Component => ScaleZ(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween ScaleZ<T>(this T target, TweenSettings<float> settings) where T : Component
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = (_tween.target as Component).transform;
            var val = _tween.FloatVal;
            _target.localScale = _target.localScale.WithComponent(2, val);
        }, t => (target as Component).transform.localScale.z.ToContainer(), TweenType.ScaleZ);
    }
    #endregion
    #region Scale Additive
    public static W_Tween ScaleAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
    => ScaleAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween ScaleAdditive<T>(this T target, Vector3 deltaValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : Component
        => ScaleAdditive(target, deltaValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime));
    public static W_Tween ScaleAdditive<T>(this T target, Vector3 deltaValue, TweenSettings settings) where T : Component
        => W_Tween.CustomAdditive(target, deltaValue, settings, (_target, delta) => _target.transform.localScale += delta);
    #endregion
}