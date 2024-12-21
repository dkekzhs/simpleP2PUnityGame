using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{
    public static PlayerUIHandler Instance { get; private set; }
    public Button readyButton;
    public Button startButton;

    private PlayerRoomData playerData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("PlayerUIHandler �ʱ�ȭ �Ϸ�");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerData(PlayerRoomData data)
    {
        playerData = data;
        if (data == null)
        {
            Debug.LogError("PlayerRoomData�� null�Դϴ�.");
            return;
        }
        UpdateUI();
        Debug.Log($"PlayerUIHandler�� PlayerRoomData ������: {data.playerName}");
    }


    void Start()
    {
    }


    public void OnReadyButtonClick()
    {
        if (playerData != null)
        {
        playerData.CmdSetReadyState(true);
        }
    }

    public void OnStartButtonClick()
    {
            playerData.CmdStartGame();
    }
    private void UpdateUI()
    {

        startButton.gameObject.SetActive(playerData.IsHost());
        readyButton.gameObject.SetActive(!playerData.IsHost());
        
    }

    public void OnCancelButtonClick()
    {
        Debug.Log("Ŭ���̾�Ʈ�� ���� �������� �մϴ�.");

        playerData.CmdLeaveRoom();
        SceneController.Instance.LoadMainScene();
        
    }


}
