using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    PlayerSetting playerSetting;
    Dictionary<int, MapData> map;

    void Start()
    {
        
    }

    void Update()
    {

    }

    //behavior method example player visit... 


    public void InitMap()
    {
        playerSetting.GetMapSize();
        playerSetting.GetResourceSize();

        map = MapDatabase.initMapData();

        foreach (var entry in map)
        {
            MapData mapData = entry.Value;

            if (mapData == null) continue;

        }

        Console.Write(map.ToString());



    }

    private void AdjustResources(MapData mapData, PlayerSetting.ResourceSize resourceSize)
    {
        float multiplier = 1.0f;

        switch (resourceSize)
        {
            case PlayerSetting.ResourceSize.Insufficient:
                multiplier = 1f; 
                break;
            case PlayerSetting.ResourceSize.Average:
                multiplier = 2f; 
                break;
            case PlayerSetting.ResourceSize.Abundant:
                multiplier = 3f;
                break;
        }

        mapData.resource1Efficiency *= multiplier;
        mapData.resource2Efficiency *= multiplier;
        mapData.resource3Efficiency *= multiplier;
        mapData.resource4Efficiency *= multiplier;
        mapData.resource5Efficiency *= multiplier;
    }

}
