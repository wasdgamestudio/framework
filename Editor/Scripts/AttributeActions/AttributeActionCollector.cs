﻿using System.Collections.Generic;
using System.Reflection;
using Type = System.Type;
using UnityEngine;

internal static class AttributeActionCollector
{
    private static Dictionary<Type, IAttributeAction> actions;
    private static HashSet<IAttributeAction> usedActions;
    private static List<Type> missingActions;

    public static HashSet<IAttributeAction> UsedActions => usedActions;

    static AttributeActionCollector()
    {
        actions = new Dictionary<Type, IAttributeAction>();
        missingActions = new List<Type>();
        usedActions = new HashSet<IAttributeAction>();

        var EHandlesAssembly = Assembly.GetExecutingAssembly();
        CollectActionsInAssembly(EHandlesAssembly);
    }

    private static void CollectActionsInAssembly(Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            var baseType = type.BaseType;
            if (baseType == null) continue;
            if (!baseType.IsGenericType) continue;
            if (baseType.GetGenericTypeDefinition() != typeof(AttributeAction<>)) continue;

            var attributeType = baseType.GetGenericArguments()[0];
            var action = System.Activator.CreateInstance(type) as IAttributeAction;
            actions.Add(attributeType, action);
        }
    }

    /// <summary>
    /// There is only one Instance for a type.
    /// </summary>
    public static IAttributeAction GetAction(Type type)
    {
        if (actions.TryGetValue(type, out var action))
        {
            usedActions.Add(action);
            return action;
        }
        else if (!missingActions.Contains(type))
        {
            missingActions.Add(type);

            string msg = $"The AttributeAction of {type} is missing!\n\n" +
                "> Case 1: There is no action class for that.\n" +
                "> Case 2: The action class is not in the (Assets/ScriptBoy/EHandles Attributes v2/Scripts/Editor) folder.";
            Debug.LogWarning(msg);
        }

        return null;
    }
}