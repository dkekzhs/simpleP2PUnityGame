using System;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string playerName;
    public int score;
    public int level;

    public void SaveToFile(string filePath)
    {
        string jsonData = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, jsonData);
        Debug.Log("Data saved to: " + filePath);
    }

    public static PlayerData LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<PlayerData>(jsonData);
        }
        Debug.LogError("Save file not found in " + filePath);
        return null;
    }
}
