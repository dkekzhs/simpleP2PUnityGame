using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;     // 001
    public GameObject newGamePanel;     // 001_01
    public GameObject loadGamePanel;    // 002_02

    // 초기화
    void Start()
    {
        ShowMainMenu(); // 초기 화면은 MainMenu
    }

    // 메인 메뉴 표시
    public void ShowMainMenu()
    {
        SetActivePanel(mainMenuPanel);
    }

    // 새 게임 UI 표시
    public void ShowNewGame()
    {
        SetActivePanel(newGamePanel);
    }

    // 불러오기 UI 표시
    public void ShowLoadGame()
    {
        SetActivePanel(loadGamePanel);
    }
    // 활성화할 패널만 켜고 나머지는 끄는 함수
    private void SetActivePanel(GameObject activePanel)
    {
        mainMenuPanel.SetActive(activePanel == mainMenuPanel);
        newGamePanel.SetActive(activePanel == newGamePanel);
        loadGamePanel.SetActive(activePanel == loadGamePanel);
    }
}
