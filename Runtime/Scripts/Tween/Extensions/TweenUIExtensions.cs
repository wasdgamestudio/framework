using System;
using UnityEngine;
using UnityEngine.UI;
public static class TweenUIExtensions
{
    #region Slider
    public static W_Tween Value(this Slider target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
      => Value(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this Slider target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this Slider target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this Slider target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this Slider target, Single endValue, TweenSettings settings) => Value(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween Value(this Slider target, Single startValue, Single endValue, TweenSettings settings) => Value(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween Value(this Slider target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Slider;
            var val = _tween.FloatVal;
            _target.value = val;
        }, t => (t.target as Slider).value.ToContainer(), TweenType.UISliderValue);
    }
    #endregion

    #region ScrollRect
    #region NormalizedPosition
    public static W_Tween Value(this ScrollRect target, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this ScrollRect target, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this ScrollRect target, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this ScrollRect target, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Value(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Value(this ScrollRect target, Vector2 endValue, TweenSettings settings) => Value(target, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween Value(this ScrollRect target, Vector2 startValue, Vector2 endValue, TweenSettings settings) => Value(target, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween Value(this ScrollRect target, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as ScrollRect;
            var val = _tween.Vector2Val;
            _target.SetNormalizedPosition(val);
        }, t => (t.target as ScrollRect).GetNormalizedPosition().ToContainer(), TweenType.UINormalizedPosition);
    }
    #endregion
    #region HorizontalNormalizedPosition
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => HorizontalNormalizedValue(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => HorizontalNormalizedValue(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => HorizontalNormalizedValue(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => HorizontalNormalizedValue(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, Single endValue, TweenSettings settings) => HorizontalNormalizedValue(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, Single startValue, Single endValue, TweenSettings settings) => HorizontalNormalizedValue(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween HorizontalNormalizedValue(this ScrollRect target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as ScrollRect;
            var val = _tween.FloatVal;
            _target.horizontalNormalizedPosition = val;
        }, t => (t.target as ScrollRect).horizontalNormalizedPosition.ToContainer(), TweenType.UIHorizontalNormalizedPosition);
    }
    #endregion
    #region VerticalNormalizedPosition
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => VerticalNormalizedValue(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => VerticalNormalizedValue(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => VerticalNormalizedValue(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => VerticalNormalizedValue(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, Single endValue, TweenSettings settings) => VerticalNormalizedValue(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, Single startValue, Single endValue, TweenSettings settings) => VerticalNormalizedValue(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween VerticalNormalizedValue(this ScrollRect target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as ScrollRect;
            var val = _tween.FloatVal;
            _target.verticalNormalizedPosition = val;
        }, t => (t.target as ScrollRect).verticalNormalizedPosition.ToContainer(), TweenType.UIVerticalNormalizedPosition);
    }
    #endregion
    #endregion

    public static W_Tween Color(this Graphic target, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this Graphic target, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this Graphic target, Color startValue, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this Graphic target, Color startValue, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Color(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Color(this Graphic target, Color endValue, TweenSettings settings) => Color(target, new TweenSettings<Color>(endValue, settings));
    public static W_Tween Color(this Graphic target, Color startValue, Color endValue, TweenSettings settings) => Color(target, new TweenSettings<Color>(startValue, endValue, settings));
    public static W_Tween Color(this Graphic target, TweenSettings<Color> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Graphic;
            var val = _tween.ColorVal;
            _target.color = val;
        }, t => (t.target as Graphic).color.ToContainer(), TweenType.UIColorGraphic);
    }

    public static W_Tween SizeDelta(this RectTransform target, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => SizeDelta(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween SizeDelta(this RectTransform target, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => SizeDelta(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween SizeDelta(this RectTransform target, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => SizeDelta(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween SizeDelta(this RectTransform target, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => SizeDelta(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween SizeDelta(this RectTransform target, Vector2 endValue, TweenSettings settings) => SizeDelta(target, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween SizeDelta(this RectTransform target, Vector2 startValue, Vector2 endValue, TweenSettings settings) => SizeDelta(target, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween SizeDelta(this RectTransform target, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as RectTransform;
            var val = _tween.Vector2Val;
            _target.sizeDelta = val;
        }, t => (t.target as RectTransform).sizeDelta.ToContainer(), TweenType.UISizeDelta);
    }

    public static W_Tween Alpha(this CanvasGroup target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this CanvasGroup target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this CanvasGroup target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this CanvasGroup target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this CanvasGroup target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween Alpha(this CanvasGroup target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween Alpha(this CanvasGroup target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as CanvasGroup;
            var val = _tween.FloatVal;
            _target.alpha = val;
        }, t => (t.target as CanvasGroup).alpha.ToContainer(), TweenType.UIAlphaCanvasGroup);
    }

    public static W_Tween Alpha(this Graphic target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this Graphic target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this Graphic target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this Graphic target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Alpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween Alpha(this Graphic target, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween Alpha(this Graphic target, Single startValue, Single endValue, TweenSettings settings) => Alpha(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween Alpha(this Graphic target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Graphic;
            var val = _tween.FloatVal;
            _target.color = _target.color.WithAlpha(val);
        }, t => (t.target as Graphic).color.a.ToContainer(), TweenType.UIAlphaGraphic);
    }

    public static W_Tween FillAmount(this Image target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => FillAmount(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween FillAmount(this Image target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => FillAmount(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween FillAmount(this Image target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => FillAmount(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween FillAmount(this Image target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => FillAmount(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween FillAmount(this Image target, Single endValue, TweenSettings settings) => FillAmount(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween FillAmount(this Image target, Single startValue, Single endValue, TweenSettings settings) => FillAmount(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween FillAmount(this Image target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Image;
            var val = _tween.FloatVal;
            _target.fillAmount = val;
        }, t => (t.target as Image).fillAmount.ToContainer(), TweenType.UIFillAmount);
    }
}