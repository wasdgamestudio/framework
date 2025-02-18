using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RemoteConfig : ScriptableObject
{
    public static string PathJson => ExtensionsEditor.GetResourcesPath("RemoteConfig.json".ToPlatformName());
    public static string PathKey=>Path.Combine(dirKey, "key.json".ToPlatformName().ToLower());
    public static string dirKey => "remoteconfig_key.json";

    public static RemoteConfig Get()
    {      
        if(!Directory.Exists(dirKey))
        {
            Directory.CreateDirectory(dirKey);
            Debug.Log("Create folder remoteconfig_key.json");
        }
        if(!File.Exists(PathKey))
            File.WriteAllText(PathKey, "{}");
        if(File.Exists(PathJson) == false)
        {
            if(Directory.Exists(ExtensionsEditor.DirResources) == false)
                Directory.CreateDirectory(ExtensionsEditor.DirResources);
            File.WriteAllText(RemoteConfig.PathJson, "{}");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        string file = "RemoteConfig".ToPlatformName();
        var config = Resources.Load<RemoteConfig>(file);
        if(config != null) return config;
        string dir = ExtensionsEditor.DirEditorResources;
        file += ".asset";
        string path = System.IO.Path.Combine(dir, file);
        if(!System.IO.Directory.Exists(dir))
        {
            System.IO.Directory.CreateDirectory(dir);
        }
        if(System.IO.File.Exists(path))
        {
            return AssetDatabase.LoadAssetAtPath<RemoteConfig>(path);
        }
        else
        {
            config = CreateInstance<RemoteConfig>();
            AssetDatabase.CreateAsset(CreateInstance<RemoteConfig>(), path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return config;
        }
    }
}