using System;
using UnityEngine;
public static class TweenAudioExtensions
{
    #region AudioVolume
    public static W_Tween AudioVolume(this AudioSource target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
       => AudioVolume(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioVolume(this AudioSource target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioVolume(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioVolume(this AudioSource target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioVolume(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioVolume(this AudioSource target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioVolume(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioVolume(this AudioSource target, Single endValue, TweenSettings settings) => AudioVolume(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween AudioVolume(this AudioSource target, Single startValue, Single endValue, TweenSettings settings) => AudioVolume(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween AudioVolume(this AudioSource target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as AudioSource;
            var val = _tween.FloatVal;
            _target.volume = val;
        }, t => (t.target as AudioSource).volume.ToContainer(), TweenType.AudioVolume);
    }
    #endregion
    #region AudioPitch
    public static W_Tween AudioPitch(this AudioSource target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPitch(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPitch(this AudioSource target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPitch(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPitch(this AudioSource target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPitch(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPitch(this AudioSource target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPitch(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPitch(this AudioSource target, Single endValue, TweenSettings settings) => AudioPitch(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween AudioPitch(this AudioSource target, Single startValue, Single endValue, TweenSettings settings) => AudioPitch(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween AudioPitch(this AudioSource target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as AudioSource;
            var val = _tween.FloatVal;
            _target.pitch = val;
        }, t => (t.target as AudioSource).pitch.ToContainer(), TweenType.AudioPitch);
    }
    #endregion
    #region AudioPanStereo
    public static W_Tween AudioPanStereo(this AudioSource target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPanStereo(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPanStereo(this AudioSource target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPanStereo(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPanStereo(this AudioSource target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPanStereo(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPanStereo(this AudioSource target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0, bool useUnscaledTime = false)
        => AudioPanStereo(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, useUnscaledTime)));
    public static W_Tween AudioPanStereo(this AudioSource target, Single endValue, TweenSettings settings) => AudioPanStereo(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween AudioPanStereo(this AudioSource target, Single startValue, Single endValue, TweenSettings settings) => AudioPanStereo(target, new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween AudioPanStereo(this AudioSource target, TweenSettings<float> settings)
    {
        return TweenAnimateExtensions.Animate(target, ref settings, _tween =>
        {
            var _target = _tween.target as AudioSource;
            var val = _tween.FloatVal;
            _target.panStereo = val;
        }, t => (t.target as AudioSource).panStereo.ToContainer(), TweenType.AudioPanStereo);
    }
    #endregion
}