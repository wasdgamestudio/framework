using UnityEngine;

public static partial class TweenConfig
{
    internal static TweenManager Instance
    {
        get
        {
            return TweenManager.Instance;
        }
    }
   
    public static void SetTweensCapacity(int capacity)
    {
        Assert.IsTrue(capacity >= 0);
        var instance = TweenManager.Instance; // should use TweenManager.Instance because Instance property has a built-in null check 
        if(instance == null)
        {
            TweenManager.customInitialCapacity = capacity;
        }
        else
        {
            instance.SetTweensCapacity(capacity);
        }
    }

    public static W_Ease DefaultEase
    {
        get => Instance.defaultEase;
        set
        {
            if(value == W_Ease.Custom || value == W_Ease.Default)
            {
                Debug.LogError("defaultEase can't be Ease.Custom or Ease.Default.");
                return;
            }
            Instance.defaultEase = value;
        }
    } 

    internal const bool DefaultUseUnscaledTimeForShakes = false;
}