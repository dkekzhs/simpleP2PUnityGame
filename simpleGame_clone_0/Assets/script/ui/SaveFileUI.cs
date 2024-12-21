using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveFileUI : MonoBehaviour
{
    public Transform saveListParent; // ���� ���� ��ư�� �� �θ� ��ü
    public GameObject saveButtonPrefab; // ��ư ������
    private SaveFileManager saveFileManager;

    void Start()
    {
        saveFileManager = FindObjectOfType<SaveFileManager>();
        DisplaySaveFiles();
    }

    void DisplaySaveFiles()
    {
        List<string> saveFiles = saveFileManager.GetAllSaveFiles(); 

        foreach (string fileName in saveFiles)
        {
            GameObject button = Instantiate(saveButtonPrefab, saveListParent);
            button.GetComponentInChildren<TMP_Text>().text = fileName;

            // ��ư Ŭ�� �̺�Ʈ ����
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnSaveFileSelected(fileName));
        }
    }

    void OnSaveFileSelected(string fileName)
    {
        PlayerSetting loadedGame = saveFileManager.LoadSaveFile(fileName);
        if (loadedGame != null)
        {
            Debug.Log($"�ҷ��� ���� �̸�: {loadedGame.GetGameName()}");
        }
    }
}
