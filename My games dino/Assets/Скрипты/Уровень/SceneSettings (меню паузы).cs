using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public GameObject PausePanel;

    // Обновление вызывается один раз за кадр
    void Update()
    {
        // Если нажата клавиша Esc, вызываем функцию TogglePause()
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Метод вызывается при нажатии на кнопку паузы
    public void PauseButtonPressed()
    {
        TogglePause();
    }

    // Метод вызывается при нажатии на кнопку продолжить
    public void ContinueButtonPressed()
    {
        TogglePause();
    }

    // Метод вызывается при нажатии на кнопку перезагрузки
    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Установка времени игры в нормальное значение
    }

    // Метод вызывается при нажатии на кнопку смены сцены
    public void ChangeScene()
    {
        SceneManager.LoadScene(2); // Загрузка второй сцены
        Time.timeScale = 1f; // Установка времени игры в нормальное значение
    }

    // Метод для открытия и закрытия паузы
    void TogglePause()
    {
        bool isPaused = PausePanel.activeSelf; // Проверяем, активна ли панель паузы
        PausePanel.SetActive(!isPaused); // Инвертируем активность панели паузы
        Time.timeScale = isPaused ? 1f : 0f; // Если игра была на паузе, устанавливаем нормальное время, иначе - останавливаем время
    }
}
