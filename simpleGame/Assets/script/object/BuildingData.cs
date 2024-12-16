using System;
using System.Collections.Generic;

public enum BuildingType
{
    Headquarters,
    Resource1Mine,
    Resource2Mine,
    Academy,
    ResearchLab,
    FighterFactory,
    WasteProcessingPlant
}

[System.Serializable]
public struct BuildingData
{
    public string name;             // 건물명
    public int maxLevel;            // 최대 레벨
    public int resource1Cost;       // 자원1 비용
    public int resource2Cost;       // 자원2 비용
    public float resourceMultiplier; // 레벨당 자원 배수
    public int energyRequired;      // 필요 에너지
    public float energyIncreaseRate; // 레벨당 에너지 증가율
    public int buildTime;           // 건설 시간
    public int buildScore;          // 건설 점수
    public BuildingType? requiredBuilding1; // 필요 건물1
}

// BuildingType을 기반으로 데이터를 반환하는 클래스
public static class BuildingDatabase
{
    private static readonly Dictionary<BuildingType, BuildingData> buildings = new Dictionary<BuildingType, BuildingData>
{
    { BuildingType.Headquarters, new BuildingData { name = "Command", maxLevel = 1, resource1Cost = 0, resource2Cost = 0, resourceMultiplier = 0, energyRequired = 0, energyIncreaseRate = 0, buildTime = 10, buildScore = 10 } },
    { BuildingType.Resource1Mine, new BuildingData { name = "Resource1Mine", maxLevel = 50, resource1Cost = 0, resource2Cost = 0, resourceMultiplier = 1.5f, energyRequired = 5, energyIncreaseRate = 1.1f, buildTime = 5, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.Resource2Mine, new BuildingData { name = "Resource2Mine", maxLevel = 50, resource1Cost = 0, resource2Cost = 0, resourceMultiplier = 1.5f, energyRequired = 5, energyIncreaseRate = 1.1f, buildTime = 5, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.Academy, new BuildingData { name = "Academy", maxLevel = 20, resource1Cost = 150, resource2Cost = 0, resourceMultiplier = 1.5f, energyRequired = 5, energyIncreaseRate = 1.1f, buildTime = 30, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.ResearchLab, new BuildingData { name = "ResearchLab", maxLevel = 50, resource1Cost = 500, resource2Cost = 500, resourceMultiplier = 1.5f, energyRequired = 30, energyIncreaseRate = 1.1f, buildTime = 60, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.FighterFactory, new BuildingData { name = "FighterFactory", maxLevel = 20, resource1Cost = 200, resource2Cost = 150, resourceMultiplier = 1.5f, energyRequired = 10, energyIncreaseRate = 1.1f, buildTime = 60, buildScore = 10, requiredBuilding1 = BuildingType.Resource1Mine } },
    { BuildingType.WasteProcessingPlant, new BuildingData { name = "WasteProcessing", maxLevel = 20, resource1Cost = 200, resource2Cost = 0, resourceMultiplier = 1.5f, energyRequired = 15, energyIncreaseRate = 1.1f, buildTime = 60, buildScore = 10, requiredBuilding1 = BuildingType.Resource1Mine } }
};

    public static BuildingData GetBuildingData(BuildingType type)
    {
        return buildings[type];
    }
}

