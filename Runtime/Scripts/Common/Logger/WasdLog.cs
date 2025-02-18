using UnityEngine;

public static class Wasd
{
    private const string RED = "\x1b[31m";
    private const string GREEN = "\x1b[32m";
    private const string YELLOW = "\x1b[33m";
    private const string BLUE = "\x1b[34m";
    private const string CYAN = "\x1b[36m";
    private const string RESET = "\x1b[0m";
    public static void Log(object message, string title = "")
    {

#if UNITY_EDITOR
        if(title != "")
            Debug.Log($"<color=green>[WASD]</color> |<color=#FFA500>{title}</color>| {message}");
        else
            Debug.Log($"<color=green>[WASD]</color> {message}");
#elif UNITY_IOS
        if(title != "")
            Debug.Log($"{GREEN}[WASD] |{title}| {message}");
        else
            Debug.Log($"{GREEN}[WASD] {message}");
#else
        Debug.Log($"[WASD] {message}");
#endif
    }
    public static void LogStateInitialize(string service)
    {
#if UNITY_EDITOR
        Debug.Log($"<color=green>[WASD]</color> |<color=#FFA500>{service}</color>| Initialized!");
#elif UNITY_IOS
        Debug.Log($"{GREEN}[WASD] |{service}| Initialized!");
#else
        Debug.Log($"[WASD] |{service}| Initialized!");
#endif
    }
    public static void LogWarning(object message)
    {
#if UNITY_EDITOR
        Debug.LogWarning($"<color=yellow>[WASD]</color> {message}");
#elif UNITY_IOS
        Debug.LogWarning($"{YELLOW}[WASD] {message}");
#else
        Debug.LogWarning($"[WASD] {message}");
#endif
    }
    public static void LogError(object message)
    {
#if UNITY_EDITOR
        Debug.LogError($"<color=red>[WASD]</color> {message}");
#elif UNITY_IOS
        Debug.LogError($"{RED}[WASD] {message}");
#else
        Debug.LogError($"[WASD] {message}");
#endif
    }
}
