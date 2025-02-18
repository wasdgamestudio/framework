using System;
using UnityEngine;
public static class TweenLightExtensions
{
    #region LightRange
    public static W_Tween LightRange(this Light target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => LightRange(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightRange(this Light target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightRange(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightRange(this Light target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightRange(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightRange(this Light target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightRange(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightRange(this Light target, Single endValue, TweenSettings settings) => LightRange(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween LightRange(this Light target, Single startValue, Single endValue, TweenSettings settings) => LightRange(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween LightRange(this Light target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Light;
            var val = _tween.FloatVal;
            _target.range = val;
        }, t => (t.target as Light).range.ToContainer(), TweenType.LightRange);
    }
    #endregion
    #region LightShadowStrength
    public static W_Tween LightShadowStrength(this Light target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightShadowStrength(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightShadowStrength(this Light target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightShadowStrength(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightShadowStrength(this Light target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightShadowStrength(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightShadowStrength(this Light target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightShadowStrength(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightShadowStrength(this Light target, Single endValue, TweenSettings settings) => LightShadowStrength(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween LightShadowStrength(this Light target, Single startValue, Single endValue, TweenSettings settings) => LightShadowStrength(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween LightShadowStrength(this Light target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Light;
            var val = _tween.FloatVal;
            _target.shadowStrength = val;
        }, t => (t.target as Light).shadowStrength.ToContainer(), TweenType.LightShadowStrength);
    }
    #endregion
    #region LightIntensity
    public static W_Tween LightIntensity(this Light target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightIntensity(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightIntensity(this Light target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightIntensity(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightIntensity(this Light target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightIntensity(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightIntensity(this Light target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightIntensity(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightIntensity(this Light target, Single endValue, TweenSettings settings) => LightIntensity(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween LightIntensity(this Light target, Single startValue, Single endValue, TweenSettings settings) => LightIntensity(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween LightIntensity(this Light target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Light;
            var val = _tween.FloatVal;
            _target.intensity = val;
        }, t => (t.target as Light).intensity.ToContainer(), TweenType.LightIntensity);
    }
    #endregion
    #region LightColor
    public static W_Tween LightColor(this Light target, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightColor(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightColor(this Light target, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightColor(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightColor(this Light target, Color startValue, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightColor(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightColor(this Light target, Color startValue, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => LightColor(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween LightColor(this Light target, Color endValue, TweenSettings settings) => LightColor(target, new TweenSettings<Color>(endValue, settings));
    public static W_Tween LightColor(this Light target, Color startValue, Color endValue, TweenSettings settings) => LightColor(target, new TweenSettings<Color>(startValue, endValue, settings));
    public static W_Tween LightColor(this Light target, TweenSettings<Color> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Light;
            var val = _tween.ColorVal;
            _target.color = val;
        }, t => (t.target as Light).color.ToContainer(), TweenType.LightColor);
    }
    #endregion
}
