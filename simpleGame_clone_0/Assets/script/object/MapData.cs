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
    public int id;                 // 번호
    public string name;            // 명칭
    public MapType type;            // 구분 (예: 항성계, 소행성대 등)
    public string owner;           // 사용자명 (A, B, 불가 등)
    public HashSet<string> isExplored;        // 탐색 여부
    public Vector2Int coordinates; // 좌표
    public int planets;            // 행성 수
    public int satellites;         // 위성 수
    public int asteroidBelts;      // 소행성대
    public int stars;              // 항성
    public int nebulas;            // 성운
    public float resource1Efficiency; // 자원1 효율
    public float resource2Efficiency; // 자원2 효율
    public float resource3Efficiency; // 자원3 효율
    public float resource4Efficiency; // 자원4 효율
    public float resource5Efficiency; // 자원5 효율
}

public static class MapDatabase
{
    private static Dictionary<int, MapData> map = new Dictionary<int, MapData>
    {
        {
            1, new MapData
            {
                id = 1,
                name = "우주공간",
                type = MapType.space,
                owner = "불가",
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
                name = "태양계1",
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
                name = "태양계2",
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
                name = "태양계3",
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
                name = "태양계4",
                type = MapType.starSystem,
                owner = "가능",
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
