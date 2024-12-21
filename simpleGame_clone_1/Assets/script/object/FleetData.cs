using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FleetGoal
{
    Reconnaissance, // ����
    Attack,         // ����
    Occupy,         // ����
    Transport       // ����
}

[Serializable]
public struct Fleet
{
    public string player;        // �÷��̾� �̸�
    public int fleetNumber;      // �Դ� ��ȣ
    public string fleetName;     // �Դ�� (���� ����)
    public FleetGoal goal;       // ��ǥ (����, ����, ����, ����)
    public Vector2Int startPointA;  // ��� ��ǥ A
    public Vector2Int startPointB;  // ��� ��ǥ B
    public Vector2Int destinationA; // ���� ��ǥ A
    public Vector2Int destinationB; // ���� ��ǥ B
    public int maxCargoCapacity;    // �ִ� ���۷�
    public int cargoResource1;      // ���� �ڿ� 1
    public int cargoResource2;      // ���� �ڿ� 2
    public int cargoResource3;      // ���� �ڿ� 3
    public int cargoResource4;      // ���� �ڿ� 4
    public int cargoResource5;      // ���� �ڿ� 5

    public Fleet(string player, int fleetNumber, string fleetName, FleetGoal goal, Vector2Int startA, Vector2Int startB,
                 Vector2Int destinationA, Vector2Int destinationB, int maxCargo, int resource1, int resource2,
                 int resource3, int resource4, int resource5)
    {
        this.player = player;
        this.fleetNumber = fleetNumber;
        this.fleetName = fleetName;
        this.goal = goal;
        this.startPointA = startA;
        this.startPointB = startB;
        this.destinationA = destinationA;
        this.destinationB = destinationB;
        this.maxCargoCapacity = maxCargo;
        this.cargoResource1 = resource1;
        this.cargoResource2 = resource2;
        this.cargoResource3 = resource3;
        this.cargoResource4 = resource4;
        this.cargoResource5 = resource5;
    }
}