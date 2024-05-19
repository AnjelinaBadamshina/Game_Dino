using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictorySettings : MonoBehaviour
{
    public GameObject VictoryPanel;
    public Button nextLevelButton;

    public void VictoryPressed()
    {
        VictoryPanel.SetActive(true);
        Time.timeScale = 0f; // ������������� ����� ��� ����������� ������
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // ������������ �����
    }

    public void ChangeScrene()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // ������� �� ��������� �������
        Time.timeScale = 1f;
    }

    public void EnableNextLevelButton()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = true; // �������� ������ "��������� �������"
        }
    }

    public void DisableNextLevelButton()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = false; // ��������� ������ "��������� �������"
        }
    }
}
