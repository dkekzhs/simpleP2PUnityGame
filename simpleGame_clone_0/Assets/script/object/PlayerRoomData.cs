using Mirror;
using System.Collections;
using UnityEngine;

public class PlayerRoomData : NetworkBehaviour
{
    [SyncVar]
    public string playerName;

    [SyncVar]
    public bool isReady;

    public override void OnStartServer()
    {
        playerName = $"Player {connectionToClient.connectionId}";
        isReady = false;
        Debug.Log($"[����] PlayerRoomData �ʱ�ȭ �Ϸ�: {playerName}");
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log($"[Ŭ���̾�Ʈ] ���� �÷��̾� �ʱ�ȭ��: {playerName}");
        StartCoroutine(WaitForPlayerUIHandler());
    }

    private IEnumerator WaitForPlayerUIHandler()
    {
        yield return new WaitUntil(() => PlayerUIHandler.Instance != null);
        PlayerUIHandler.Instance.SetPlayerData(this);
        Debug.Log($"PlayerRoomData�� PlayerUIHandler�� ������: {playerName}");
    }

    [Command]
    public void CmdSetReadyState(bool readyState)
    {
        isReady = readyState;
        Debug.Log($"[����] {playerName} �غ� ����: {isReady}");
        RoomManager.Instance.CheckAllPlayersReady();
    }

    [Command]
    public void CmdStartGame()
    {
        if (isServer)
        {
            Debug.Log($"[����] ���� ���� ��û: {playerName}");
            RoomManager.Instance.StartGame();
        }
    }

    [Command]
    public void CmdLeaveRoom()
    {
        if (isServer)
        {
            Debug.Log($"[����] �� ������ ��û: {playerName}");
            RoomManager.Instance.LeaveRoom(connectionToClient);
        }
    }

    public bool IsHost()
    {
        return isServer && isOwned;
    }
}
