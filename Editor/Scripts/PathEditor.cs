using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;
using System.Linq;

public class PathEditor
{
    static string MENU_PATH_PROJECT = "Project/| GAME ";
    public static string MENU_PATH_INFO = MENU_PATH_PROJECT + "Info";
    public static string MENU_PATH_SERVICE = MENU_PATH_PROJECT + "Services";
    public static string MENU_PATH_REMOTE_CONFIG = MENU_PATH_PROJECT + "Remote Config";
    public static string MENU_PATH_UI_CONFIG = MENU_PATH_PROJECT + "UI Config";

    public static string GetPathFile(string fileName)
    {
        var dict = Directory.GetParent(Application.dataPath);
        var files = dict.GetFiles(fileName, SearchOption.AllDirectories);
        if(files.Length == 0)
        {
            Debug.LogError($"{fileName} not found");
            return "";
        }
        return files[0].FullName;
    }

    public static string GetPathPackage(string packageName)
    {
        ListRequest listRequest = Client.List(); // Fetch the list of installed packages
        while(!listRequest.IsCompleted) { } // Wait until the request is completed

        if(listRequest.Status == StatusCode.Success)
        {
            var package = listRequest.Result.FirstOrDefault(p => p.name == packageName);
            if(package != null)
            {
                string packagePath = package.resolvedPath;
                UnityEngine.Debug.Log("Package Path: " + packagePath);
            }
            else
            {
                UnityEngine.Debug.LogWarning("Package not found: " + packageName);
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to get package list.");
        }
        return "";
    }
}
