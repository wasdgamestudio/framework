using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class GoogleSheetEditor : EditorWindow
{
    public static string GoogleSheetUrl { get; set; } = "https://docs.google.com/spreadsheets/d/";
    public static string SpreadSheetId { get; set; } = "";
    private static string[] Scopes = { SheetsService.Scope.Spreadsheets };
    private static string ApplicationName = "Google API Unity Editor";
    private SheetsService service;
    JObject jsonObject;
    // [MenuItem("Window/Google Sheet Editor")]
    public static void OpenWindow()
    {
        var window = GetWindow<GoogleSheetEditor>("Google Sheet Editor");
        window.minSize = new Vector2(400, 600);
    }
    private void OnEnable()
    {
        jsonObject = LoadJson();
        if(jsonObject.ContainsKey(nameof(SpreadSheetId)))
        {
            SpreadSheetId = jsonObject.Value<string>(nameof(SpreadSheetId)).ToString();
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Spread Sheet Id");
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginChangeCheck();
        SpreadSheetId = EditorGUILayout.TextField(SpreadSheetId);
        if(!string.IsNullOrEmpty(SpreadSheetId))
        {
            SpreadSheetId = GetSpreadsheetId(SpreadSheetId);
            if(GUILayout.Button("Open", GUILayout.Width(60)))
            {
                Application.OpenURL(GoogleSheetUrl + SpreadSheetId);
            }
        }
        if(EditorGUI.EndChangeCheck())
        {
            if(jsonObject.ContainsKey(nameof(SpreadSheetId)))
            {
                jsonObject[nameof(SpreadSheetId)] = SpreadSheetId;
            }
            else
            {
                jsonObject.Add(nameof(SpreadSheetId), SpreadSheetId);
            }
            SaveJson(GetJsonPath(), jsonObject);
        }
        EditorGUILayout.EndHorizontal();
        if(string.IsNullOrEmpty(SpreadSheetId)) return;

        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("Pull", GUILayout.Width(100)))
        {
            if(AuthenticateGoogleAPI())
            {
                FetchDataFromSheet();
            }
        }

        EditorGUILayout.EndHorizontal();
        ShowJsonData();
    }

    void ShowJsonData()
    {
        if(jsonObject == null || jsonObject.Count == 0) return;

        float widthValue = position.width - 210;
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        GUILayout.Label("Name", EditorStyles.toolbarButton, GUILayout.Width(150));
        GUILayout.Label("Value", EditorStyles.toolbarButton);
        EditorGUILayout.EndHorizontal();
        foreach(var item in jsonObject)
        {
            if(item.Key == nameof(SpreadSheetId)) continue;
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(item.Key, GUILayout.Width(150));
            string _value = GUILayout.TextField(item.Value.ToString(), GUILayout.MaxWidth(widthValue));

            EditorGUILayout.EndHorizontal();
            GUILayout.Space(5);
        }
        if(GUILayout.Button("Save", GUILayout.Width(100)))
        {
            ApplyAll();
        }
    }

    void ApplyAll()
    {
        var info = InfoConfig.Get();
        // Set Title
        if(jsonObject.ContainsKey(SheetInfo.Name))
        {
            string name = jsonObject[SheetInfo.Name].ToString();
            name = IsValidFolderName(name);
            if(!string.IsNullOrEmpty(name))
            {
                PlayerSettings.productName = name;
                info.AddKeyValue(nameof(info.Name), name);
            }
        }
        // Set Package Title
        if(jsonObject.ContainsKey(SheetInfo.PackageName))
        {
            string packageName = jsonObject[SheetInfo.PackageName].ToString();
            if(!string.IsNullOrEmpty(packageName))
            {
#if UNITY_ANDROID
                PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, packageName);
#elif UNITY_IOS
                PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, packageName);
#endif
                info.AddKeyValue(nameof(info.PackageName), packageName);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.PrivacyPolicy))
        {
            string privacyPolicy = jsonObject[SheetInfo.PrivacyPolicy].ToString();
            if(!string.IsNullOrEmpty(privacyPolicy))
            {
                info.AddKeyValue(nameof(info.UrlPolicy), privacyPolicy);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.TermsOfUse))
        {
            string termsOfService = jsonObject[SheetInfo.TermsOfUse].ToString();
            if(!string.IsNullOrEmpty(termsOfService))
            {
                info.AddKeyValue(nameof(info.UrlTerms), termsOfService);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.SDKMax))
        {
            string sdkMax = jsonObject[SheetInfo.SDKMax].ToString();
            if(!string.IsNullOrEmpty(sdkMax))
            {
                info.AddKeyValue(nameof(info.SDKMax), sdkMax);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.AppId))
        {
            string appId = jsonObject[SheetInfo.AppId].ToString();
            if(!string.IsNullOrEmpty(appId))
            {
                info.AddKeyValue(nameof(info.AppID), appId);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.AppOpenId))
        {
            string appOpen = jsonObject[SheetInfo.AppOpenId].ToString();
            if(!string.IsNullOrEmpty(appOpen))
            {
                info.AddKeyValue(nameof(info.AppOpen), appOpen);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.BannerId))
        {
            string banner = jsonObject[SheetInfo.BannerId].ToString();
            if(!string.IsNullOrEmpty(banner))
            {
                info.AddKeyValue(nameof(info.Banner), banner);
            }
        }        
        if(jsonObject.ContainsKey(SheetInfo.InterstitialId))
        {
            string interstitial = jsonObject[SheetInfo.InterstitialId].ToString();
            if(!string.IsNullOrEmpty(interstitial))
            {
                info.AddKeyValue(nameof(info.Interstitial), interstitial);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.RewardedId))
        {
            string rewarded = jsonObject[SheetInfo.RewardedId].ToString();
            if(!string.IsNullOrEmpty(rewarded))
            {
                info.AddKeyValue(nameof(info.Rewarded), rewarded);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.AdjustToken))
        {
            string adjustToken = jsonObject[SheetInfo.AdjustToken].ToString();
            if(!string.IsNullOrEmpty(adjustToken))
            {
                info.AddKeyValue(ServiceParameters.ADJUST_APP_TOKEN, adjustToken);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.AppsflyerDevKey))
        {
            string appsflyerDevKey = jsonObject[SheetInfo.AppsflyerDevKey].ToString();
            if(!string.IsNullOrEmpty(appsflyerDevKey))
            {
                info.AddKeyValue(ServiceParameters.APPSFLYER_DEV_KEY, appsflyerDevKey);
            }
        }
        if(jsonObject.ContainsKey(SheetInfo.AppsflyerAppId))
        {
            string appsflyerAppId = jsonObject[SheetInfo.AppsflyerAppId].ToString();
            if(!string.IsNullOrEmpty(appsflyerAppId))
            {
                info.AddKeyValue(ServiceParameters.APPSFLYER_APP_ID, appsflyerAppId);
            }
        }

        EditorUtility.SetDirty(info);
        AssetDatabase.SaveAssets();
        Debug.Log("Apply all data from Google Sheet to project successfully.");
    }
    static string GetSpreadsheetId(string input)
    {
        // Check if the input is a URL
        if(IsGoogleSheetsUrl(input))
        {
            return ExtractSpreadsheetIdFromUrl(input);
        }
        else
        {
            // If it's not a URL, assume it's a SpreadsheetId
            return input;
        }
    }
    static bool IsGoogleSheetsUrl(string input)
    {
        // Regular expression to check if the input is a Google Sheets URL
        string urlPattern = @"https:\/\/docs\.google\.com\/spreadsheets\/d\/[a-zA-Z0-9-_]+\/edit";
        return Regex.IsMatch(input, urlPattern);
    }

    static string ExtractSpreadsheetIdFromUrl(string url)
    {
        // Regular expression to extract the SpreadsheetId from a URL
        string pattern = @"\/d\/([a-zA-Z0-9-_]+)\/edit";

        // Perform the regex match
        Match match = Regex.Match(url, pattern);

        if(match.Success)
        {
            // Return the first group, which contains the SpreadsheetId
            return match.Groups[1].Value;
        }

        // Return null if no match was found
        return null;
    }
    private bool AuthenticateGoogleAPI()
    {
        UserCredential credential;
        var path = PathEditor.GetPathFile("wasd-api.json");
        string credPath = "token.json";
        try
        {
            using(var stream =
                new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Debug.Log("Credential file saved to: " + credPath);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            Debug.Log("Google API authenticated successfully.");
            return true;
        }
        catch(Exception ex)
        {
            Debug.LogError("Error during Google API authentication: " + ex.Message);
        }
        return false;
    }
    async void FetchDataFromSheet()
    {
        var spreadsheetRequest = service.Spreadsheets.Get(SpreadSheetId);
        Spreadsheet spreadsheet = spreadsheetRequest.Execute();
        IList<Sheet> sheets = spreadsheet.Sheets;

        if(sheets != null && sheets.Count > 0)
        {
            // Lấy sheet đầu tiên
            Sheet firstSheet = sheets[0];
            string firstSheetTitle = firstSheet.Properties.Title;

            Debug.Log("First sheet name: " + firstSheetTitle);

            // Lấy toàn bộ dữ liệu từ sheet đầu tiên
            string range = $"{firstSheetTitle}!A:Z";  // Lấy toàn bộ dữ liệu từ cột A đến Z
                                                      // var request = service.Spreadsheets.Get(SpreadsheetId);
            var valueRange = await service.Spreadsheets.Values.Get(SpreadSheetId, range).ExecuteAsync();
            var values = valueRange.Values;


            // Load existing JSON from the file
            jsonObject = new JObject();
            if(values != null && values.Count > 0)
            {
                Debug.Log("Data from Google Sheets:");
                foreach(var row in values)
                {
                    if(row.Count < 2 || string.IsNullOrEmpty(row[0].ToString())) continue;
                    AddKeyValueToJson(jsonObject, row[0].ToString(), row[1].ToString());
                }
                SaveJson(GetJsonPath(), jsonObject);
            }
            else
            {
                Debug.Log("No data found.");
            }
        }
        else
        {
            Debug.LogError("No sheets found in the spreadsheet.");
        }
    }
    static string IsValidFolderName(string folderName)
    {
        Regex invalidCharsRegex = new Regex(@"[^a-zA-Z0-9_\- ]", RegexOptions.Compiled);
        string cleanedName = invalidCharsRegex.Replace(folderName, "");
        // Check if the cleaned name is empty
        if(string.IsNullOrEmpty(cleanedName))
        {
            throw new ArgumentException("The folder name is invalid.");
        }
        return cleanedName;
    }
    static string GetJsonPath()
    {
        string filePath = Directory.GetParent(Application.dataPath).FullName;
        filePath = Path.Combine(filePath, "Info.json");
        return filePath;
    }
    static JObject LoadJson()
    {
        var filePath = GetJsonPath();
        if(File.Exists(filePath))
        {
            // Load existing JSON file into a JObject
            string json = File.ReadAllText(filePath);
            return JObject.Parse(json);
        }
        else
        {
            // If the file doesn't exist, create a new empty JObject
            return new JObject();
        }
    }
    static void SaveJson(string filePath, JObject jsonObject)
    {
        // Serialize JObject back to JSON and write to file
        File.WriteAllText(filePath, jsonObject.ToString(Formatting.Indented));
    }
    static void AddKeyValueToJson(JObject jsonObject, string key, string value)
    {
        if(key == "Name" && value == "Value") return;
        if(!GetKeyValue(ref key, ref value)) return;
        // Add or update the key-value pair in the JObject
        jsonObject[key] = JToken.FromObject(value);
    }

    static bool GetKeyValue(ref string key, ref string value)
    {
        if(string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return false;
        if(SheetInfo.GetKey(ref key))
        {
            value = value.Trim();
            return true;
        }
        return false;
    }
}