using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{

    public PlayerData playerData;
    private FileObserver fileObserver;
    private string filePath;
    
    void Start()
    {
        Debug.Log("save file path " + Application.persistentDataPath);
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        if (File.Exists(filePath))
        {
            playerData = PlayerData.LoadFromFile(filePath);
            Debug.Log("Loaded Player: " + playerData.playerName);
        }
        else
        {
            playerData = new PlayerData() { playerName = "Player1", score = 0, level = 1 };
            playerData.SaveToFile(filePath);
        }

        fileObserver = new FileObserver(filePath, playerData);

    }

  
    void Update()
    {
        
    }
}
