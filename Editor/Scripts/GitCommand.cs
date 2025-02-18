using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GitCommand
{
    public static async Task RunGitCommand(string command)
    {

        var tcs = new System.Threading.Tasks.TaskCompletionSource<int>();
        ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = true;
        processStartInfo.RedirectStandardError = true;
        processStartInfo.RedirectStandardOutput = true;

        using(var process = new Process())
        {

            process.EnableRaisingEvents = true;
            process.StartInfo = processStartInfo;
            process.Start();
          
            process.Exited += (sender, e) =>
            {
                tcs.SetResult(process.ExitCode);
            };

            process.Disposed += (sender, e) =>
            {
                Debug.Log("Done!");
                AssetDatabase.Refresh();
                process.Dispose();
            };
            process.OutputDataReceived += (sender, e) =>
            {
                Debug.Log(e.Data);
            };
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            Debug.Log(command);
            await tcs.Task;
            process.WaitForExit();
        }
    }


    public static async void AddSubmodule(string url, Action<string> callback)
    {
        //await RunGitCommand("git add .gitmodules");
        string path = "Assets/_API/" + url.Substring(url.LastIndexOf("/") + 1).Replace(".git", "");
        //await RunGitCommand($"git rm --cached {path} -r");
        Debug.Log("Adding submodule to " + path);
        callback?.Invoke(path);
        await RunGitCommand("git submodule add --force " + url + " " + path);
    }

    public static async void RemoveSubmodule(string localPath)
    {
        await RunGitCommand("git submodule deinit -f --" + localPath);
        await RunGitCommand("git rm -f " + localPath);
        await RunGitCommand("git commit -m \"Removed submodule " + localPath + "\"");
        await RunGitCommand("rm -rf .git/modules/" + localPath);
        await RunGitCommand("git rm --cached " + localPath);
        await RunGitCommand($"git commit -m \"{localPath }\" from index");
    }

    //public static void UpdateSubmodule(string path)
    //{
    //    RunGitCommand("git submodule update --init --recursive " + path);
    //}

    public static async void AddGitLFS()
    {
        string path = Application.dataPath;
        var files = ExtensionsEditor.FindLargeFiles(path, 100);
        await RunGitCommand("git lfs install");
        await RunGitCommand("git lfs track \"*.psd\"");
        await RunGitCommand("git add .gitattributes");
        await RunGitCommand("git commit -m \"Add git lfs\"");
    }
}