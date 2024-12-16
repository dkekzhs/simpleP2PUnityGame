using System;
using System.Collections.Generic;

[Serializable]
public class GameState
{
    public string gameName;                      
    public int currentTurn = 0;                    
    public List<Region> regions = new List<Region>(); // 지도상의 지역 정보
    public List<Fleet> fleets = new List<Fleet>();    // 함대 정보
    public List<EventData> events = new List<EventData>(); // 이벤트 목록

}

[Serializable]
public class Region
{
    public string name;          // 지역 이름
    public bool isNeutral;       // 중립 지역 여부
    public bool isExplored;      // 탐색 여부
    public string owner;         // 소유자 (플레이어, 적 등)
}


[Serializable]
public class EventData
{
    public string description;  // 이벤트 설명
    public bool isAccepted;     // 이벤트 수락 여부
}
