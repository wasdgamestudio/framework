using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial struct W_Tween
{
    public static W_Tween Custom(TweenSettings<Vector2> settings, Action<Vector2> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector2);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Vector2>;
            var val = _tween.Vector2Val;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomVector2);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<Vector3> settings, Action<Vector3> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector3);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Vector3>;
            var val = _tween.Vector3Val;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomVector3);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<Vector4> settings, Action<Vector4> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector4);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Vector4>;
            var val = _tween.Vector4Val;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomVector4);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<Color> settings, Action<Color> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Color);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Color>;
            var val = _tween.ColorVal;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomColor);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<float> settings, Action<float> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Float);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<float>;
            var val = _tween.FloatVal;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomFloat);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<Rect> settings, Action<Rect> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Rect);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Rect>;
            var val = _tween.RectVal;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomRect);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<Quaternion> settings, Action<Quaternion> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Quaternion);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Quaternion>;
            var val = _tween.QuaternionVal;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomQuaternion);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(TweenSettings<Double> settings, Action<Double> onValueChange)
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Double);
        tween.customOnValueChange = onValueChange;
        tween.Setup(TweenManager.dummyTarget, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<Double>;
            var val = _tween.DoubleVal;
            try
            {
                _onValueChange(val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomDouble);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Color> settings, Action<T, Color> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Color);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Color>;
            var _target = _tween.target as T;
            Color val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.ColorVal;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.ColorVal = newVal;
            }
            else
            {
                val = _tween.ColorVal;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomColor);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<float> settings, Action<T, float> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Float);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, float>;
            var _target = _tween.target as T;
            float val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.FloatVal;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.FloatVal = newVal;
            }
            else
            {
                val = _tween.FloatVal;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomFloat);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Vector2> settings, Action<T, Vector2> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector2);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Vector2>;
            var _target = _tween.target as T;
            Vector2 val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.Vector2Val;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.Vector2Val = newVal;
            }
            else
            {
                val = _tween.Vector2Val;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomVector2);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Vector3> settings, Action<T, Vector3> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector3);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Vector3>;
            var _target = _tween.target as T;
            Vector3 val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.Vector3Val;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.Vector3Val = newVal;
            }
            else
            {
                val = _tween.Vector3Val;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomVector3);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Rect> settings, Action<T, Rect> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Rect);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Rect>;
            var _target = _tween.target as T;
            Rect val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.RectVal;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.RectVal = newVal;
            }
            else
            {
                val = _tween.RectVal;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomRect);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Quaternion> settings, Action<T, Quaternion> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Quaternion);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Quaternion>;
            var _target = _tween.target as T;
            Quaternion val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.QuaternionVal;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.QuaternionVal = newVal;
            }
            else
            {
                val = _tween.QuaternionVal;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomQuaternion);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Vector4> settings, Action<T, Vector4> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Vector4);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Vector4>;
            var _target = _tween.target as T;
            Vector4 val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.Vector4Val;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.Vector4Val = newVal;
            }
            else
            {
                val = _tween.Vector4Val;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomVector4);
        return TweenManager.Animate(tween);
    }
    static W_Tween CustomInternal<T>(T target, TweenSettings<Double> settings, Action<T, Double> onValueChange, bool isAdditive = false) where T : class
    {
        Assert.IsNotNull(onValueChange);
        var tween = TweenManager.FetchTween();
        tween.startValue.CopyFrom(ref settings.startValue);
        tween.endValue.CopyFrom(ref settings.endValue);
        tween.setPropType(PropType.Double);
        tween.customOnValueChange = onValueChange;
        tween.isAdditive = isAdditive;
        tween.Setup(target, ref settings.settings, _tween =>
        {
            var _onValueChange = _tween.customOnValueChange as Action<T, Double>;
            var _target = _tween.target as T;
            Double val;
            if(_tween.isAdditive)
            {
                var newVal = _tween.DoubleVal;
                val = newVal.calcDelta(_tween.prevVal);
                _tween.prevVal.DoubleVal = newVal;
            }
            else
            {
                val = _tween.DoubleVal;
            }
            try
            {
                _onValueChange(_target, val);
            }
            catch(Exception e)
            {
                Assert.LogError($"Tween was stopped because of exception in {nameof(onValueChange)} callback, tween: {_tween.GetDescription()}, exception:\n{e}\n", _tween.id, _tween.target as UnityEngine.Object);
                _tween.EmergencyStop();
            }
        }, null, false, TweenType.CustomDouble);
        return TweenManager.Animate(tween);
    }
    public static W_Tween Custom(float startValue, float endValue, float duration, Action<float> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
      => Custom(new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(float startValue, float endValue, float duration, Action<float> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(float startValue, float endValue, TweenSettings settings, Action<float> onValueChange) => Custom(new TweenSettings<float>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, float startValue, float endValue, float duration, Action<T, float> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class => CustomInternal(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, float startValue, float endValue, float duration, Action<T, float> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class => CustomInternal(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, float startValue, float endValue, TweenSettings settings, Action<T, float> onValueChange) where T : class => CustomInternal(target, new TweenSettings<float>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<float> settings, Action<T, float> onValueChange) where T : class => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, float deltaValue, TweenSettings settings, Action<T, float> onDeltaChange) where T : class => CustomInternal(target, new TweenSettings<float>(default, deltaValue, settings), onDeltaChange, true);
    public static W_Tween Custom(Color startValue, Color endValue, float duration, Action<Color> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Color startValue, Color endValue, float duration, Action<Color> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Color startValue, Color endValue, TweenSettings settings, Action<Color> onValueChange) => Custom(new TweenSettings<Color>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Color startValue, Color endValue, float duration, Action<T, Color> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Color startValue, Color endValue, float duration, Action<T, Color> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Color>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Color startValue, Color endValue, TweenSettings settings, Action<T, Color> onValueChange) where T : class
        => CustomInternal(target, new TweenSettings<Color>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<Color> settings, Action<T, Color> onValueChange) where T : class => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, Color deltaValue, TweenSettings settings, Action<T, Color> onDeltaChange) where T : class
        => CustomInternal(target, new TweenSettings<Color>(default, deltaValue, settings), onDeltaChange, true);
    public static W_Tween Custom(Vector2 startValue, Vector2 endValue, float duration, Action<Vector2> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => Custom(new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Vector2 startValue, Vector2 endValue, float duration, Action<Vector2> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Vector2 startValue, Vector2 endValue, TweenSettings settings, Action<Vector2> onValueChange) => Custom(new TweenSettings<Vector2>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Vector2 startValue, Vector2 endValue, float duration, Action<T, Vector2> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class => CustomInternal(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Vector2 startValue, Vector2 endValue, float duration, Action<T, Vector2> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class => CustomInternal(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Vector2 startValue, Vector2 endValue, TweenSettings settings, Action<T, Vector2> onValueChange) where T : class => CustomInternal(target, new TweenSettings<Vector2>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<Vector2> settings, Action<T, Vector2> onValueChange) where T : class => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, Vector2 deltaValue, TweenSettings settings, Action<T, Vector2> onDeltaChange) where T : class => CustomInternal(target, new TweenSettings<Vector2>(default, deltaValue, settings), onDeltaChange, true);
    public static W_Tween Custom(Vector3 startValue, Vector3 endValue, float duration, Action<Vector3> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Vector3 startValue, Vector3 endValue, float duration, Action<Vector3> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Vector3 startValue, Vector3 endValue, TweenSettings settings, Action<Vector3> onValueChange) => Custom(new TweenSettings<Vector3>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Vector3 startValue, Vector3 endValue, float duration, Action<T, Vector3> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Vector3 startValue, Vector3 endValue, float duration, Action<T, Vector3> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Vector3 startValue, Vector3 endValue, TweenSettings settings, Action<T, Vector3> onValueChange) where T : class
        => CustomInternal(target, new TweenSettings<Vector3>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<Vector3> settings, Action<T, Vector3> onValueChange) where T : class
        => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, Vector3 deltaValue, TweenSettings settings, Action<T, Vector3> onDeltaChange) where T : class
        => CustomInternal(target, new TweenSettings<Vector3>(default, deltaValue, settings), onDeltaChange, true);
    public static W_Tween Custom(Vector4 startValue, Vector4 endValue, float duration, Action<Vector4> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => Custom(new TweenSettings<Vector4>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Vector4 startValue, Vector4 endValue, float duration, Action<Vector4> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Vector4>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Vector4 startValue, Vector4 endValue, TweenSettings settings, Action<Vector4> onValueChange) => Custom(new TweenSettings<Vector4>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Vector4 startValue, Vector4 endValue, float duration, Action<T, Vector4> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Vector4>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Vector4 startValue, Vector4 endValue, float duration, Action<T, Vector4> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Vector4>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Vector4 startValue, Vector4 endValue, TweenSettings settings, Action<T, Vector4> onValueChange) where T : class
        => CustomInternal(target, new TweenSettings<Vector4>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<Vector4> settings, Action<T, Vector4> onValueChange) where T : class
        => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, Vector4 deltaValue, TweenSettings settings, Action<T, Vector4> onDeltaChange) where T : class
        => CustomInternal(target, new TweenSettings<Vector4>(default, deltaValue, settings), onDeltaChange, true);
    public static W_Tween Custom(Quaternion startValue, Quaternion endValue, float duration, Action<Quaternion> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => Custom(new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Quaternion startValue, Quaternion endValue, float duration, Action<Quaternion> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Quaternion startValue, Quaternion endValue, TweenSettings settings, Action<Quaternion> onValueChange) => Custom(new TweenSettings<Quaternion>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Quaternion startValue, Quaternion endValue, float duration, Action<T, Quaternion> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Quaternion startValue, Quaternion endValue, float duration, Action<T, Quaternion> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Quaternion startValue, Quaternion endValue, TweenSettings settings, Action<T, Quaternion> onValueChange) where T : class
        => CustomInternal(target, new TweenSettings<Quaternion>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<Quaternion> settings, Action<T, Quaternion> onValueChange) where T : class
        => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, Quaternion deltaValue, TweenSettings settings, Action<T, Quaternion> onDeltaChange) where T : class
        => CustomInternal(target, new TweenSettings<Quaternion>(default, deltaValue, settings), onDeltaChange, true);
    public static W_Tween Custom(Rect startValue, Rect endValue, float duration, Action<Rect> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => Custom(new TweenSettings<Rect>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Rect startValue, Rect endValue, float duration, Action<Rect> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Rect>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom(Rect startValue, Rect endValue, TweenSettings settings, Action<Rect> onValueChange) => Custom(new TweenSettings<Rect>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Rect startValue, Rect endValue, float duration, Action<T, Rect> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Rect>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Rect startValue, Rect endValue, float duration, Action<T, Rect> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Rect>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);
    public static W_Tween Custom<T>(T target, Rect startValue, Rect endValue, TweenSettings settings, Action<T, Rect> onValueChange) where T : class
        => CustomInternal(target, new TweenSettings<Rect>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, TweenSettings<Rect> settings, Action<T, Rect> onValueChange) where T : class
        => CustomInternal(target, settings, onValueChange);
    public static W_Tween CustomAdditive<T>(T target, Rect deltaValue, TweenSettings settings, Action<T, Rect> onDeltaChange) where T : class
        => CustomInternal(target, new TweenSettings<Rect>(default, deltaValue, settings), onDeltaChange, true);

    public static W_Tween Custom(Double startValue, Double endValue, float duration, Action<Double> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Double>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);

    public static W_Tween Custom(Double startValue, Double endValue, float duration, Action<Double> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => Custom(new TweenSettings<Double>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);

    public static W_Tween Custom(Double startValue, Double endValue, TweenSettings settings, Action<Double> onValueChange) => Custom(new TweenSettings<Double>(startValue, endValue, settings), onValueChange);
    public static W_Tween Custom<T>(T target, Double startValue, Double endValue, float duration, Action<T, Double> onValueChange, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Double>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);

    public static W_Tween Custom<T>(T target, Double startValue, Double endValue, float duration, Action<T, Double> onValueChange, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false) where T : class
        => CustomInternal(target, new TweenSettings<Double>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)), onValueChange);

    public static W_Tween Custom<T>(T target, Double startValue, Double endValue, TweenSettings settings, Action<T, Double> onValueChange) where T : class
        => CustomInternal(target, new TweenSettings<Double>(startValue, endValue, settings), onValueChange);

    public static W_Tween Custom<T>(T target, TweenSettings<Double> settings, Action<T, Double> onValueChange) where T : class
        => CustomInternal(target, settings, onValueChange);

    public static W_Tween CustomAdditive<T>(T target, Double deltaValue, TweenSettings settings, Action<T, Double> onDeltaChange) where T : class
        => CustomInternal(target, new TweenSettings<Double>(default, deltaValue, settings), onDeltaChange, true);
}
