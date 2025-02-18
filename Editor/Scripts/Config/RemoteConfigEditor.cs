using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

[CustomEditor(typeof(RemoteConfig))]
public class RemoteConfigEditor : Editor
{
    JObject remoteConfigData;
    private void OnEnable()
    {
        if(File.Exists(RemoteConfig.PathJson) == false)
        {
            File.WriteAllText(RemoteConfig.PathJson, "{}");
            LoadRemoteData();
        }
        else
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Culture = CultureInfo.InvariantCulture
            };
            string text = File.ReadAllText(RemoteConfig.PathJson);
            remoteConfigData = JsonConvert.DeserializeObject<JObject>(text, settings);
        }
    }
    bool isShowContentKey = false;
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        GUIStyle headerStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            fontSize = 14,
            fontStyle = FontStyle.Bold,
            normal = { textColor = new Color(131f / 255f, 220 / 255f, 255f / 255f) }
        };
        if(remoteConfigData != null)
        {
            EditorGUIUtility.labelWidth = 100;
            GUILayout.Label("Remote Config Data");
            foreach(var item in remoteConfigData)
            {
                GUILayout.BeginVertical();
                EditorGUILayout.SelectableLabel(item.Key, headerStyle);
                if(bool.TryParse(item.Value.ToString(), out bool result))
                {
                    GUILayout.TextArea(result.ToString());
                }
                else
                {
                    JToken.Parse(GUILayout.TextArea(item.Value.ToString()));
                    //GUILayout.TextArea(item.Value.ToString());
                }
                //EditorGUILayout.EndFoldoutHeaderGroup();
                GUILayout.EndVertical();
            }
        }
        GUILayout.Space(100);
        if(GUILayout.Button("Open file Remote config in Resources"))
        {
            Application.OpenURL(RemoteConfig.PathJson);
        }
        if(GUILayout.Button("Fetch data from Firebase remote config"))
        {
            LoadRemoteData();
        }
        //string keyInput = "account-sevice.json";
        //bool isHasKey = EditorPrefs.HasKey(keyInput);
        //if(isHasKey)
        //{
        //    isHasKey = !string.IsNullOrEmpty(EditorPrefs.GetString(keyInput));
        //}
        //if(isHasKey)
        //{
        //    if(GUILayout.Button("Import other private key Json"))
        //    {
        //        string pathInput = RemoteConfig.dirKey;
        //        pathInput = EditorUtility.OpenFilePanel("Select file", pathInput, "json");
        //        EditorPrefs.SetString(keyInput, pathInput);
        //    }
        //}
        //else
        //{
        //    if(GUILayout.Button("Import private key Json"))
        //    {
        //        LoadRemoteData();
        //    }
        //}
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(10));
        isShowContentKey = EditorGUILayout.BeginToggleGroup("Show firebase key", isShowContentKey);
        if(isShowContentKey)
        {
            GUILayout.Space(10);
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
            EditorGUI.BeginChangeCheck();
            var text = File.ReadAllText(RemoteConfig.PathKey);
            string value = EditorGUILayout.TextArea(text);
            if(EditorGUI.EndChangeCheck())
            {
                File.WriteAllText(RemoteConfig.PathKey, value);
            }
        }
        EditorGUILayout.EndToggleGroup();
    }

    void LoadRemoteData()
    {
        var dict = Directory.GetParent(Application.dataPath);
        var files = dict.GetFiles("firebase-remoteconfig.exe", SearchOption.AllDirectories);
        if(files.Length == 0)
        {
            Debug.LogError("firebase-remoteconfig.exe not found");
            return;
        }
        var path = files[0].FullName;
        //string pathInput = "";
        //string keyInput = "account-sevice.json";
        //if(EditorPrefs.HasKey(keyInput))
        //{
        //    pathInput = EditorPrefs.GetString(keyInput);
        //    if(!File.Exists(pathInput))
        //    {
        //        pathInput = RemoteConfig.dirKey;
        //    }
        //}
        //if(string.IsNullOrEmpty(pathInput))
        //{
        //    pathInput = EditorUtility.OpenFilePanel("Select file", pathInput, "json");
        //}
        ReadRemoteConfig(path, RemoteConfig.PathKey);
    }
    async void ReadRemoteConfig(string pathExe, string pathInput)
    {
        if(string.IsNullOrEmpty(pathInput))
        {
            return;
        }
        string text = File.ReadAllText(pathInput);
        if(File.Exists(RemoteConfig.PathKey))
        {
            File.WriteAllText(RemoteConfig.PathKey, text);
        }
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = pathExe,
            Arguments = $"-i {Path.GetFullPath(RemoteConfig.PathKey)}",
            RedirectStandardOutput = true, // Đọc đầu ra từ console
            RedirectStandardError = true,  // Đọc lỗi từ console
            UseShellExecute = false,       // Không sử dụng shell
            CreateNoWindow = true          // Không tạo cửa sổ console
        };
        Debug.Log(startInfo.Arguments);
        using(Process process = new Process { StartInfo = startInfo })
        {
            process.Start();

            // Đọc đầu ra và lỗi từ console
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            process.WaitForExit();

            if(string.IsNullOrEmpty(error) == false)
            {
                Debug.Log("Error:");
                Debug.Log(error);
            }
            if(string.IsNullOrEmpty(output) == false)
            {
                ReadFileRemote(output);
            }
        }
    }

    public void ReadFileRemote(string text)
    {
        var json = JsonConvert.DeserializeObject<JObject>(text);
        remoteConfigData = new JObject();
        var parameters = json["parameters"] as JObject;
        if(json.ContainsKey("parameters"))
        {
            foreach(var item in json["parameters"])
            {
                var obj = item as JProperty;
                string name = obj.Name;
                string valueType = "";
                foreach(var child in item.Children())
                {
                    valueType = child["valueType"].ToString();
                    break;
                }
                var _value = parameters[name]["defaultValue"]["value"];
                //Debug.Log(name + " " + valueType);
                switch(valueType)
                {
                    case "NUMBER":
                        remoteConfigData.Add(name, _value.Value<float>());
                        break;
                    case "BOOLEAN":
                        remoteConfigData.Add(name, _value.Value<bool>());
                        break;
                    case "STRING":
                    case "JSON":
                        remoteConfigData.Add(name, _value);
                        break;
                    default:
                        break;
                }
            }
            File.WriteAllText(RemoteConfig.PathJson, remoteConfigData.ToString());
            Debug.Log("Write file success! " + RemoteConfig.PathJson);
            AssetDatabase.Refresh();
        }
    }

    public bool IsJson(string text)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<JObject>(text);
            return true;
        }
        catch(Exception)
        {
            return false;
        }
    }
}
