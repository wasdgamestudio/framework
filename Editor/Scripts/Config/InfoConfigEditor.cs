using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InfoConfig))]
public class InfoConfigEditor : Editor
{
    InfoConfig config;
    JObject TextInfo;
    bool useAdjust;
    bool useAppsflyer;
    string adjustAppToken;
    string appsflyerAppID;
    string appsflyerDevKey;
    bool groupInfo = true;
    bool groupTracking = true;
    bool groupMediation = true;

    void OnEnable()
    {
        config = target as InfoConfig;
        var info = Resources.Load<TextAsset>("Info".ToPlatformName());
        if(info != null)
        {
            TextInfo = JObject.Parse(info.text);

            if(config != null)
            {
                if(TextInfo.TryGetValue(nameof(config.Name), out var name))
                {
                    config.Name = name.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.PackageName), out var packageName))
                {
                    config.PackageName = packageName.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.SDKMax), out var sdkmax))
                {
                    config.SDKMax = sdkmax.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.AppID), out var appId))
                {
                    config.AppID = appId.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.AppOpen), out var appOpenAd))
                {
                    config.AppOpen = appOpenAd.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.Banner), out var banner))
                {
                    config.Banner = banner.ToString();
                }

                if(TextInfo.TryGetValue(nameof(config.Interstitial), out var interstitial))
                {
                    config.Interstitial = interstitial.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.Rewarded), out var rewarded))
                {
                    config.Rewarded = rewarded.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.UrlPolicy), out var policy))
                {
                    config.UrlPolicy = policy.ToString();
                }
                if(TextInfo.TryGetValue(nameof(config.UrlTerms), out var terms))
                {
                    config.UrlTerms = terms.ToString();
                }
            }
            if(TextInfo.ContainsKey(ServiceParameters.ADJUST_APP_TOKEN))
            {
                useAdjust = true;
                adjustAppToken = TextInfo[ServiceParameters.ADJUST_APP_TOKEN].ToString();
            }
            if(TextInfo.ContainsKey(ServiceParameters.APPSFLYER_APP_ID))
            {
                useAppsflyer = true;
                appsflyerAppID = TextInfo[ServiceParameters.APPSFLYER_APP_ID].ToString();
                appsflyerDevKey = TextInfo[ServiceParameters.APPSFLYER_DEV_KEY].ToString();
            }
        }
    }

    public override void OnInspectorGUI()
    {
        if(config == null) return;
        if(GUILayout.Button("Open Google Sheet Info"))
        {
            GoogleSheetEditor.OpenWindow();
        }
        GUIStyle headerStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fixedWidth = 140,
            fontSize = 14,
            fontStyle = FontStyle.Bold,
            normal = { textColor = new Color(131f / 255f, 220 / 255f, 255f / 255f) }
        };
        GUIStyle contentStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fontSize = 14,
            fontStyle = FontStyle.Normal,
            normal = { textColor = Color.white },
            alignment = TextAnchor.MiddleLeft
        };
        GUIStyle trackingStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fontSize = 14,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.cyan },
            alignment = TextAnchor.MiddleLeft,
        };
        GUIStyle groupStyle = new GUIStyle(EditorStyles.foldout)
        {
            fontSize = 15,
            fontStyle = FontStyle.Bold,
            stretchWidth = false,
            alignment = TextAnchor.MiddleLeft
        };
        //base.OnInspectorGUI();
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(10));
        groupInfo = EditorGUILayout.BeginFoldoutHeaderGroup(groupInfo, "Information", groupStyle);
        if(groupInfo)
        {
            EditorGUILayout.BeginVertical();
            EditorGUIUtility.labelWidth = 120;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Product Name", headerStyle);
            EditorGUILayout.SelectableLabel(config.Name, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Package Name", headerStyle);
            EditorGUILayout.SelectableLabel(config.PackageName, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Url Policy", headerStyle);
            EditorGUILayout.SelectableLabel(config.UrlPolicy, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Url Terms", headerStyle);
            EditorGUILayout.SelectableLabel(config.UrlTerms, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("SDK Max", headerStyle);
            EditorGUILayout.SelectableLabel(config.SDKMax, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("App ID", headerStyle);
            EditorGUILayout.SelectableLabel(config.AppID, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("App Open Id", headerStyle);
            EditorGUILayout.SelectableLabel(config.AppOpen, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Banner Id", headerStyle);
            EditorGUILayout.SelectableLabel(config.Banner, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Interstitial Id", headerStyle);
            EditorGUILayout.SelectableLabel(config.Interstitial, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.SelectableLabel("Rewarded Id", headerStyle);
            EditorGUILayout.SelectableLabel(config.Rewarded, contentStyle);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(10));
        if(TextInfo != null)
        {
            EditorGUIUtility.labelWidth = 150;
            groupTracking = EditorGUILayout.BeginFoldoutHeaderGroup(groupTracking, "Tracking", groupStyle);
            if(groupTracking)
            {
                EditorGUI.BeginChangeCheck();
                if(useAdjust)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.SelectableLabel("Adjust App Token", headerStyle);
                    EditorGUILayout.SelectableLabel(adjustAppToken, trackingStyle);
                    EditorGUILayout.EndHorizontal();
                }
                if(useAppsflyer)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.SelectableLabel("Appsflyer App ID", headerStyle);
                    EditorGUILayout.SelectableLabel(appsflyerAppID, trackingStyle);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.SelectableLabel("Appsflyer Dev Key", headerStyle);
                    EditorGUILayout.SelectableLabel(appsflyerDevKey, trackingStyle);
                    EditorGUILayout.EndHorizontal();
                }
                if(EditorGUI.EndChangeCheck())
                {
                    SaveTracking();
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(10));
        }
        if(config.Mediations == null)
        {
            config.Mediations = new List<AdMediation>();
        }
        groupMediation = EditorGUILayout.BeginFoldoutHeaderGroup(groupMediation, "Mediations", groupStyle);
        if(groupMediation)
        {
            for(int i = 0; i < config.Mediations.Count; i++)
            {
                ShowMediation(config.Mediations[i]);
                GUILayout.Space(2);
            }

            GUILayout.Space(20);
            GUILayout.Label("Add Mediation:");
            GUILayout.BeginHorizontal();
            int index = 0;
            index = EditorGUILayout.Popup(index, GetMediationEnum().ToArray());
            AdMediation adMediation = NameToEnum(GetMediationEnum()[index]);
            if(adMediation != AdMediation._)
            {
                if(!config.Mediations.Contains(adMediation))
                {
                    config.Mediations.Add(adMediation);
                }
                adMediation = AdMediation._;
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
          
            string maxMediation = "MaxMediation";
            if(GUILayout.Button("Apply"))
            {
                EditorUtility.SetDirty(config);
                string methodInfo = "SetInfo";
                Type type = AppDomain.CurrentDomain.GetAssemblies()
                              .SelectMany(assembly => assembly.GetTypes())
                              .FirstOrDefault(t => t.Name == maxMediation);
                //Type type = Type.GetType(maxMediation);
                if(type != null)
                {
                    MethodInfo method = type.GetMethod(methodInfo);
                    method.Invoke(Activator.CreateInstance(type), null);
                }
                // MaxMediation.SetInfo(config);
                //config.ToJson();
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            if(config.Mediations != null && config.Mediations.Count > 0)
            {
                if(GUILayout.Button("Update All", GUILayout.Width(100)))
                {
                    Debug.Log("Update All");
                    Type type = AppDomain.CurrentDomain.GetAssemblies()
                               .SelectMany(assembly => assembly.GetTypes())
                               .FirstOrDefault(t => t.Name == maxMediation);
                    string methodName = "Upgraded";
                    // Type type = Type.GetType(maxMediation);
                    if(type != null)
                    {
                        MethodInfo method = type.GetMethod(methodName);
                        method.Invoke(Activator.CreateInstance(type), null);
                    }
                }
            }
            GUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        string msg = "";
        msg += "Version: " + PlayerSettings.bundleVersion;
        msg += "\n";
        msg += "Version Code: " + PlayerSettings.Android.bundleVersionCode;

        GUILayout.Label(msg);
    }
    public AdMediation NameToEnum(string name)
    {
        return Enum.Parse<AdMediation>(name);
    }
    public List<string> GetMediationEnum()
    {
        List<string> mediations = new List<string>();
        foreach(var item in System.Enum.GetValues(typeof(AdMediation)))
        {
            AdMediation adMediation = (AdMediation)item;
            if(!config.Mediations.Contains(adMediation))
                mediations.Add(item.ToString());
        }
        return mediations;
    }

    void ShowMediation(AdMediation adMediation)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Button(adMediation.ToString(), GUILayout.Width(300));
        if(GUILayout.Button("Remove", GUILayout.Width(100)))
        {
            config.Mediations.Remove(adMediation);
        }
        GUILayout.EndHorizontal();
    }

    void SaveTracking()
    {
        if(useAdjust)
        {
            TextInfo[ServiceParameters.ADJUST_APP_TOKEN] = adjustAppToken;
        }
        if(useAppsflyer)
        {
            TextInfo[ServiceParameters.APPSFLYER_APP_ID] = appsflyerAppID;
            TextInfo[ServiceParameters.APPSFLYER_DEV_KEY] = appsflyerDevKey;
        }
        string path = AssetDatabase.GetAssetPath(Resources.Load<TextAsset>("Info".ToPlatformName()));
        File.WriteAllText(path, TextInfo.ToString());
        AssetDatabase.Refresh();
    }
}