using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectUI : MonoBehaviour
{
    public TMP_InputField playerIp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickConnectBtn()
    {
        RoomManager.Instance.JoinRoom(playerIp.text);
    }
}
