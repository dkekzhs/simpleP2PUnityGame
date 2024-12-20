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
    public string name;             
    public int maxLevel;         
    public int resource1Cost;      
    public int resource2Cost;       
    public int resource3Cost;     
    public int resource4Cost;       
    public int resource5Cost;     


    public float resourceMultiplier;
    public int energyRequired;      
    public float energyIncreaseRate;
    public int generateEnergy;
    public int buildTime;           
    public int buildScore;
    public BuildingType? requiredBuilding1; 
    //필요 연구와 연구레벨은 아직
    public int buildingLevel;
}

// BuildingType을 기반으로 데이터를 반환하는 클래스
public static class BuildingDatabase
{
    private static readonly Dictionary<BuildingType, BuildingData> buildings = new Dictionary<BuildingType, BuildingData>
{
    { BuildingType.Headquarters, new BuildingData { name = "Command", maxLevel = 1, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 0, energyRequired = 0, energyIncreaseRate = 0, buildTime = 10, buildScore = 10 } },
    { BuildingType.Resource1Mine, new BuildingData { name = "Resource1Mine", maxLevel = 50, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 1.5f, energyRequired = 5, energyIncreaseRate = 1.1f, buildTime = 5, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.Resource2Mine, new BuildingData { name = "Resource2Mine", maxLevel = 50, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 1.5f, energyRequired = 5, energyIncreaseRate = 1.1f, buildTime = 5, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.Academy, new BuildingData { name = "Academy", maxLevel = 20, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 1.5f, energyRequired = 5, energyIncreaseRate = 1.1f, buildTime = 30, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.ResearchLab, new BuildingData { name = "ResearchLab", maxLevel = 50, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 1.5f, energyRequired = 30, energyIncreaseRate = 1.1f, buildTime = 60, buildScore = 10, requiredBuilding1 = BuildingType.Headquarters } },
    { BuildingType.FighterFactory, new BuildingData { name = "FighterFactory", maxLevel = 20, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 1.5f, energyRequired = 10, energyIncreaseRate = 1.1f, buildTime = 60, buildScore = 10, requiredBuilding1 = BuildingType.Resource1Mine } },
    { BuildingType.WasteProcessingPlant, new BuildingData { name = "WasteProcessing", maxLevel = 20, resource1Cost = 0, resource2Cost = 0, resource3Cost = 0 , resource4Cost = 0 ,resource5Cost = 0, resourceMultiplier = 1.5f, energyRequired = 15, energyIncreaseRate = 1.1f, buildTime = 60, buildScore = 10, requiredBuilding1 = BuildingType.Resource1Mine } }
};

    public static BuildingData GetBuildingData(BuildingType type)
    {
        return buildings[type];
    }
}

