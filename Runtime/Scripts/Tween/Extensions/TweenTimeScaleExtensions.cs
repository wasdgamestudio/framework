using System;
using UnityEngine;
public static class TweenTimeScaleExtensions
{
    #region GlobalTimeScale
    public static W_Tween TimeScale(this Time target, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0)
       => TimeScale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, true)));
    public static W_Tween TimeScale(this Time target, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0)
        => TimeScale(target, new TweenSettings<float>(endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, true)));
    public static W_Tween TimeScale(this Time target, Single startValue, Single endValue, float duration, W_Ease ease = W_Ease.Default, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0)
        => TimeScale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, true)));
    public static W_Tween TimeScale(this Time target, Single startValue, Single endValue, float duration, W_Easing ease, int loops = 1, W_LoopMode loopMode = W_LoopMode.Restart, float startDelay = 0, float endDelay = 0)
        => TimeScale(target, new TweenSettings<float>(startValue, endValue, new TweenSettings(duration, ease, loops, loopMode, startDelay, endDelay, true)));
    public static W_Tween TimeScale(this Time target, Single endValue, TweenSettings settings) => TimeScale(target, new TweenSettings<float>(endValue, settings));
    public static W_Tween TimeScale(this Time target, Single startValue, Single endValue, TweenSettings settings) => TimeScale(target,new TweenSettings<float>(startValue, endValue, settings));
    public static W_Tween TimeScale(this Time target, TweenSettings<float> settings)
    {
        clampTimescale(ref settings.startValue);
        clampTimescale(ref settings.endValue);
        if(!settings.settings.useUnscaledTime)
        {
            Debug.LogWarning("Setting " + nameof(TweenSettings.useUnscaledTime) + " to true to animate Time.timeScale correctly.");
            settings.settings.useUnscaledTime = true;
        }
        return TweenAnimateExtensions.Animate(TweenManager.dummyTarget, ref settings, t => Time.timeScale = t.FloatVal, _ => Time.timeScale.ToContainer(), TweenType.GlobalTimeScale);

        void clampTimescale(ref float value)
        {
            if(value < 0)
            {
                Debug.LogError($"timeScale should be >= 0, but was {value}");
                value = 0;
            }
        }
    }
    #endregion  
}