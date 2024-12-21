using Mirror;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RoomManager : NetworkManager
{
    public static RoomManager Instance { get; private set; }

    private List<PlayerRoomData> players = new List<PlayerRoomData>();


    public override void Awake()
    {
        base.Awake();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Debug.LogWarning("RoomManager 인스턴스 중복. 기존 인스턴스 유지, 새로운 인스턴스 제거.");
            Destroy(gameObject);
        }
    }

    public void CreateRoom()
    {
        StartHost();
        LoadLobbyScene();
    }

    public void JoinRoom(string ipAddress)
    {
        networkAddress = ipAddress;  
        StartClient();
    }


    void LoadMainScene()
    {
        SceneController.Instance.LoadMainScene();
    }
    void LoadLobbyScene()
    {
        ServerChangeScene("RoomScene");  // 대기방 씬 이름으로 변경
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        GameObject player = Instantiate(playerPrefab);
        PlayerRoomData playerData = player.GetComponent<PlayerRoomData>();
        players.Add(playerData);
        if (playerData != null)
        {
            Debug.Log($"플레이어 추가됨: {playerData.playerName}");
        }
        else
        {
            Debug.LogError("PlayerRoomData 초기화 실패");
        }
    }
    public override void OnStopHost()
    {
        players.Clear();
        Debug.Log("서버 종료");
    }

    public override void OnClientConnect()
    {
        Debug.Log("클라이언트가 서버에 접속했습니다.");
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("클라이언트가 서버에서 접속을 끊었습니다.");
    }
    [Server]
    public void StartGame()
    {
        Debug.Log("게임 시작");
        ServerChangeScene("InGameScene");
    }
    [Server]
    public void LeaveRoom(NetworkConnectionToClient conn)
    {
        PlayerRoomData playerToRemove = players.Find(p => p.connectionToClient == conn);
        if (playerToRemove != null)
        {
            players.Remove(playerToRemove);
        }

        Debug.Log($"플레이어 {conn.connectionId} 나감");
        conn.Disconnect();
    }

    [Server]
    public void CheckAllPlayersReady()
    {
        foreach (PlayerRoomData player in FindObjectsOfType<PlayerRoomData>())
        {
            if (!player.isReady)
            {
                return;
            }
        }
        RoomManager.Instance.StartGame();
    }


}
