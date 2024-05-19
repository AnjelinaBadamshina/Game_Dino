using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnEnter : MonoBehaviour
{
    void Update()
    {
        // Проверяем, нажата ли клавиша Enter (KeyCode.Return для клавиатур с английской раскладкой)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Переключаемся на указанную сцену
            SceneManager.LoadScene(1); // или SceneManager.LoadScene(sceneIndex);
        }
    }
}



