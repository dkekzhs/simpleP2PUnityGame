using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameNameInput : MonoBehaviour
{
    public TMP_InputField gameNameInput; 
    public PlayerSetting playerSetting;

    public void OnGameNameChanged()
    {
        playerSetting.SetGameName(gameNameInput.text);
    }
}
