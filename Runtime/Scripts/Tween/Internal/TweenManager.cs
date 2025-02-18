using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
#if UNITY_EDITOR
using UnityEditor;
#endif

internal class TweenManager : TickBehaviour
{
    internal static TweenManager Instance;
#if UNITY_EDITOR
    static bool isHotReload = true;
#endif
    internal static int customInitialCapacity = -1;

    /// Item can be null if the list is accessed from the <see cref="ReusableTween.UpdateAndCheckIfRunning"/> via onValueChange() or onComplete()
    /// Changing list to array gives about 8% performance improvement and is possible to do in the future
    ///     The current implementation is simpler and TweenManagerInspector can draw tweens with no additional code
    [SerializeField] internal List<ReusableTween> tweens;
    [SerializeField] internal List<ReusableTween> fixedUpdateTweens;
    [NonSerialized] internal List<ReusableTween> pool;
    /// startValue can't be replaced with 'W_Tween lastTween'
    /// because the lastTween may already be dead, but the tween before it is still alive (count >= 1)
    /// and we can't retrieve the startValue from the dead lastTween
    internal Dictionary<(Transform, TweenType), (ValueContainer startValue, int count)> shakes;
    internal int currentPoolCapacity { get; private set; }
    internal int maxSimultaneousTweensCount { get; private set; }

    [HideInInspector]
    internal long lastId = 1;
    internal W_Ease defaultEase = W_Ease.OutQuad;
    internal const W_Ease defaultShakeEase = W_Ease.OutQuad;  
    internal bool validateCustomCurves = true;
    internal bool warnEndValueEqualsCurrent = true;
    int processedCount;
    internal int updateDepth;
    internal static readonly object dummyTarget = new object();

    const string manualInstanceCreationIsNotAllowedMessage = "Please don't create the " + nameof(TweenManager) + " instance manually.";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
#if UNITY_EDITOR
        isHotReload = false;
#endif
        Assert.IsNull(Instance);
        var go = new GameObject(nameof(TweenManager));
        DontDestroyOnLoad(go);
        var instance = go.AddComponent<TweenManager>();
        const int defaultInitialCapacity = 200;
        instance.Init(customInitialCapacity != -1 ? customInitialCapacity : defaultInitialCapacity);
        Instance = instance;
    }

#if UNITY_EDITOR
    [InitializeOnLoadMethod]
    static void InitOnLoad()
    {
        EditorApplication.playModeStateChanged += state =>
        {
            if(state == PlayModeStateChange.EnteredEditMode)
            {
                Instance = null;
                customInitialCapacity = -1;
            }
        };
        if(!isHotReload)
        {
            return;
        }
        if(!Application.isPlaying)
        {
            return;
        }
        Assert.IsNull(Instance);
        var foundInScene =
                FindAnyObjectByType<TweenManager>();
        Assert.IsNotNull(foundInScene);
        var count = foundInScene.tweensCount;
        if(count > 0)
        {
            Debug.Log($"All tweens ({count}) were stopped because of 'Recompile And Continue Playing'.");
        }
        foundInScene.Init(foundInScene.currentPoolCapacity);
        Instance = foundInScene;
    }

    void Reset()
    {
        Assert.IsFalse(Application.isPlaying);
        Debug.LogError(manualInstanceCreationIsNotAllowedMessage);
        DestroyImmediate(this);
    }
#endif

    void Init(int capacity)
    {
        tweens = new List<ReusableTween>(capacity);
        fixedUpdateTweens = new List<ReusableTween>(capacity);
        pool = new List<ReusableTween>(capacity);
        for(int i = 0; i < capacity; i++)
        {
            pool.Add(new ReusableTween());
        }
        shakes = new Dictionary<(Transform, TweenType), (ValueContainer, int)>(capacity);
        currentPoolCapacity = capacity;
    }

    protected override void Awake()
    {
        base.Awake();
        Assert.IsNull(Instance, manualInstanceCreationIsNotAllowedMessage);
    }

    void Start()
    {
        Assert.AreEqual(Instance, this, manualInstanceCreationIsNotAllowedMessage);
    }
    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        TweensUpdate(fixedUpdateTweens, Time.fixedDeltaTime, Time.fixedUnscaledDeltaTime, out _);
    }
    /// <summary>
    /// The most common tween lifecycle:
    /// 1. User's script creates a tween in Update() in frame N.
    /// 2. TweenManager.LateUpdate() applies the 'startValue' to the tween in the SAME FRAME N. This guarantees that the animation is rendered at the 'startValue' in the same frame the tween is created.
    /// 3. TweenManager.Update() executes the first animation step on frame N+1. TweenManager's execution order is -2000, this means that
    ///     all tweens created in previous frames will already be updated before user's script Update() (if user's script execution order is greater than -2000).
    /// 4. TweenManager.Update() completes the tween on frame N+(Duration*targetFrameRate) given that targetFrameRate is stable.
    /// </summary>

    public override void OnUpdate()
    {
        base.OnUpdate();
        TweensUpdate(tweens, Time.deltaTime, Time.unscaledDeltaTime, out processedCount);
    }

    public override void OnLateUpdate()
    {
        base.OnLateUpdate();
        updateDepth++;
        var cachedCount = tweens.Count;
        for(int i = processedCount; i < cachedCount; i++)
        {
            var tween = tweens[i];
            if(tween._isAlive && !tween.startFromCurrent && tween.settings.startDelay == 0 && !tween.IsUnityTargetDestroyed() && !tween.isAdditive
                && tween.CanManipulate()
                && tween.elapsedTimeTotal == 0f)
            {
                Assert.AreEqual(0f, tween.elapsedTimeTotal);
                tween.SetElapsedTimeTotal(0f);
            }
        }
        updateDepth--;
    }


    void TweensUpdate(List<ReusableTween> tweens, float deltaTime, float unscaledDeltaTime, out int processedCount)
    {
        if(updateDepth != 0)
        {
            throw new Exception("updateDepth != 0");
        }
        updateDepth++;
        // onComplete and onValueChange can create new tweens. Cache count to process only those tweens that were present when the update started
        var oldCount = tweens.Count;
        var numRemoved = 0;
        // Process tweens in the order of creation.
        // This allows to create tween duplicates because the latest tween on the same value will overwrite the previous ones.
        for(int i = 0; i < oldCount; i++)
        {
            var tween = tweens[i];
            var newIndex = i - numRemoved;
            if(tween.UpdateAndCheckIfRunning(tween.settings.useUnscaledTime ? unscaledDeltaTime : deltaTime))
            {
                if(i != newIndex)
                {
                    tweens[i] = null;
                    tweens[newIndex] = tween;
                }
                continue;
            }
            ReturnTweenToPool(tween);
            tweens[i] = null; // set to null after releaseTweenToPool() so in case of an exception, the tween will stay inspectable via Inspector
            numRemoved++;
        }
        processedCount = oldCount - numRemoved;
        updateDepth--;
        if(numRemoved == 0)
        {
            return;
        }
        var newCount = tweens.Count;
        for(int i = oldCount; i < newCount; i++)
        {
            var tween = tweens[i];
            var newIndex = i - numRemoved;
#if SAFETY_CHECKS
                Assert.IsNotNull(tween);
#endif
            tweens[newIndex] = tween;
        }
        tweens.RemoveRange(newCount - numRemoved, numRemoved);
        Assert.AreEqual(tweens.Count, newCount - numRemoved);
    }
    void ReturnTweenToPool(ReusableTween tween)
    {
        tween.Reset();
        pool.Add(tween);
    }

    /// Returns null if target is a destroyed UnityEngine.Object
    internal static W_Tween? DelayWithoutDurationCheck(object target, float duration, bool useUnscaledTime)
    {
        var tween = FetchTween();
        tween.setPropType(PropType.Float);
        var settings = new TweenSettings
        {
            Duration = duration,
            EaseType = W_Ease.Linear,
            useUnscaledTime = useUnscaledTime
        };
        tween.Setup(target, ref settings, _ => { }, null, false, TweenType.Delay);
        var result = AddTween(tween);
        // ReSharper disable once RedundantCast
        return result.IsCreated ? result : (W_Tween?)null;
    }

    internal static ReusableTween FetchTween()
    {
        return Instance.FetchTweenInternal();
    }

    ReusableTween FetchTweenInternal()
    {
        ReusableTween result;
        if(pool.Count == 0)
        {
            result = new ReusableTween();
            if(tweensCount + 1 > currentPoolCapacity)
            {
                var newCapacity = currentPoolCapacity == 0 ? 4 : currentPoolCapacity * 2;               
                currentPoolCapacity = newCapacity;
            }
        }
        else
        {
            var lastIndex = pool.Count - 1;
            result = pool[lastIndex];
            pool.RemoveAt(lastIndex);
        }
        Assert.AreEqual(-1, result.id);
        result.id = lastId;
        return result;
    }

    public static W_Tween Animate(ReusableTween tween)
    {
        return AddTween(tween);
    }

    internal static W_Tween AddTween(ReusableTween tween)
    {
        return Instance.AddTweenInternal(tween);
    }

    W_Tween AddTweenInternal(ReusableTween tween)
    {
        Assert.IsNotNull(tween);
        Assert.IsTrue(tween.id > 0);
        if(tween.target == null || tween.IsUnityTargetDestroyed())
        {           
            tween.Kill();
            ReturnTweenToPool(tween);
            return default;
        }       

        if(tween.settings.UseFixedUpdate)
        {
            fixedUpdateTweens.Add(tween);
        }
        else
        {
            tweens.Add(tween);
        }
        lastId++; // increment only when tween added successfully
        return new W_Tween(tween);
    }

    internal static int ProcessAll(object onTarget, Predicate<ReusableTween> predicate, bool allowToProcessTweensInsideSequence)
    {
        return Instance.ProcessAllInternal(onTarget, predicate, allowToProcessTweensInsideSequence);
    }

    internal static bool LogCantManipulateError = true;

    int ProcessAllInternal(object onTarget, Predicate<ReusableTween> predicate, bool allowToProcessTweensInsideSequence)
    {
        return processInList(tweens) + processInList(fixedUpdateTweens);
        int processInList(List<ReusableTween> tweens)
        {
            int numProcessed = 0;
            int totalCount = 0;
            var count = tweens.Count; // this is not an optimization, OnComplete() may create new tweens
            for(var i = 0; i < count; i++)
            {
                var tween = tweens[i];
                if(tween == null)
                {
                    continue;
                }
                totalCount++;
                if(onTarget != null)
                {
                    if(tween.target != onTarget)
                    {
                        continue;
                    }
                    if(!allowToProcessTweensInsideSequence && tween.IsInSequence())
                    {                      
                        Assert.IsFalse(tween.IsMainSequenceRoot());                       
                        continue;
                    }
                }
                if(tween._isAlive && predicate(tween))
                {
                    numProcessed++;
                }
            }
            if(onTarget == null)
            {
                return totalCount;
            }
            return numProcessed;
        }
    }

    internal void SetTweensCapacity(int capacity)
    {
        var runningTweens = tweensCount;
        if(capacity < runningTweens)
        {
            Debug.LogError($"New capacity ({capacity}) should be greater than the number of currently running tweens ({runningTweens})");
            return;
        }
        tweens.Capacity = capacity;
        fixedUpdateTweens.Capacity = capacity;
        shakes.EnsureCapacity(capacity);
        ResizeAndSetCapacity(pool, capacity - runningTweens, capacity);
        currentPoolCapacity = capacity;
        Assert.AreEqual(capacity, tweens.Capacity);
        Assert.AreEqual(capacity, fixedUpdateTweens.Capacity);
        Assert.AreEqual(capacity, pool.Capacity);
    }

    internal int tweensCount => tweens.Count + fixedUpdateTweens.Count;

    internal static void ResizeAndSetCapacity(List<ReusableTween> list, int newCount, int newCapacity)
    {
        Assert.IsTrue(newCapacity >= newCount);
        int curCount = list.Count;
        if(curCount > newCount)
        {
            var numToRemove = curCount - newCount;
            list.RemoveRange(newCount, numToRemove);
            list.Capacity = newCapacity;
        }
        else
        {
            list.Capacity = newCapacity;
            if(newCount > curCount)
            {
                var numToCreate = newCount - curCount;
                for(int i = 0; i < numToCreate; i++)
                {
                    list.Add(new ReusableTween());
                }
            }
        }
        Assert.AreEqual(newCount, list.Count);
        Assert.AreEqual(newCapacity, list.Capacity);
    }
}