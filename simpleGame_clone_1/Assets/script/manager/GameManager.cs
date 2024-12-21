using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mirror;
using System;

public class GameManager : MonoBehaviour
{

    void Start()
    {

    }

    public void OnStartGame()
    {
        PlayerSetting.Instance.OnValidateSettings();
        RoomManager.Instance.CreateRoom();

        Console.WriteLine("SUCEESS CREATE ROOM");

    }
  
    void Update()
    {
        
    }
}
