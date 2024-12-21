using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ResearchType
{
    Resource1Efficiency, // �ڿ�1 ä�� ȿ�� ����
    Resource2Efficiency, // �ڿ�2 ä�� ȿ�� ����
    ResearchSpeed,       // ���� �ӵ� ����
    AttackPower,         // ���ݷ� ����
    Durability           // ������ ����
}

[Serializable]
public struct ResearchData
{
    public string name;                // ������
    public int maxLevel;               // �ִ� ����
    public int resource1Cost;          // �ڿ�1 ���
    public int resource2Cost;          // �ڿ�2 ���
    public float resourceMultiplier;   // ������ �ڿ����
    public float researchTime;         // ���� �ð�
    public float timeIncreaseRate;     // ������ �����ð� ������
    public int researchScore;          // ���� ����
    public ResearchType[] requiredResearch; // �ʿ� ����
    public string requiredBuilding;    // �ʿ� �ǹ�
}
public static class ResearchDatabase
{
    private static readonly Dictionary<ResearchType, ResearchData> researchData = new Dictionary<ResearchType, ResearchData>
    {
        { ResearchType.Resource1Efficiency, new ResearchData {
            name = "�ڿ�1 ä�� ȿ�� ����", maxLevel = 100, resource1Cost = 10000, resource2Cost = 0,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.Resource2Efficiency, new ResearchData {
            name = "�ڿ�2 ä�� ȿ�� ����", maxLevel = 100, resource1Cost = 10000, resource2Cost = 20000,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.ResearchSpeed, new ResearchData {
            name = "���� �ӵ� ����", maxLevel = 100, resource1Cost = 10000, resource2Cost = 20000,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.AttackPower, new ResearchData {
            name = "���ݷ� ����", maxLevel = 100, resource1Cost = 50000, resource2Cost = 100000,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }},
        { ResearchType.Durability, new ResearchData {
            name = "������ ����", maxLevel = 100, resource1Cost = 100000, resource2Cost = 0,
            resourceMultiplier = 1.2f, researchTime = 60, timeIncreaseRate = 1.1f, researchScore = 100, requiredBuilding = "Research Lab"
        }}
    };

    public static ResearchData GetResearchData(ResearchType type)
    {
        return researchData[type];
    }
}
