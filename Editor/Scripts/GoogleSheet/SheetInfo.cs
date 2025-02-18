using System.Reflection;

public class SheetInfo
{
    public static string Name => "Name";
    public static string PackageName => "Package Name";
    public static string PrivacyPolicy => "Privacy Policy";
    public static string TermsOfUse => "Terms of Use";
    public static string SDKMax => "SDK Max";
    public static string AppId => "App Id";
    public static string AppOpenId => "App Open Id";
    public static string BannerId => "Banner Id";
    public static string MRECId => "MREC Id";
    public static string InterstitialId => "Interstitial Id";
    public static string RewardedId => "Rewarded Id";
    public static string AdjustToken => "Adjust Token";
    public static string AppsflyerDevKey => "Appsflyer Dev Key";
    public static string AppsflyerAppId => "Appsflyer App Id";

    public static bool GetKey(ref string key)
    {
        key = key.Trim();
        // Get all public static fields from the class
        var Properties = typeof(SheetInfo).GetProperties(BindingFlags.Public | BindingFlags.Static);

        // Iterate over the fields to check if any of their values match the input value
        foreach(var property in Properties)
        {
            if(property.PropertyType == typeof(string))
            {
                var fieldValue = (string)property.GetValue(null); // Get static field value
                if(fieldValue == key)
                {
                   // key = property.Title;
                    return true; // Found a match
                }
            }
        }

        return false; // No match found
    }
}
