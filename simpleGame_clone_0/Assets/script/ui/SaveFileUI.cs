using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveFileUI : MonoBehaviour
{
    public Transform saveListParent; // 저장 파일 버튼이 들어갈 부모 객체
    public GameObject saveButtonPrefab; // 버튼 프리팹
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

            // 버튼 클릭 이벤트 연결
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnSaveFileSelected(fileName));
        }
    }

    void OnSaveFileSelected(string fileName)
    {
        PlayerSetting loadedGame = saveFileManager.LoadSaveFile(fileName);
        if (loadedGame != null)
        {
            Debug.Log($"불러온 게임 이름: {loadedGame.GetGameName()}");
        }
    }
}
