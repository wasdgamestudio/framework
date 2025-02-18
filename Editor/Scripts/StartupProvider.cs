using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using game.remoteconfig;

public class StartupProvider
{
    [SettingsProvider]
    public static SettingsProvider CreateWasdService() => CreateProvider(PathEditor.MENU_PATH_SERVICE, ServiceConfig.Get());


    [SettingsProvider]
    public static SettingsProvider CreateWasdInfo() => CreateProvider(PathEditor.MENU_PATH_INFO, InfoConfig.Get());

    [SettingsProvider]
    public static SettingsProvider CreateWasdRemoteConfig() => CreateProvider(PathEditor.MENU_PATH_REMOTE_CONFIG, RemoteConfig.Get());
    [SettingsProvider]
    public static SettingsProvider CreateWasdUIConfig()=> CreateProvider(PathEditor.MENU_PATH_UI_CONFIG, PanelConfig.Get());


    private static SettingsProvider CreateProvider(string settingsWindowPath, Object asset)
    {
        var provider = AssetSettingsProvider.CreateProviderFromObject(settingsWindowPath, asset);

        provider.keywords = SettingsProvider.GetSearchKeywordsFromSerializedObject(new SerializedObject(asset));
        return provider;
    }
}
