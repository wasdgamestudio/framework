using System;
using UnityEngine;
public static class TweenMaterialExtensions
{
    #region Material Color Property
    public static W_Tween MaterialColor(this Material target, int propertyId, Color endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => MaterialColor(target, propertyId, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, int propertyId, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialColor(target, propertyId, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, int propertyId, Color startValue, Color endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialColor(target, propertyId, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, int propertyId, Color startValue, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialColor(target, propertyId, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, int propertyId, Color endValue, TweenSettings settings) => MaterialColor(target, propertyId, new TweenSettings<Color>(endValue, settings));
    public static W_Tween MaterialColor(this Material target, int propertyId, Color startValue, Color endValue, TweenSettings settings) => MaterialColor(target, propertyId, new TweenSettings<Color>(startValue, endValue, settings));
    public static W_Tween MaterialColor(this Material target, int propertyId, TweenSettings<Color> settings)
    {
        return TweenAnimateExtensions.AnimateWithIntParam(target, propertyId, ref settings,
            tween => (tween.target as Material).SetColor(tween.intParam, tween.ColorVal),
            tween => (tween.target as Material).GetColor(tween.intParam).ToContainer(), TweenType.MaterialColorProperty);
    }
    #endregion
    #region Material Color
    public static W_Tween MaterialColor(this Material target, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => MaterialColor(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialColor(target, new TweenSettings<Color>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, Color startValue, Color endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialColor(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, Color startValue, Color endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialColor(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialColor(this Material target, Color endValue, TweenSettings settings) => MaterialColor(target, new TweenSettings<Color>(endValue, settings));
    public static W_Tween MaterialColor(this Material target, Color startValue, Color endValue, TweenSettings settings) => MaterialColor(target, new TweenSettings<Color>(startValue, endValue, settings));
    public static W_Tween MaterialColor(this Material target, TweenSettings<Color> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Material;
            var val = _tween.ColorVal;
            _target.color = val;
        }, t => (t.target as Material).color.ToContainer(), TweenType.MaterialColor);
    }
    #endregion
    #region  Material Property Vector4
    public static W_Tween MaterialProperty(this Material target, int propertyId, Vector4 endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<Vector4>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, Vector4 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<Vector4>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, Vector4 startValue, Vector4 endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<Vector4>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, Vector4 startValue, Vector4 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<Vector4>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, Vector4 endValue, TweenSettings settings) => MaterialProperty(target, propertyId, new TweenSettings<Vector4>(endValue, settings));
    public static W_Tween MaterialProperty(this Material target, int propertyId, Vector4 startValue, Vector4 endValue, TweenSettings settings) => MaterialProperty(target, propertyId, new TweenSettings<Vector4>(startValue, endValue, settings));
    public static W_Tween MaterialProperty(this Material target, int propertyId, TweenSettings<Vector4> settings)
    {
        return TweenAnimateExtensions.AnimateWithIntParam(target, propertyId, ref settings,
            tween => (tween.target as Material).SetVector(tween.intParam, tween.Vector4Val),
            tween => (tween.target as Material).GetVector(tween.intParam).ToContainer(), TweenType.MaterialPropertyVector4);
    }
    #endregion
    #region Material Property
    public static W_Tween MaterialProperty(this Material target, int propertyId, float endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, float endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, float startValue, float endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, float startValue, float endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialProperty(target, propertyId, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialProperty(this Material target, int propertyId, float endValue, TweenSettings settings) => MaterialProperty(target, propertyId, new TweenSettings<float>(endValue, settings));
    public static W_Tween MaterialProperty(this Material target, int propertyId, float startValue, float endValue, TweenSettings settings) => MaterialProperty(target, propertyId, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween MaterialProperty(this Material target, int propertyId, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.AnimateWithIntParam(target, propertyId, ref settings,
            tween => (tween.target as Material).SetFloat(tween.intParam, tween.FloatVal),
            tween => (tween.target as Material).GetFloat(tween.intParam).ToContainer(), TweenType.MaterialProperty);
    }
    #endregion
    #region Material Alpha Property
    public static W_Tween MaterialAlpha(this Material target, int propertyId, float endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, propertyId, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, int propertyId, float endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, propertyId, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, int propertyId, float startValue, float endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, propertyId, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, int propertyId, float startValue, float endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, propertyId, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, int propertyId, float endValue, TweenSettings settings) => MaterialAlpha(target, propertyId, new TweenSettings<float>(endValue, settings));
    public static W_Tween MaterialAlpha(this Material target, int propertyId, float startValue, float endValue, TweenSettings settings) => MaterialAlpha(target, propertyId, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween MaterialAlpha(this Material target, int propertyId, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.AnimateWithIntParam(target, propertyId, ref settings,
            tween =>
            {
                var _target = tween.target as Material;
                var _propId = tween.intParam;
                _target.SetColor(_propId, _target.GetColor(_propId).WithAlpha(tween.FloatVal));
            },
            tween => (tween.target as Material).GetColor(tween.intParam).a.ToContainer(), TweenType.MaterialAlphaProperty);
    }
    #endregion
    #region Material Alpha
    public static W_Tween MaterialAlpha(this Material target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialAlpha(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialAlpha(this Material target, Single endValue, TweenSettings settings) => MaterialAlpha(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween MaterialAlpha(this Material target, Single startValue, Single endValue, TweenSettings settings) => MaterialAlpha(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween MaterialAlpha(this Material target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Material;
            var val = _tween.FloatVal;
            _target.color = _target.color.WithAlpha(val);
        }, t => (t.target as Material).color.a.ToContainer(), TweenType.MaterialAlpha);
    }
    #endregion
    #region Material Texture Offset Property
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, Vector2 endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureOffset(target, propertyId, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureOffset(target, propertyId, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureOffset(target, propertyId, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureOffset(target, propertyId, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, Vector2 endValue, TweenSettings settings) => MaterialTextureOffset(target, propertyId, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, Vector2 startValue, Vector2 endValue, TweenSettings settings) => MaterialTextureOffset(target, propertyId, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween MaterialTextureOffset(this Material target, int propertyId, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.AnimateWithIntParam(target, propertyId, ref settings,
            tween => (tween.target as Material).SetTextureOffset(tween.intParam, tween.Vector2Val),
            tween => (tween.target as Material).GetTextureOffset(tween.intParam).ToContainer(), TweenType.MaterialTextureOffset);
    }
    #endregion
    #region Material Main Texture Offset
    public static W_Tween MaterialMainTextureOffset(this Material target, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureOffset(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureOffset(this Material target, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureOffset(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureOffset(this Material target, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureOffset(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureOffset(this Material target, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureOffset(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureOffset(this Material target, Vector2 endValue, TweenSettings settings) => MaterialMainTextureOffset(target, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween MaterialMainTextureOffset(this Material target, Vector2 startValue, Vector2 endValue, TweenSettings settings) => MaterialMainTextureOffset(target, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween MaterialMainTextureOffset(this Material target, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Material;
            var val = _tween.Vector2Val;
            _target.mainTextureOffset = val;
        }, t => (t.target as Material).mainTextureOffset.ToContainer(), TweenType.MaterialMainTextureOffset);
    }
    #endregion
    #region Material Texture Scale Property
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, Vector2 endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureScale(target, propertyId, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureScale(target, propertyId, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureScale(target, propertyId, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialTextureScale(target, propertyId, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, Vector2 endValue, TweenSettings settings) => MaterialTextureScale(target, propertyId, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, Vector2 startValue, Vector2 endValue, TweenSettings settings) => MaterialTextureScale(target, propertyId, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween MaterialTextureScale(this Material target, int propertyId, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.AnimateWithIntParam(target, propertyId, ref settings,
            tween => (tween.target as Material).SetTextureScale(tween.intParam, tween.Vector2Val),
            tween => (tween.target as Material).GetTextureScale(tween.intParam).ToContainer(), TweenType.MaterialTextureScale);
    }
    #endregion
    #region Material Texture Scale
    public static W_Tween MaterialMainTextureScale(this Material target, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureScale(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureScale(this Material target, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureScale(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureScale(this Material target, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureScale(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureScale(this Material target, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MaterialMainTextureScale(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MaterialMainTextureScale(this Material target, Vector2 endValue, TweenSettings settings) => MaterialMainTextureScale(target, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween MaterialMainTextureScale(this Material target, Vector2 startValue, Vector2 endValue, TweenSettings settings) => MaterialMainTextureScale(target, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween MaterialMainTextureScale(this Material target, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Material;
            var val = _tween.Vector2Val;
            _target.mainTextureScale = val;
        }, t => (t.target as Material).mainTextureScale.ToContainer(), TweenType.MaterialMainTextureScale);
    }
    #endregion
}