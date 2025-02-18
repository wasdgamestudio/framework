using System;
using System.Collections;
using System.Linq;

public partial struct W_Tween : IEnumerator
{
    /// <summary>Use this method to wait for a W_Tween in coroutines.</summary>
    /// <example><code>
    /// IEnumerator Coroutine() {
    ///     yield return W_Tween.Delay(1).ToYieldInstruction();
    /// }
    /// </code></example>
    public IEnumerator ToYieldInstruction()
    {
        if(!IsAlive || !TryManipulate())
        {
            return Enumerable.Empty<object>().GetEnumerator();
        }
        var result = tween.coroutineEnumerator;
        result.SetTween(this);
        return result;
    }

    bool IEnumerator.MoveNext()
    {
        return IsAlive;
    }

    object IEnumerator.Current
    {
        get
        {
            Assert.IsTrue(IsAlive);
            return null;
        }
    }

    void IEnumerator.Reset() => throw new NotSupportedException();
}

public partial struct W_Sequence : IEnumerator
{
    /// <summary>Use this method to wait for a W_Sequence in coroutines.</summary>
    /// <example><code>
    /// IEnumerator Coroutine() {
    ///     var sequence = W_Sequence.Create(W_Tween.Delay(1)).ChainCallback(() =&gt; Debug.Log("Done!"));
    ///     yield return sequence.ToYieldInstruction();
    /// }
    /// </code></example>
    public IEnumerator ToYieldInstruction() => root.ToYieldInstruction();

    bool IEnumerator.MoveNext()
    {
        return isAlive;
    }

    object IEnumerator.Current
    {
        get
        {
            Assert.IsTrue(isAlive);
            return null;
        }
    }

    void IEnumerator.Reset() => throw new NotSupportedException();
}

internal class TweenCoroutineEnumerator : IEnumerator
{
    W_Tween tween;
    bool isRunning;

    internal void SetTween(W_Tween _tween)
    {
        Assert.IsFalse(isRunning);
        Assert.IsTrue(!tween.IsCreated || tween.Id == _tween.Id);
        Assert.IsTrue(_tween.IsAlive);
        tween = _tween;
        isRunning = true;
    }

    bool IEnumerator.MoveNext()
    {
        var result = tween.IsAlive;
        if(!result)
        {
            resetEnumerator();
        }
        return result;
    }

    internal void resetEnumerator()
    {
        tween = default;
        isRunning = false;
    }

    object IEnumerator.Current
    {
        get
        {
            Assert.IsTrue(tween.IsAlive);
            Assert.IsTrue(isRunning);
            return null;
        }
    }
    void IEnumerator.Reset() => throw new NotSupportedException();
}