using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ServiceConfig : ScriptableObject
{
    public List<ServiceType> Services = new List<ServiceType>();
    static string baseGitUrl = "https://gitlab.com/api_lib/service-";
    private static string manifestPath = "Packages/manifest.json";
    public static ServiceConfig Get()
    {
        string dir = "Assets/Editor Default Resources";
        string file = "ServiceConfig.asset".ToPlatformName();
        string path = Path.Combine(dir, file);
        if(!System.IO.Directory.Exists(dir))
        {
            System.IO.Directory.CreateDirectory(dir);
        }
        if(File.Exists(path))
        {
            return AssetDatabase.LoadAssetAtPath<ServiceConfig>(path);
        }
        else
        {
            var config = CreateInstance<ServiceConfig>();
            AssetDatabase.CreateAsset(CreateInstance<ServiceConfig>(), path);
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return config;
        }
    }
    private void OnEnable()
    {
        ReloadPackages();
    }

    public void ReloadPackages()
    {
        Services = new List<ServiceType>();

        if(File.Exists(manifestPath))
        {
            string manifestContent = File.ReadAllText(manifestPath);

            string[] names = Enum.GetNames(typeof(ServiceType));
            foreach(string name in names)
            {
                if(name == "None")
                {
                    continue;
                }
                string urlGit = baseGitUrl + name.ToLower();
                if(manifestContent.Contains($"{urlGit}"))
                {
                    //Debug.Log($"Service {name} installed");
                    Services.Add((ServiceType)Enum.Parse(typeof(ServiceType), name));
                }
            }
        }
    }

    public void AddService(ServiceType service)
    {
        string packageURL = $"{baseGitUrl}{service.ToString().ToLower()}.git";
        string packageName = $"com.wasd.{service.ToString().ToLower()}";

        Debug.Log($"Start adding service: {service}");

        if(!File.Exists(manifestPath))
        {
            Debug.LogError("manifest.json not found!");
            return;
        }

        string manifestContent = File.ReadAllText(manifestPath);
        var jvalue = JObject.Parse(manifestContent);
        var dependencies = jvalue["dependencies"] as JObject;
        var scopedRegistries=jvalue["scopedRegistries"] as JArray;
        if(scopedRegistries == null)
        {
            scopedRegistries = new JArray();
            jvalue["scopedRegistries"] = scopedRegistries;
            JToken googleEDM = JObject.Parse("{\"name\":\"package.openupm.com\",\"url\":\"https://package.openupm.com\",\"scopes\":[\"com.google.external-dependency-manager\"]}");
            scopedRegistries.Add(googleEDM);
        }

        if(dependencies.ContainsKey(packageName))
        {
            Debug.LogWarning($"Package {packageName} already exists in manifest.json. Skipping...");
        }
        else
        {
            dependencies[packageName] = "git+" + packageURL;
            if(service == ServiceType.Firebase)
            {
                if(!dependencies.ContainsKey("com.google.firebase.analytics"))
                {
                    dependencies["com.google.firebase.analytics"] = "git+https://gitlab.com/firebase5420204/analytics.git";
                }
                if(!dependencies.ContainsKey("com.google.firebase.app"))
                {
                    dependencies["com.google.firebase.app"] = "git+https://gitlab.com/firebase5420204/app-core.git";
                }
                if(!dependencies.ContainsKey("com.google.firebase.crashlytics"))
                {
                    dependencies["com.google.firebase.crashlytics"] = "git+https://gitlab.com/firebase5420204/crashlytics.git";
                }
               if(!dependencies.ContainsKey("com.google.firebase.remote-config"))
                {
                    dependencies["com.google.firebase.remote-config"] = "git+https://gitlab.com/firebase5420204/remote-config.git";
                } 
            }
            File.WriteAllText(manifestPath, jvalue.ToString());
            Debug.Log($"Added {packageName} from {packageURL}");
            RefreshPackageManager();
        }
    }
    public void RemoveService(ServiceType service)
    {
        // string packageURL = $"{url}{service.ToString().ToLower()}.git";
        Client.Remove($"com.wasd.{service.ToString().ToLower()}");
    }
    private static void RefreshPackageManager()
    {
        Debug.Log("Refreshing Unity Package Manager...");
        Client.Resolve();
    }
}
