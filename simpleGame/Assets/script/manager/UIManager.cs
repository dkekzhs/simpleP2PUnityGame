using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;     // 001
    public GameObject newGamePanel;     // 001_01
    public GameObject loadGamePanel;    // 002_02

    // �ʱ�ȭ
    void Start()
    {
        ShowMainMenu(); // �ʱ� ȭ���� MainMenu
    }

    // ���� �޴� ǥ��
    public void ShowMainMenu()
    {
        SetActivePanel(mainMenuPanel);
    }

    // �� ���� UI ǥ��
    public void ShowNewGame()
    {
        SetActivePanel(newGamePanel);
    }

    // �ҷ����� UI ǥ��
    public void ShowLoadGame()
    {
        SetActivePanel(loadGamePanel);
    }
    // Ȱ��ȭ�� �гθ� �Ѱ� �������� ���� �Լ�
    private void SetActivePanel(GameObject activePanel)
    {
        mainMenuPanel.SetActive(activePanel == mainMenuPanel);
        newGamePanel.SetActive(activePanel == newGamePanel);
        loadGamePanel.SetActive(activePanel == loadGamePanel);
    }
}
