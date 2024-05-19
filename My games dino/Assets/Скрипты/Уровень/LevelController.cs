using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Используем паттерн синглтон, чтобы убедиться, что существует только один экземпляр LevelController
    public static LevelController instance = null;

    // Индекс текущей сцены/уровня
    int sceneIndex;
    // Самый высокий уровень, который был пройден, сохраняется в PlayerPrefs
    int levelComplete;

    // Ссылка на скрипт или класс, который управляет настройками победы и UI
    public VictorySettings victorySettings;

    int Crystal;

    private CrystalCounter crystalCounter; // Ссылка на экземпляр CrystalCounter

    // Флаги для отслеживания, закончили ли оба персонажа уровень
    private bool character1Finished = false;
    private bool character2Finished = false;

    // Метод Unity, который вызывается при инициализации скрипта
    void Start()
    {
        // Если это первый созданный экземпляр, делаем его синглтоном
        if (instance == null)
        {
            instance = this;
        }

        // Получаем индекс текущей сцены
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Загружаем значение самого высокого пройденного уровня из PlayerPrefs
        levelComplete = PlayerPrefs.GetInt("levelComplete", 0);

        crystalCounter = FindObjectOfType<CrystalCounter>(); // Находим объект CrystalCounter в сцене

    }


    // Метод для отметки, что персонаж закончил уровень
    public void CharacterFinished(int characterNumber)
    {
        // Если первый персонаж завершил уровень
        if (characterNumber == 1)
        {
            character1Finished = true;
        }
        // Если второй персонаж завершил уровень
        else if (characterNumber == 2)
        {
            character2Finished = true;
        }

        // Если оба персонажа завершили уровень, запускаем логику победы
        if (character1Finished && character2Finished)
        {
            ShowVictoryPanel();
        }
    }

    // Метод для отметки, что персонаж покинул финишную зону
    public void CharacterLeft(int characterNumber)
    {
        // Если первый персонаж покинул финишную зону
        if (characterNumber == 1)
        {
            character1Finished = false;
        }
        // Если второй персонаж покинул финишную зону
        else if (characterNumber == 2)
        {
            character2Finished = false;
        }
    }

    // Метод для отображения панели победы и управления логикой победы
    private void ShowVictoryPanel()
    {
        // Проверяем, назначен ли объект victorySettings
        if (victorySettings != null)
        {
            // Показываем панель победы или запускаем логику победы
            victorySettings.VictoryPressed();

            // Если текущий уровень больше самого высокого пройденного, обновляем значение levelComplete
            if (sceneIndex > levelComplete)
            {
                PlayerPrefs.SetInt("levelComplete", sceneIndex); // Сохраняем новый пройденный уровень
                PlayerPrefs.Save(); // Убеждаемся, что данные сохранены
            }

            // Определяем, нужно ли активировать или деактивировать кнопку "Следующий уровень"
            if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1) // Проверяем, есть ли следующий уровень
            {
                victorySettings.EnableNextLevelButton(); // Разрешаем переход на следующий уровень
            }
            else // Если это последний уровень
            {
                victorySettings.DisableNextLevelButton(); // Деактивируем кнопку "Следующий уро9вень"
            }


            Crystal = crystalCounter.crystal;

            if (Crystal == 0 && !PlayerPrefs.HasKey("CrystalRecordLevel" + sceneIndex))
                PlayerPrefs.SetInt("CrystalRecordLevel"+ sceneIndex, 0);
            else if (Crystal == 1 && (!PlayerPrefs.HasKey("CrystalRecordLevel" + sceneIndex) || PlayerPrefs.GetInt("CrystalRecordLevel" + sceneIndex) < 1))
                PlayerPrefs.SetInt("CrystalRecordLevel" + sceneIndex, 1);
            else if (Crystal == 2 && (!PlayerPrefs.HasKey("CrystalRecordLevel" + sceneIndex) || PlayerPrefs.GetInt("CrystalRecordLevel" + sceneIndex) < 2))
                PlayerPrefs.SetInt("CrystalRecordLevel" + sceneIndex, 2);
            else if (Crystal == 3 && (!PlayerPrefs.HasKey("CrystalRecordLevel" + sceneIndex) || PlayerPrefs.GetInt("CrystalRecordLevel" + sceneIndex) < 3))
                PlayerPrefs.SetInt("CrystalRecordLevel" + sceneIndex, 3);

            
            

        }
    }

}
