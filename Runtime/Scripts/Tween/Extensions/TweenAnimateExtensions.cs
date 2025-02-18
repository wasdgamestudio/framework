using System;
using UnityEngine;

internal static class TweenAnimateExtensions
{
    static W_Tween AnimateIntAsFloat(object target, ref TweenSettings<float> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Int);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween AnimateWithIntParam(object target, int intParam, ref TweenSettings<float> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Float);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }

    public static W_Tween AnimateWithIntParam(object target, int intParam, ref TweenSettings<Vector2> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector2);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween AnimateWithIntParam(object target, int intParam, ref TweenSettings<Vector3> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector3);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween AnimateWithIntParam(object target, int intParam, ref TweenSettings<Color> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Color);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween AnimateWithIntParam(object target, int intParam, ref TweenSettings<Vector4> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector4);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween AnimateWithIntParam(object target, int intParam, ref TweenSettings<Quaternion> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Quaternion);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    static W_Tween animateWithIntParam(object target, int intParam, ref TweenSettings<Rect> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.intParam = intParam;
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Rect);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<Color> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Color);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<float> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Float);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<Vector2> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector2);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<Vector3> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector3);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<Vector4> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector4);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<Quaternion> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Quaternion);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Animate(object target, ref TweenSettings<Rect> settings, Action<ReusableTween> setter, Func<ReusableTween, ValueContainer> getter, TweenType _tweenType)
    {
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Rect);
        tween.Setup(target, ref settings.settings, setter, getter, settings.startFromCurrent, _tweenType);
        return TweenManager.Animate(tween);
    }
}
