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


    void LoadMainScene()
    {
        SceneController.Instance.LoadMainScene();
    }
    void LoadLobbyScene()
    {
        ServerChangeScene("RoomScene");  // ���� �� �̸����� ����
    }


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        GameObject player = Instantiate(playerPrefab);
        PlayerRoomData playerData = player.GetComponent<PlayerRoomData>();
        players.Add(playerData);
        if (playerData != null)
        {
            Debug.Log($"�÷��̾� �߰���: {playerData.playerName}");
        }
        else
        {
            Debug.LogError("PlayerRoomData �ʱ�ȭ ����");
        }
    }
    public override void OnStopHost()
    {
        players.Clear();
        Debug.Log("���� ����");
    }

    public override void OnClientConnect()
    {
        Debug.Log("Ŭ���̾�Ʈ�� ������ �����߽��ϴ�.");
    }

    public override void OnClientDisconnect()
    {
        Debug.Log("Ŭ���̾�Ʈ�� �������� ������ �������ϴ�.");
    }
    [Server]
    public void StartGame()
    {
        Debug.Log("���� ����");
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

        Debug.Log($"�÷��̾� {conn.connectionId} ����");
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
