using System;
using System.Collections.Generic;

[Serializable]
public class GameState
{
    public string gameName;                      
    public int currentTurn = 0;                    
    public List<Region> regions = new List<Region>(); // �������� ���� ����
    public List<Fleet> fleets = new List<Fleet>();    // �Դ� ����
    public List<EventData> events = new List<EventData>(); // �̺�Ʈ ���

}

[Serializable]
public class Region
{
    public string name;          // ���� �̸�
    public bool isNeutral;       // �߸� ���� ����
    public bool isExplored;      // Ž�� ����
    public string owner;         // ������ (�÷��̾�, �� ��)
}


[Serializable]
public class EventData
{
    public string description;  // �̺�Ʈ ����
    public bool isAccepted;     // �̺�Ʈ ���� ����
}
