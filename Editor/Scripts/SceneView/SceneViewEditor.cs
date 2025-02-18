using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class SceneViewEditor
{
    /// <summary>
    /// Should the scene view be used.
    /// </summary>
    private static bool UseToolboxSceneView { get; set; } = true;

    static SceneViewEditor()
    {
        UpdateEventCallback();
    }

    private static List<GameObject> GetObjectsUnderCursor()
    {
        const int maxIterations = 50;

        var mousePosition = Event.current.mousePosition;
        var hitObjects = new List<GameObject>();
        GameObject[] hitObjectsArray;
        for(var i = 0; i < maxIterations; i++)
        {
            hitObjectsArray = hitObjects.ToArray();

            var go = HandleUtility.PickGameObject(mousePosition, false, hitObjectsArray);
            if(go == null)
            {
                break;
            }

            hitObjects.Add(go);
        }

        return hitObjects;
    }

    private static void UpdateEventCallback()
    {
        UnityEditor.SceneView.duringSceneGui -= SceneViewDuringSceneGui;

        if(UseToolboxSceneView)
        {
            UnityEditor.SceneView.duringSceneGui += SceneViewDuringSceneGui;
        }
    }

    private static void SceneViewDuringSceneGui(UnityEditor.SceneView sceneView)
    {
        if(Event.current.type != EventType.KeyDown || !IsSelectorKey())
        {
            return;
        }

        var objectsUnderCursor = GetObjectsUnderCursor();
        if(objectsUnderCursor.Count > 0)
        {
            SceneViewObjectSelector.Show(objectsUnderCursor, Event.current.mousePosition + sceneView.position.position);
        }
    }
    static bool IsSelectorKey()
    {
        return Event.current.keyCode == KeyCode.Tab;
    }
}