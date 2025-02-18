using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using TMPro;

public static class EditorExtensions
{
    public const string labelSlider = "Slider";
    public const string labelFont = "Wasd_Fonts";

    public static T[] FindAssets<T>(string label, params string[] names) where T : UnityEngine.Object
    {
        T[] array = new T[names.Length];
        string[] guids = AssetDatabase.FindAssets($"l:{label}");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string name = Path.GetFileNameWithoutExtension(path);
            for (int i = 0; i < names.Length; i++)
            {
                if (name == names[i])
                {
                    array[i] = AssetDatabase.LoadAssetAtPath<T>(path);
                    break;
                }
            }
        }
        return array;
    }

}
