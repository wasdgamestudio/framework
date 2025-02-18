using System.IO;
using UnityEditor;
using UnityEngine;

public class ModuleEditor : Editor
{
    public static string GetGitModule(ServiceType module)
    {
        switch (module)
        {
            case ServiceType.Firebase:
                return "git@gitlab.com:wasd-packages/module-firebase.git";
            case ServiceType.Applovin:
                return "git@gitlab.com:wasd-packages/module-applovin.git";
            case ServiceType.Adjust:
                return "git@gitlab.com:wasd-packages/module-adjust.git";
            case ServiceType.Appsflyer:
                return "git@gitlab.com:wasd-packages/module-appsflyer.git";
          
            default: return "";
        }
    }
    public static ServiceType GetModule(string path)
    {
        if (path.Contains("module-firebase"))
        {
            return ServiceType.Firebase;
        }
        if (path.Contains("module-applovin"))
        {
            return ServiceType.Applovin;
        }
        if (path.Contains("module-adjust"))
        {
            return ServiceType.Adjust;
        }
        if (path.Contains("module-appsflyer"))
        {
            return ServiceType.Appsflyer;
        }
      
        return ServiceType.None;
    }

    public static string[] GetGitModule()
    {
        string path = Directory.GetParent(Application.dataPath).FullName;

        string gitModules = Path.Combine(path, ".gitmodules");
        if (!File.Exists(gitModules))
        {
            return new string[0];
        }
        string[] lines = File.ReadAllLines(gitModules);
        return lines;
    }

    public static string[] GetGitConfig()
    {
        string path = Directory.GetParent(Application.dataPath).FullName;
        string gitModules = Path.Combine(path, ".git/config");
        if (!File.Exists(gitModules))
        {
            return new string[0];
        }
        string[] lines = File.ReadAllLines(gitModules);
        return lines;
    }
    public static string LocalPath(string url)
    {
        return "Assets/_API/" + url.Substring(url.LastIndexOf("/") + 1).Replace(".git", "");
    }
    public static string LocalPath(ServiceType module)
    {
        string subPath = "module-" + module.ToString().ToLower();
        return "Assets/_API/" + subPath;
    }
    public static ServiceType GetModuleType(string localPath)
    {
        switch (localPath)
        {
            case "module-firebase": return ServiceType.Firebase;
            case "module-applovin": return ServiceType.Applovin;
            case "module-adjust": return ServiceType.Adjust;
            case "module-appsflyer": return ServiceType.Appsflyer;
            default: return ServiceType.None;
        }
    }
}
