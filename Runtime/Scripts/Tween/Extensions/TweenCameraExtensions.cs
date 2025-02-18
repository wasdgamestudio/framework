using System;
using UnityEngine;
public static class TweenCameraExtensions
{
    #region Camera OrthographicSize
    public static W_Tween CameraOrthographicSize(this Camera target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => CameraOrthographicSize(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraOrthographicSize(this Camera target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraOrthographicSize(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraOrthographicSize(this Camera target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraOrthographicSize(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraOrthographicSize(this Camera target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraOrthographicSize(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraOrthographicSize(this Camera target, Single endValue, TweenSettings settings) => CameraOrthographicSize(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween CameraOrthographicSize(this Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraOrthographicSize(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween CameraOrthographicSize(this Camera target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Camera;
            var val = _tween.FloatVal;
            _target.orthographicSize = val;
        }, t => (t.target as Camera).orthographicSize.ToContainer(), TweenType.CameraOrthographicSize);
    }
    #endregion
    #region Camera BackgroundColor
    public static W_Tween CameraBackgroundColor(this Camera target, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraBackgroundColor(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraBackgroundColor(this Camera target, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraBackgroundColor(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraBackgroundColor(this Camera target, Color startValue, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraBackgroundColor(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraBackgroundColor(this Camera target, Color startValue, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraBackgroundColor(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraBackgroundColor(this Camera target, Color endValue, TweenSettings settings) => CameraBackgroundColor(target, new TweenSettings<Color>(endValue, settings));
    public static W_Tween CameraBackgroundColor(this Camera target, Color startValue, Color endValue, TweenSettings settings) => CameraBackgroundColor(target, new TweenSettings<Color>(startValue, endValue, settings));
    public static W_Tween CameraBackgroundColor(this Camera target, TweenSettings<Color> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Camera;
            var val = _tween.ColorVal;
            _target.backgroundColor = val;
        }, t => (t.target as Camera).backgroundColor.ToContainer(), TweenType.CameraBackgroundColor);
    }
    #endregion
    #region Camera Aspect
    public static W_Tween CameraAspect(this Camera target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraAspect(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraAspect(this Camera target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraAspect(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraAspect(this Camera target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraAspect(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraAspect(this Camera target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraAspect(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraAspect(this Camera target, Single endValue, TweenSettings settings) => CameraAspect(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween CameraAspect(this Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraAspect(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween CameraAspect(this Camera target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Camera;
            var val = _tween.FloatVal;
            _target.aspect = val;
        }, t => (t.target as Camera).aspect.ToContainer(), TweenType.CameraAspect);
    }
    #endregion
    #region Camera FarClipPlane
    public static W_Tween CameraFarClipPlane(this Camera target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFarClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFarClipPlane(this Camera target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFarClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFarClipPlane(this Camera target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFarClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFarClipPlane(this Camera target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFarClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFarClipPlane(this Camera target, Single endValue, TweenSettings settings) => CameraFarClipPlane(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween CameraFarClipPlane(this Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraFarClipPlane(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween CameraFarClipPlane(this Camera target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Camera;
            var val = _tween.FloatVal;
            _target.farClipPlane = val;
        }, t => (t.target as Camera).farClipPlane.ToContainer(), TweenType.CameraFarClipPlane);
    }
    #endregion
    #region Camera FieldOfView
    public static W_Tween CameraFieldOfView(this Camera target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFieldOfView(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFieldOfView(this Camera target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFieldOfView(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFieldOfView(this Camera target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFieldOfView(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFieldOfView(this Camera target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraFieldOfView(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraFieldOfView(this Camera target, Single endValue, TweenSettings settings) => CameraFieldOfView(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween CameraFieldOfView(this Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraFieldOfView(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween CameraFieldOfView(this Camera target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Camera;
            var val = _tween.FloatVal;
            _target.fieldOfView = val;
        }, t => (t.target as Camera).fieldOfView.ToContainer(), TweenType.CameraFieldOfView);
    }
    #endregion
    #region Camera NearClipPlane
    public static W_Tween CameraNearClipPlane(this Camera target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraNearClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraNearClipPlane(this Camera target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraNearClipPlane(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraNearClipPlane(this Camera target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraNearClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraNearClipPlane(this Camera target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => CameraNearClipPlane(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween CameraNearClipPlane(this Camera target, Single endValue, TweenSettings settings) => CameraNearClipPlane(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween CameraNearClipPlane(this Camera target, Single startValue, Single endValue, TweenSettings settings) => CameraNearClipPlane(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween CameraNearClipPlane(this Camera target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Camera;
            var val = _tween.FloatVal;
            _target.nearClipPlane = val;
        }, t => (t.target as Camera).nearClipPlane.ToContainer(), TweenType.CameraNearClipPlane);
    }
    #endregion
}
