using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class PlayerListUI : MonoBehaviour
{
    public TMP_Text playerListText;  // �÷��̾� ����Ʈ�� ǥ���� �ؽ�Ʈ UI

    void Update()
    {
        UpdatePlayerList();
    }

    void UpdatePlayerList()
    {
        List<PlayerRoomData> players = new List<PlayerRoomData>(FindObjectsOfType<PlayerRoomData>());

        playerListText.text = "�÷��̾� ����Ʈ:\n";
        foreach (var player in players)
        {
            playerListText.text += player.playerName + " (ID: " + player.playerName + ")\n";
        }
    }
}