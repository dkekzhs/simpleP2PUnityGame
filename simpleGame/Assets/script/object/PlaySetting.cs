using System;
using System.IO;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    private string gameName = "ASDASD"; 
    private MapSize mapSize = MapSize.Small;  
    private ResourceSize resourceSize = ResourceSize.Average; 
    private int maxPlayers = 5; 
    private int maxEnemies = 2; 

    private readonly int MAX_PLAYER_LIMIT = 8;
    private readonly int MAX_ENEMY_LIMIT = 4;

    public enum MapSize
    {
        Small,    // 25x25
        Medium,   // 50x50
        Large     // 100x100
    }

    public enum ResourceSize
    {
        Insufficient, // 부족함
        Average,      // 평균
        Abundant      // 풍족함
    }

    // --- 데이터 불러오기 메서드 ---
    public string GetGameName()
    {
        return gameName;
    }

    public MapSize GetMapSize()
    {
        return mapSize;
    }

    public ResourceSize GetResourceSize()
    {
        return resourceSize;
    }

    public int GetMaxPlayers()
    {
        return maxPlayers;
    }

    public int GetMaxEnemies()
    {
        return maxEnemies;
    }

    public void SetGameName(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length > 20) 
        {
            Debug.LogError("게임 이름은 1~20자 사이여야 합니다.");
            return;
        }
        gameName = name;
    }

    public void SetMapSize(int sizeIndex)
    {
        if (Enum.IsDefined(typeof(MapSize), sizeIndex))
        {
            mapSize = (MapSize)sizeIndex;
        }
        else
        {
            Debug.LogError("잘못된 맵 크기 선택");
        }
    }

    public void SetResourceSize(int resourceIndex)
    {
        if (Enum.IsDefined(typeof(ResourceSize), resourceIndex))
        {
            resourceSize = (ResourceSize)resourceIndex;
        }
        else
        {
            Debug.LogError("잘못된 자원 크기 선택");
        }
    }

    public void SetMaxPlayers(int playerCount)
    {
        if (playerCount < 1 || playerCount > MAX_PLAYER_LIMIT)
        {
            Debug.LogError($"플레이어 수는 1~{MAX_PLAYER_LIMIT} 사이여야 합니다.");
            return;
        }
        maxPlayers = playerCount;
    }

    public void SetMaxEnemies(int enemyCount)
    {
        if (enemyCount < 0 || enemyCount > MAX_ENEMY_LIMIT)
        {
            Debug.LogError($"적의 수는 0~{MAX_ENEMY_LIMIT} 사이여야 합니다.");
            return;
        }
        maxEnemies = enemyCount;
    }

    public bool Validateion()
    {
        if (string.IsNullOrEmpty(gameName))
        {
            Debug.LogError("게임 이름이 설정되지 않았습니다.");
            return false;
        }

        if (maxPlayers <= 0 || maxPlayers > MAX_PLAYER_LIMIT)
        {
            Debug.LogError("플레이어 수가 유효하지 않습니다.");
            return false;
        }

        if (maxEnemies < 0 || maxEnemies > MAX_ENEMY_LIMIT)
        {
            Debug.LogError("적의 수가 유효하지 않습니다.");
            return false;
        }

        Debug.Log("모든 설정이 유효합니다.");
        return true;
    }
    public void LogAllVariables()
    {
        Debug.Log($"Game Name: {gameName}");
        Debug.Log($"Map Size: {mapSize}");
        Debug.Log($"Resource Size: {resourceSize}");
        Debug.Log($"Max Players: {maxPlayers}");
        Debug.Log($"Max Enemies: {maxEnemies}");
        Debug.Log($"Player Limit: {MAX_PLAYER_LIMIT}");
        Debug.Log($"Enemy Limit: {MAX_ENEMY_LIMIT}");
    }
    public void OnValidateSettings()
    {
        LogAllVariables();
        bool isValid = Validateion();
        if (isValid)
        {
            Debug.Log("모든 설정이 완료되었습니다! 게임을 시작합니다.");
        }
        else
        {
            Debug.LogError("설정에 문제가 있어 게임을 시작할 수 없습니다.");
        }
    }
}

