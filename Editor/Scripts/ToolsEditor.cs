using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolsEditor : Editor
{
    [MenuItem("WASD/Settings #S", priority =0)]
    static void OpenSetting()
    {
        SettingsService.OpenProjectSettings(PathEditor.MENU_PATH_INFO);
    }
    [MenuItem("WASD/Tools/Find Large Files Size >100M #F")]
    static void Find()
    {
        var files = ExtensionsEditor.FindLargeFiles(Application.dataPath, 100);
        if (files.Count == 0)
        {
            Debug.Log("No large files found!");
        }
        foreach (var item in files)
        {
            Debug.LogError(item);
        }
    }
    [MenuItem("WASD/Tools/Remove Missing Scripts In Scene")]
    static void RemoveMissingScripts()
    {
        ExtensionsEditor.RemoveMissingScriptsInScene();
    }
}
