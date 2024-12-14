using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapAndResourceDropdown : MonoBehaviour
{
    public TMP_Dropdown mapSizeDropdown;     
    public TMP_Dropdown resourceSizeDropdown;
    public PlayerSetting playerSetting;

    public void OnMapSizeChanged()
    {
        playerSetting.SetMapSize(mapSizeDropdown.value);
    }

    public void OnResourceSizeChanged()
    {
        playerSetting.SetResourceSize(resourceSizeDropdown.value);
    }
}