using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileManager : MonoBehaviour
{
    private string saveDirectory;

    void Start()
    {
        saveDirectory = Application.persistentDataPath;
        Debug.Log($"세이브 경로: {saveDirectory}");
    }

    public List<string> GetAllSaveFiles()
    {
        List<string> saveFiles = new List<string>();

        if (Directory.Exists(saveDirectory))
        {
            string[] files = Directory.GetFiles(saveDirectory, "*_save.json");

            foreach (string file in files)
            {
                saveFiles.Add(Path.GetFileName(file));
            }
        }
        return saveFiles;
    }

    public PlayerSetting LoadSaveFile(string fileName)
    {
        string filePath = Path.Combine(saveDirectory, fileName);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            PlayerSetting loadedData = JsonUtility.FromJson<PlayerSetting>(jsonData);
            Debug.Log($"세이브 파일 불러오기 성공: {filePath}");
            return loadedData;
        }
        else
        {
            Debug.LogError("세이브 파일을 찾을 수 없습니다.");
            return null;
        }
    }
}
