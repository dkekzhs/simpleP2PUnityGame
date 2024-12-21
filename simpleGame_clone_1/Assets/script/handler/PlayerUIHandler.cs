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
            Debug.Log("PlayerUIHandler 초기화 완료");
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
            Debug.LogError("PlayerRoomData가 null입니다.");
            return;
        }
        UpdateUI();
        Debug.Log($"PlayerUIHandler에 PlayerRoomData 설정됨: {data.playerName}");
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
        Debug.Log("클라이언트가 방을 나가려고 합니다.");

        playerData.CmdLeaveRoom();
        SceneController.Instance.LoadMainScene();
        
    }


}
