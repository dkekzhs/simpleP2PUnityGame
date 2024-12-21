using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum UnitType
{
    Scout,         // 정찰기
    Transport,     // 수송선
    Fighter,       // 전투기
    Destroyer,     // 구축함
    Cruiser        // 순양함
}


[Serializable]
public struct UnitData
{
    public string name;              // 유닛명
    public string category;          // 분류 (소형, 중형, 대형)
    public string type;              // 유형 (일반, 함선)
    public int resource1;            // 자원1 비용
    public int resource2;            // 자원2 비용
    public int fuelConsumption;      // 연료 소모량
    public int unitScore;            // 유닛 점수
    public int durability;           // 내구도
    public int shield;               // 보호막
    public int attackRange;          // 사거리
    public string attackType;        // 공격유형
    public int attackSpeed;          // 공격속도
    public int cargoCapacity;        // 수송량
    public int moveSpeed;            // 이동속도

    // 공격력 및 공격횟수
    public int groundAttack;         // 지상 공격력
    public int smallAttack;          // 소형 공격력
    public int mediumAttack;         // 중형 공격력
    public int largeAttack;          // 대형 공격력

    public int groundHits;           // 지상 공격 횟수
    public int smallHits;            // 소형 공격 횟수
    public int mediumHits;           // 중형 공격 횟수
    public int largeHits;            // 대형 공격 횟수
}

public static class UnitDatabase
{
    private static readonly Dictionary<UnitType, UnitData> unitDictionary = new Dictionary<UnitType, UnitData>
    {
        {
            UnitType.Scout, new UnitData
            {
                name = "Scout",
                category = "소형",
                type = "일반",
                resource1 = 100,
                resource2 = 0,
                fuelConsumption = 5,
                unitScore = 1,
                durability = 100,
                shield = 0,
                attackRange = 0,
                attackType = "null",
                attackSpeed = 0,
                cargoCapacity = 0,
                moveSpeed = 1000,
                groundAttack = 0,
                smallAttack = 0,
                mediumAttack = 0,
                largeAttack = 0,
                groundHits = 0,
                smallHits = 0,
                mediumHits = 0,
                largeHits = 0
            }
        },
        {
            UnitType.Transport, new UnitData
            {
                name = "Transport",
                category = "소형",
                type = "일반",
                resource1 = 1000,
                resource2 = 0,
                fuelConsumption = 20,
                unitScore = 1,
                durability = 2000,
                shield = 0,
                attackRange = 0,
                attackType = "null",
                attackSpeed = 0,
                cargoCapacity = 1000,
                moveSpeed = 100,
                groundAttack = 0,
                smallAttack = 0,
                mediumAttack = 0,
                largeAttack = 0,
                groundHits = 0,
                smallHits = 0,
                mediumHits = 0,
                largeHits = 0
            }
        },
        {
            UnitType.Fighter, new UnitData
            {
                name = "Fighter",
                category = "소형",
                type = "일반",
                resource1 = 2000,
                resource2 = 0,
                fuelConsumption = 20,
                unitScore = 1,
                durability = 1500,
                shield = 0,
                attackRange = 5,
                attackType = "레이저",
                attackSpeed = 1,
                cargoCapacity = 100,
                moveSpeed = 70,
                groundAttack = 100,
                smallAttack = 100,
                mediumAttack = 100,
                largeAttack = 100,
                groundHits = 1,
                smallHits = 1,
                mediumHits = 1,
                largeHits = 1
            }
        },
        {
            UnitType.Destroyer, new UnitData
            {
                name = "Destroyer",
                category = "중형",
                type = "함선",
                resource1 = 10000,
                resource2 = 3000,
                fuelConsumption = 100,
                unitScore = 10,
                durability = 100000,
                shield = 100000,
                attackRange = 10,
                attackType = "레이저",
                attackSpeed = 1,
                cargoCapacity = 50000,
                moveSpeed = 50,
                groundAttack = 1000,
                smallAttack = 1000,
                mediumAttack = 1000,
                largeAttack = 1000,
                groundHits = 5,
                smallHits = 5,
                mediumHits = 5,
                largeHits = 1
            }
        },
        {
            UnitType.Cruiser, new UnitData
            {
                name = "Cruiser",
                category = "대형",
                type = "함선",
                resource1 = 150000,
                resource2 = 50000,
                fuelConsumption = 300,
                unitScore = 50,
                durability = 300000,
                shield = 300000,
                attackRange = 20,
                attackType = "레이저",
                attackSpeed = 1,
                cargoCapacity = 100000,
                moveSpeed = 30,
                groundAttack = 3000,
                smallAttack = 3000,
                mediumAttack = 3000,
                largeAttack = 3000,
                groundHits = 10,
                smallHits = 10,
                mediumHits = 10,
                largeHits = 2
            }
        }
    };

    public static UnitData GetUnitData(UnitType type)
    {
        return unitDictionary[type];
    }
}
