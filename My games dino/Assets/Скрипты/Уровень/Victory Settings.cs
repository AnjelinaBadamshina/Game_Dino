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
        Time.timeScale = 0f; // Останавливаем время при отображении панели
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Возобновляем время
    }

    public void ChangeScrene()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // Переход на следующий уровень
        Time.timeScale = 1f;
    }

    public void EnableNextLevelButton()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = true; // Включить кнопку "Следующий уровень"
        }
    }

    public void DisableNextLevelButton()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.interactable = false; // Выключить кнопку "Следующий уровень"
        }
    }
}
