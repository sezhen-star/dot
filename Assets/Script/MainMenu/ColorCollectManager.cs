using UnityEngine;

public static class ColorCollectManager
{
    public static bool HasOrange
    {
        get => PlayerPrefs.GetInt("HasOrange", 0) == 1;
        set => PlayerPrefs.SetInt("HasOrange", value ? 1 : 0);
    }

    public static bool HasGreen
    {
        get => PlayerPrefs.GetInt("HasGreen", 0) == 1;
        set => PlayerPrefs.SetInt("HasGreen", value ? 1 : 0);
    }

    public static bool HasPurple
    {
        get => PlayerPrefs.GetInt("HasPurple", 0) == 1;
        set => PlayerPrefs.SetInt("HasPurple", value ? 1 : 0);
    }

    public static bool AllCollected()
    {
        return HasOrange && HasGreen && HasPurple;
    }

    // ≤‚ ‘ªÚ÷ÿ÷√”√
    public static void ResetAll()
    {
        HasOrange = HasGreen = HasPurple = false;
        PlayerPrefs.Save();
    }
}
