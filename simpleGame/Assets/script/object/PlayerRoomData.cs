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
        Debug.Log($"[서버] PlayerRoomData 초기화 완료: {playerName}");
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log($"[클라이언트] 로컬 플레이어 초기화됨: {playerName}");
        StartCoroutine(WaitForPlayerUIHandler());
    }

    private IEnumerator WaitForPlayerUIHandler()
    {
        yield return new WaitUntil(() => PlayerUIHandler.Instance != null);
        PlayerUIHandler.Instance.SetPlayerData(this);
        Debug.Log($"PlayerRoomData가 PlayerUIHandler에 설정됨: {playerName}");
    }

    [Command]
    public void CmdSetReadyState(bool readyState)
    {
        isReady = readyState;
        Debug.Log($"[서버] {playerName} 준비 상태: {isReady}");
        RoomManager.Instance.CheckAllPlayersReady();
    }

    [Command]
    public void CmdStartGame()
    {
        if (isServer)
        {
            Debug.Log($"[서버] 게임 시작 요청: {playerName}");
            RoomManager.Instance.StartGame();
        }
    }

    [Command]
    public void CmdLeaveRoom()
    {
        if (isServer)
        {
            Debug.Log($"[서버] 방 나가기 요청: {playerName}");
            RoomManager.Instance.LeaveRoom(connectionToClient);
        }
    }

    public bool IsHost()
    {
        return isServer && isOwned;
    }
}
