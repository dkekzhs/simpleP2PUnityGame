using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class PlayerListUI : MonoBehaviour
{
    public TMP_Text playerListText;  // 플레이어 리스트를 표시할 텍스트 UI

    void Update()
    {
        UpdatePlayerList();
    }

    void UpdatePlayerList()
    {
        List<PlayerRoomData> players = new List<PlayerRoomData>(FindObjectsOfType<PlayerRoomData>());

        playerListText.text = "플레이어 리스트:\n";
        foreach (var player in players)
        {
            playerListText.text += player.playerName + " (ID: " + player.playerName + ")\n";
        }
    }
}