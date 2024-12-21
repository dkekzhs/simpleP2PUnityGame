using Mirror;
using UnityEngine;

public class PlayerRoomData : NetworkBehaviour
{
    [SyncVar]
    public string playerName;  

    [SyncVar]
    public bool isReady;  

    public override void OnStartServer()
    {
        playerName = "Player " + netId;  
        isReady = false; 
    }

    [Command]
    public void CmdSetReadyState(bool readyState)
    {
        isReady = readyState;  
        CheckAllPlayersReady();  
    }

    [Server]
    void CheckAllPlayersReady()
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
