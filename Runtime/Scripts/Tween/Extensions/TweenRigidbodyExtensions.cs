using System;
using UnityEngine;
public static class TweenRigidbodyExtensions
{
    #region Move Position 3D
    public static W_Tween MovePosition(this Rigidbody target, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
           => MovePosition(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody target, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MovePosition(target, new TweenSettings<Vector3>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody target, Vector3 startValue, Vector3 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MovePosition(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody target, Vector3 startValue, Vector3 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MovePosition(target, new TweenSettings<Vector3>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody target, Vector3 endValue, TweenSettings settings) => MovePosition(target, new TweenSettings<Vector3>(endValue, settings));
    public static W_Tween MovePosition(this Rigidbody target, Vector3 startValue, Vector3 endValue, TweenSettings settings) => MovePosition(target, new TweenSettings<Vector3>(startValue, endValue, settings));
    public static W_Tween MovePosition(this Rigidbody target, TweenSettings<Vector3> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Rigidbody;
            var val = _tween.Vector3Val;
            _target.MovePosition(val);
        }, t => (t.target as Rigidbody).position.ToContainer(), TweenType.RigidbodyMovePosition);
    }
    #endregion
    #region Move Rotation 3D
    public static W_Tween MoveRotation(this Rigidbody target, Quaternion endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween TweenMoveRotationMoveRotation(this Rigidbody target, Quaternion endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<Quaternion>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody target, Quaternion startValue, Quaternion endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody target, Quaternion startValue, Quaternion endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<Quaternion>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody target, Quaternion endValue, TweenSettings settings) => MoveRotation(target, new TweenSettings<Quaternion>(endValue, settings));
    public static W_Tween MoveRotation(Rigidbody target, Quaternion startValue, Quaternion endValue, TweenSettings settings) => MoveRotation(target, new TweenSettings<Quaternion>(startValue, endValue, settings));
    public static W_Tween MoveRotation(this Rigidbody target, TweenSettings<Quaternion> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Rigidbody;
            var val = _tween.QuaternionVal;
            _target.MoveRotation(val);
        }, t => (t.target as Rigidbody).rotation.ToContainer(), TweenType.RigidbodyMoveRotation);
    }
    #endregion
    #region Move Position 2D
    public static W_Tween MovePosition(this Rigidbody2D target, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
           => MovePosition(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody2D target, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MovePosition(target, new TweenSettings<Vector2>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody2D target, Vector2 startValue, Vector2 endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MovePosition(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody2D target, Vector2 startValue, Vector2 endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MovePosition(target, new TweenSettings<Vector2>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MovePosition(this Rigidbody2D target, Vector2 endValue, TweenSettings settings) => MovePosition(target, new TweenSettings<Vector2>(endValue, settings));
    public static W_Tween MovePosition(this Rigidbody2D target, Vector2 startValue, Vector2 endValue, TweenSettings settings) => MovePosition(target, new TweenSettings<Vector2>(startValue, endValue, settings));
    public static W_Tween MovePosition(this Rigidbody2D target, TweenSettings<Vector2> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Rigidbody2D;
            var val = _tween.Vector2Val;
            _target.MovePosition(val);
        }, t => (t.target as Rigidbody2D).position.ToContainer(), TweenType.RigidbodyMovePosition2D);
    }
    #endregion
    #region Move Rotation 2D
    public static W_Tween MoveRotation(this Rigidbody2D target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody2D target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody2D target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody2D target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => MoveRotation(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween MoveRotation(this Rigidbody2D target, Single endValue, TweenSettings settings) => MoveRotation(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween MoveRotation(this Rigidbody2D target, Single startValue, Single endValue, TweenSettings settings) => MoveRotation(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween MoveRotation(this Rigidbody2D target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as Rigidbody2D;
            var val = _tween.FloatVal;
            _target.MoveRotation(val);
        }, t => (t.target as Rigidbody2D).rotation.ToContainer(), TweenType.RigidbodyMoveRotation2D);
    }
    #endregion
}
