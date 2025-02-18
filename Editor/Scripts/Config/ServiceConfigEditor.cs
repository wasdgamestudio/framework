using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ServiceConfig))]
public class ServiceConfigEditor : Editor
{
    ServiceConfig StartupConfig;
   
    void OnEnable()
    {
        StartupConfig = target as ServiceConfig;
        if (StartupConfig == null)
        {
            return;
        }
       
    }
    ServiceType serviceSelect = ServiceType.None;
    public override void OnInspectorGUI()
    {
        GUIStyle addStyle = new GUIStyle(EditorStyles.miniButton)
        {
            fontSize = 12,
            normal = { textColor = Color.green }
        };       
       
        EditorGUIUtility.labelWidth = 100;

        if (GUILayout.Button("Refresh"))
        {
            StartupConfig.ReloadPackages();
        }
        //base.OnInspectorGUI();
        if (StartupConfig.Services.Count == 0)
        {
            GUILayout.Label("No services added");
        }
        GUILayout.BeginVertical();
        for (int i = 0; i < StartupConfig.Services.Count; i++)
        {
            ShowService(StartupConfig.Services[i]);
        }
        GUILayout.EndVertical();
        GUILayout.Space(30);
        GUILayout.BeginHorizontal();
        serviceSelect = (ServiceType)EditorGUILayout.EnumPopup("Select Services:", serviceSelect);
        if(serviceSelect != ServiceType.None && !StartupConfig.Services.Contains(serviceSelect))
        {
            if(GUILayout.Button("Add Service", addStyle))
            {
                StartupConfig.AddService(serviceSelect);
                AssetDatabase.SaveAssetIfDirty(StartupConfig);
            }
        }
        GUILayout.EndHorizontal();
    }
    void ShowService(ServiceType service)
    {
        GUIStyle reloadStyle = new GUIStyle(EditorStyles.miniButton)
        {
            fontSize = 12,
            normal = { textColor = Color.yellow }
        };
        GUIStyle removeStyle = new GUIStyle(EditorStyles.miniButton)
        {
            fontSize = 12,
            normal = { textColor = Color.red }
        };
        EditorGUILayout.BeginFoldoutHeaderGroup(true, service.ToString());
        //GUILayout.Button(module.ToString());
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Reload", reloadStyle))
        {
            AssetDatabase.Refresh();
        }
        if(GUILayout.Button("Remove", removeStyle))
        {
            StartupConfig.RemoveService(service);
            AssetDatabase.SaveAssetIfDirty(StartupConfig);
        }

        GUILayout.EndHorizontal();
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
}