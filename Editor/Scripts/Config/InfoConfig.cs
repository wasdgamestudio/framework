using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class InfoConfig : ScriptableObject
{
    public static string PathJson => ExtensionsEditor.GetResourcesPath("Info.json".ToPlatformName());
    public string Name = "";
    public string PackageName = "";
    public string UrlPolicy = "";
    public string UrlTerms = "";
    public string SDKMax = "";
    public string AppID = "";
    public string AppOpen = "";
    public string Banner = "";
    public string Interstitial = "";
    public string Rewarded = "";
    public List<AdMediation> Mediations = new List<AdMediation>();

    public static InfoConfig Get()
    {
        if(File.Exists(PathJson) == false)
        {
            if(Directory.Exists(ExtensionsEditor.DirResources) == false)
                Directory.CreateDirectory(ExtensionsEditor.DirResources);
            File.WriteAllText(PathJson, "{}");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        string dir = "Assets/Editor Default Resources";
        string file = "InfoConfig.asset".ToPlatformName();
        string path = System.IO.Path.Combine(dir, file);
        if(!System.IO.Directory.Exists(dir))
        {
            System.IO.Directory.CreateDirectory(dir);
        }
        if(System.IO.File.Exists(path))
        {
            return AssetDatabase.LoadAssetAtPath<InfoConfig>(path);
        }
        else
        {
            var config = CreateInstance<InfoConfig>();
            AssetDatabase.CreateAsset(CreateInstance<InfoConfig>(), path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return config;
        }
    }
    public void AddKeyValue(string key, string value)
    {
        if(string.IsNullOrEmpty(key)) return;
        JObject jObject= JObject.Parse(File.ReadAllText(PathJson));
        if(jObject.ContainsKey(key))
        {
            jObject[key] = value;
        }
        else
        {
            jObject.Add(key, value);
        }
        File.WriteAllText(PathJson, jObject.ToString());
    }
}

public enum AdMediation
{
    _ = 0,
    InMobi = 1,
    Liftoff_Vungle = 2,
    Mintegral = 3,
    AdMob = 4,
    IronSource = 5,
    UnityAds = 6,
    GoogleBidding = 7,
    Facebook = 8,
    BidMachine = 9,
    Chartboost = 10,
    CSJ = 11,
    DTExchange = 12,
    HyprMX = 13,
    LINE = 14,
    Maio = 15,
    MobileFuse = 16,
    Moloco = 17,
    Ogury = 18,
    Pangle = 19,
    Smaato = 20,
    Tencent = 21,
    Verve = 22,
    VKAdNetwork = 23,
    Yandex = 24,
    YSONetwork = 25,
    Fyber = 26,
}