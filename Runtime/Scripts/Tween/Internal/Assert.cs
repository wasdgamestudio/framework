using UnityEngine;
internal static class Assert
{
    internal static void LogError(string msg, long id, Object context = null)
    {
        Debug.LogError(TryAddStackTrace(msg, id), context);
    }

    internal static void LogWarning(string msg, long id, Object context = null)
    {
        Debug.LogWarning(TryAddStackTrace(msg, id), context);
    }

    static string TryAddStackTrace(string msg, long tweenId)
    {
        return msg;
    }

    internal static void IsTrue(bool condition, long? tweenId = null, string msg = null) => UnityEngine.Assertions.Assert.IsTrue(condition, AddStackTrace(!condition, msg, tweenId));
    internal static void AreEqual<T>(T expected, T actual, string msg = null) => UnityEngine.Assertions.Assert.AreEqual(expected, actual, msg);
    internal static void AreNotEqual<T>(T expected, T actual, string msg = null) => UnityEngine.Assertions.Assert.AreNotEqual(expected, actual, msg);
    internal static void IsFalse(bool condition, string msg = null) => UnityEngine.Assertions.Assert.IsFalse(condition, msg);
    internal static void IsNotNull<T>(T value, string msg = null) where T : class => UnityEngine.Assertions.Assert.IsNotNull(value, msg);
    internal static void IsNull<T>(T value, string msg = null) where T : class => UnityEngine.Assertions.Assert.IsNull(value, msg);
    static string AddStackTrace(bool add, string msg, long? tweenId)
    {
        if(add && tweenId.HasValue)
        {
            return TryAddStackTrace(msg, tweenId.Value);
        }
        return msg;
    }
}