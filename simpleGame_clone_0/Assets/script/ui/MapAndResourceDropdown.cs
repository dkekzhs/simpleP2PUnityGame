using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class MapAndResourceDropdown : MonoBehaviour
{
    public TMP_Dropdown mapSizeDropdown;     
    public TMP_Dropdown resourceSizeDropdown;
    public PlayerSetting playerSetting;
    public TMP_FontAsset customFont; 
    private void Start()
    {
        ApplyCustomFont();
        InitializeDropdowns();
    }
    private void InitializeDropdowns()
    {
        mapSizeDropdown.options.Clear();
        mapSizeDropdown.options.Add(new TMP_Dropdown.OptionData(GetLocalizedString("MapSize_Small")));   // Small
        mapSizeDropdown.options.Add(new TMP_Dropdown.OptionData(GetLocalizedString("MapSize_Medium")));  // Medium
        mapSizeDropdown.options.Add(new TMP_Dropdown.OptionData(GetLocalizedString("MapSize_Large")));   // Large
        mapSizeDropdown.value = 0; 


        resourceSizeDropdown.options.Clear();
        resourceSizeDropdown.options.Add(new TMP_Dropdown.OptionData(GetLocalizedString("Resource_Insufficient"))); // ºÎÁ·ÇÔ
        resourceSizeDropdown.options.Add(new TMP_Dropdown.OptionData(GetLocalizedString("Resource_Average")));      // Æò±Õ
        resourceSizeDropdown.options.Add(new TMP_Dropdown.OptionData(GetLocalizedString("Resource_Abundant")));     // Ç³Á·ÇÔ
        resourceSizeDropdown.value = 1; 
    }

    private string GetLocalizedString(string key)
    {
        return LocalizationSettings.StringDatabase.GetLocalizedString("sizeTable", key); // Localization Å×ÀÌºí "UI" »ç¿ë
    }
    public void OnMapSizeChanged()
    {
        playerSetting.SetMapSize(mapSizeDropdown.value);
        Debug.Log($"Map Size ¼±ÅÃµÊ: {mapSizeDropdown.options[mapSizeDropdown.value].text}");
    }

    public void OnResourceSizeChanged()
    {
        playerSetting.SetResourceSize(resourceSizeDropdown.value);
        Debug.Log($"Resource Size ¼±ÅÃµÊ: {resourceSizeDropdown.options[resourceSizeDropdown.value].text}");
    }

    private void ApplyCustomFont()
    {
        if (customFont != null)
        {
            // Dropdown¿¡ Ä¿½ºÅÒ ÆùÆ® Àû¿ë
            mapSizeDropdown.captionText.font = customFont;
            mapSizeDropdown.itemText.font = customFont;

            resourceSizeDropdown.captionText.font = customFont;
            resourceSizeDropdown.itemText.font = customFont;

            Debug.Log("Custom font applied: ³ª´®¹Ù¸¥°íµñ");
        }
        else
        {
            Debug.LogWarning("Custom font not assigned in inspector.");
        }
    }

}