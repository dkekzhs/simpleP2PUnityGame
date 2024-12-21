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
            Debug.LogWarning("RoomManager �ν��Ͻ� �ߺ�. ���� �ν��Ͻ� ����, ���ο� �ν��Ͻ� ����.");
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
        ServerChangeScene("RoomScene");  // ���� �� �̸����� ����
    }

    // ���� ���� - ���濡�� ȣ��
    public void StartGame()
    {
        ServerChangeScene("InGameScene");  // ���� ������ �̵�
    }
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
    public override void OnStopHost()
    {
        Debug.Log("������ ����Ǿ����ϴ�.");
    }

    public override void OnClientConnect()
    {
        Debug.Log("Ŭ���̾�Ʈ�� ������ �����߽��ϴ�.");
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("Ŭ���̾�Ʈ�� �������� ������ �������ϴ�.");
    }



}
