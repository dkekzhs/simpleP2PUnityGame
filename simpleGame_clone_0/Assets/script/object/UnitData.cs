using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum UnitType
{
    Scout,         // ������
    Transport,     // ���ۼ�
    Fighter,       // ������
    Destroyer,     // ������
    Cruiser        // ������
}


[Serializable]
public struct UnitData
{
    public string name;              // ���ָ�
    public string category;          // �з� (����, ����, ����)
    public string type;              // ���� (�Ϲ�, �Լ�)
    public int resource1;            // �ڿ�1 ���
    public int resource2;            // �ڿ�2 ���
    public int fuelConsumption;      // ���� �Ҹ�
    public int unitScore;            // ���� ����
    public int durability;           // ������
    public int shield;               // ��ȣ��
    public int attackRange;          // ��Ÿ�
    public string attackType;        // ��������
    public int attackSpeed;          // ���ݼӵ�
    public int cargoCapacity;        // ���۷�
    public int moveSpeed;            // �̵��ӵ�

    // ���ݷ� �� ����Ƚ��
    public int groundAttack;         // ���� ���ݷ�
    public int smallAttack;          // ���� ���ݷ�
    public int mediumAttack;         // ���� ���ݷ�
    public int largeAttack;          // ���� ���ݷ�

    public int groundHits;           // ���� ���� Ƚ��
    public int smallHits;            // ���� ���� Ƚ��
    public int mediumHits;           // ���� ���� Ƚ��
    public int largeHits;            // ���� ���� Ƚ��
}

public static class UnitDatabase
{
    private static readonly Dictionary<UnitType, UnitData> unitDictionary = new Dictionary<UnitType, UnitData>
    {
        {
            UnitType.Scout, new UnitData
            {
                name = "Scout",
                category = "����",
                type = "�Ϲ�",
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
                category = "����",
                type = "�Ϲ�",
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
                category = "����",
                type = "�Ϲ�",
                resource1 = 2000,
                resource2 = 0,
                fuelConsumption = 20,
                unitScore = 1,
                durability = 1500,
                shield = 0,
                attackRange = 5,
                attackType = "������",
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
                category = "����",
                type = "�Լ�",
                resource1 = 10000,
                resource2 = 3000,
                fuelConsumption = 100,
                unitScore = 10,
                durability = 100000,
                shield = 100000,
                attackRange = 10,
                attackType = "������",
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
                category = "����",
                type = "�Լ�",
                resource1 = 150000,
                resource2 = 50000,
                fuelConsumption = 300,
                unitScore = 50,
                durability = 300000,
                shield = 300000,
                attackRange = 20,
                attackType = "������",
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
