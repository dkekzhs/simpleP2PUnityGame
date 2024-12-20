using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum MapType
{
    space,
    starSystem

}

[System.Serializable]
public class MapData
{
    public int id;                 // ��ȣ
    public string name;            // ��Ī
    public MapType type;            // ���� (��: �׼���, ���༺�� ��)
    public string owner;           // ����ڸ� (A, B, �Ұ� ��)
    public HashSet<string> isExplored;        // Ž�� ����
    public Vector2Int coordinates; // ��ǥ
    public int planets;            // �༺ ��
    public int satellites;         // ���� ��
    public int asteroidBelts;      // ���༺��
    public int stars;              // �׼�
    public int nebulas;            // ����
    public float resource1Efficiency; // �ڿ�1 ȿ��
    public float resource2Efficiency; // �ڿ�2 ȿ��
    public float resource3Efficiency; // �ڿ�3 ȿ��
    public float resource4Efficiency; // �ڿ�4 ȿ��
    public float resource5Efficiency; // �ڿ�5 ȿ��
}

public static class MapDatabase
{
    private static Dictionary<int, MapData> map = new Dictionary<int, MapData>
    {
        {
            1, new MapData
            {
                id = 1,
                name = "���ְ���",
                type = MapType.space,
                owner = "�Ұ�",
                isExplored = new HashSet<string> { },
                coordinates = new Vector2Int(1, 0),
                planets = 0,
                satellites = 0,
                asteroidBelts = 0,
                stars = 0,
                nebulas = 1,
                resource1Efficiency = 0,
                resource2Efficiency = 0,
                resource3Efficiency = 0,
                resource4Efficiency = 0,
                resource5Efficiency = 1
            }
        },
        {
            2, new MapData
            {
                id = 2,
                name = "�¾��1",
                type = MapType.starSystem,
                owner = "A",
                isExplored = new HashSet<string> { },
                coordinates = new Vector2Int(2, 5),
                planets = 3,
                satellites = 1,
                asteroidBelts = 1,
                stars = 1,
                nebulas = 0,
                resource1Efficiency = 2.5f,
                resource2Efficiency = 1.5f,
                resource3Efficiency = 1,
                resource4Efficiency = 1,
                resource5Efficiency = 0
            }
        },
        {
            3, new MapData
            {
                id = 3,
                name = "�¾��2",
                type = MapType.starSystem,
                owner = "B",
                isExplored = new HashSet<string> { },
                coordinates = new Vector2Int(3, 2),
                planets = 2,
                satellites = 2,
                asteroidBelts = 2,
                stars = 1,
                nebulas = 0,
                resource1Efficiency = 1,
                resource2Efficiency = 1,
                resource3Efficiency = 2,
                resource4Efficiency = 1,
                resource5Efficiency = 0
            }
        },
        {
            4, new MapData
            {
                id = 4,
                name = "�¾��3",
                type = MapType.starSystem,
                owner = "A",
                isExplored = new HashSet<string> { },
                coordinates = new Vector2Int(4, 6),
                planets = 1,
                satellites = 1,
                asteroidBelts = 1,
                stars = 1,
                nebulas = 0,
                resource1Efficiency = 3,
                resource2Efficiency = 0.5f,
                resource3Efficiency = 1,
                resource4Efficiency = 1,
                resource5Efficiency = 0
            }
        },
        {
            5, new MapData
            {
                id = 5,
                name = "�¾��4",
                type = MapType.starSystem,
                owner = "����",
                isExplored = new HashSet<string> { },
                coordinates = new Vector2Int(5, 3),
                planets = 1,
                satellites = 1,
                asteroidBelts = 1,
                stars = 1,
                nebulas = 0,
                resource1Efficiency = 1.5f,
                resource2Efficiency = 0.5f,
                resource3Efficiency = 1,
                resource4Efficiency = 1,
                resource5Efficiency = 0
            }
        }
    };

    public static Dictionary<int, MapData> initMapData()
    {
        return map;
    }
    public static MapData GetMapData(int id)
    {
        MapData val;
        if (map.TryGetValue(id, out val))
        {
            return val;
        }
        else return null;
    }
}
