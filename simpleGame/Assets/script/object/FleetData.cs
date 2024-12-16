using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FleetGoal
{
    Reconnaissance, // 정찰
    Attack,         // 공격
    Occupy,         // 점령
    Transport       // 수송
}

[Serializable]
public struct Fleet
{
    public string player;        // 플레이어 이름
    public int fleetNumber;      // 함대 번호
    public string fleetName;     // 함대명 (설정 가능)
    public FleetGoal goal;       // 목표 (정찰, 공격, 점령, 수송)
    public Vector2Int startPointA;  // 출발 좌표 A
    public Vector2Int startPointB;  // 출발 좌표 B
    public Vector2Int destinationA; // 도착 좌표 A
    public Vector2Int destinationB; // 도착 좌표 B
    public int maxCargoCapacity;    // 최대 수송량
    public int cargoResource1;      // 수송 자원 1
    public int cargoResource2;      // 수송 자원 2
    public int cargoResource3;      // 수송 자원 3
    public int cargoResource4;      // 수송 자원 4
    public int cargoResource5;      // 수송 자원 5

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