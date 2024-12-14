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
        Insufficient, // ������
        Average,      // ���
        Abundant      // ǳ����
    }

    // --- ������ �ҷ����� �޼��� ---
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
            Debug.LogError("���� �̸��� 1~20�� ���̿��� �մϴ�.");
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
            Debug.LogError("�߸��� �� ũ�� ����");
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
            Debug.LogError("�߸��� �ڿ� ũ�� ����");
        }
    }

    public void SetMaxPlayers(int playerCount)
    {
        if (playerCount < 1 || playerCount > MAX_PLAYER_LIMIT)
        {
            Debug.LogError($"�÷��̾� ���� 1~{MAX_PLAYER_LIMIT} ���̿��� �մϴ�.");
            return;
        }
        maxPlayers = playerCount;
    }

    public void SetMaxEnemies(int enemyCount)
    {
        if (enemyCount < 0 || enemyCount > MAX_ENEMY_LIMIT)
        {
            Debug.LogError($"���� ���� 0~{MAX_ENEMY_LIMIT} ���̿��� �մϴ�.");
            return;
        }
        maxEnemies = enemyCount;
    }

    public bool Validateion()
    {
        if (string.IsNullOrEmpty(gameName))
        {
            Debug.LogError("���� �̸��� �������� �ʾҽ��ϴ�.");
            return false;
        }

        if (maxPlayers <= 0 || maxPlayers > MAX_PLAYER_LIMIT)
        {
            Debug.LogError("�÷��̾� ���� ��ȿ���� �ʽ��ϴ�.");
            return false;
        }

        if (maxEnemies < 0 || maxEnemies > MAX_ENEMY_LIMIT)
        {
            Debug.LogError("���� ���� ��ȿ���� �ʽ��ϴ�.");
            return false;
        }

        Debug.Log("��� ������ ��ȿ�մϴ�.");
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
            Debug.Log("��� ������ �Ϸ�Ǿ����ϴ�! ������ �����մϴ�.");
        }
        else
        {
            Debug.LogError("������ ������ �־� ������ ������ �� �����ϴ�.");
        }
    }
}

