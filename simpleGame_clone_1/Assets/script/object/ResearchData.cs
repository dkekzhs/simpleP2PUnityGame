using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ResearchType
{
    Resource1Efficiency, // 자원1 채굴 효율 증가
    Resource2Efficiency, // 자원2 채굴 효율 증가
    ResearchSpeed,       // 연구 속도 증가
    AttackPower,         // 공격력 증가
    Durability           // 내구도 증가
}

[Serializable]
public struct ResearchData
{
    public string name;                // 연구명
    public int maxLevel;               // 최대 레벨
    public int resource1Cost;          // 자원1 비용
    public int resource2Cost;          // 자원2 비용
    public float resourceMultiplier;   // 레벨당 자원배수
    public float researchTime;         // 연구 시간
    public float timeIncreaseRate;     // 레벨당 연구시간 증가율
    public int researchScore;          // 연구 점수
    public ResearchType[] requiredResearch; // 필요 연구
    public string requiredBuilding;    // 필요 건물
}
public static class ResearchDatabase
{
    private static readonly Dictionary<ResearchType, ResearchData> researchData = new Dictionary<ResearchType, ResearchData>
    {
        { ResearchType.Resource1Efficiency, new ResearchData {
            name = "자원1 채굴 효율 증가", maxLevel = 100, resource1Cost = 10000, resource2Cost = 0,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.Resource2Efficiency, new ResearchData {
            name = "자원2 채굴 효율 증가", maxLevel = 100, resource1Cost = 10000, resource2Cost = 20000,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.ResearchSpeed, new ResearchData {
            name = "연구 속도 증가", maxLevel = 100, resource1Cost = 10000, resource2Cost = 20000,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.AttackPower, new ResearchData {
            name = "공격력 증가", maxLevel = 100, resource1Cost = 50000, resource2Cost = 100000,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.Durability, new ResearchData {
            name = "내구도 증가", maxLevel = 100, resource1Cost = 100000, resource2Cost = 0,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }}
    };

    public static ResearchData GetResearchData(ResearchType type)
    {
        return researchData[type];
    }
}
