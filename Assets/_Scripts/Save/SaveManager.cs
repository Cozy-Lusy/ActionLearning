using UnityEngine;

public static class SaveManager
{
    public static void Save<T>(string key, T SaveData)
    {
        string jsonDataString = JsonUtility.ToJson(SaveData, true);
        PlayerPrefs.SetString(key, jsonDataString);
    }

    public static T Load<T>(string key) where T: new()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(loadedString);
        } 
        else
        {
            return new T();
        }
    }
}
