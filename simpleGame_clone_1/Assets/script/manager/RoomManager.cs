using Mirror;
using System.Collections.Generic;
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
    void LoadLobbyScene()
    {
        ServerChangeScene("RoomScene");  // 대기방 씬 이름으로 변경
    }

    // 게임 시작 - 대기방에서 호출
    public void StartGame()
    {
        ServerChangeScene("InGameScene");  // 게임 씬으로 이동
    }
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
    public override void OnStopHost()
    {
        Debug.Log("서버가 종료되었습니다.");
    }

    public override void OnClientConnect()
    {
        Debug.Log("클라이언트가 서버에 접속했습니다.");
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("클라이언트가 서버에서 접속을 끊었습니다.");
    }



}
