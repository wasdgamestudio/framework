using System;
using UnityEngine;

public static class TweenRendererExtensions
{
    #region Color SpriteRenderer
    public static W_Tween Color(this SpriteRenderer target, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => Color(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this SpriteRenderer target, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this SpriteRenderer target, Color startValue, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this SpriteRenderer target, Color startValue, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this SpriteRenderer target, Color endValue, TweenSettings settings) => Color(target, new TweenSettings<Color>(endValue, settings));
    public static W_Tween Color(this SpriteRenderer target, Color startValue, Color endValue, TweenSettings settings) => Color(target, new TweenSettings<Color>(startValue, endValue, settings));
    public static W_Tween Color(this SpriteRenderer target, TweenSettings<Color> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as SpriteRenderer;
            var val = _tween.ColorVal;
            _target.color = val;
        }, t => (t.target as SpriteRenderer).color.ToContainer(), TweenType.Color);
    }
    #endregion
    #region Alpha SpriteRenderer
    public static W_Tween Alpha(this SpriteRenderer target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this SpriteRenderer target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this SpriteRenderer target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this SpriteRenderer target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this SpriteRenderer target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween Alpha(this SpriteRenderer target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween Alpha(this SpriteRenderer target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as SpriteRenderer;
            var val = _tween.FloatVal;
            _target.color = _target.color.WithAlpha(val);
        }, t => (t.target as SpriteRenderer).color.a.ToContainer(), TweenType.Alpha);
    }
    #endregion
}
