using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] characters; // Массив персонажей для выбора
    [SerializeField] private string PrefName;
    [SerializeField] private CameraController camera;
    void Start()
    {
        // Загружаем индекс выбранного персонажа из PlayerPrefs
        int selectedCharacterIndex = PlayerPrefs.GetInt(PrefName, 0);

        // Деактивируем всех персонажей
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        // Активируем выбранного персонажа
        characters[selectedCharacterIndex].SetActive(true);

        if (PrefName == "CharactersSelect1")
        {
            camera.Player1 = characters[selectedCharacterIndex].transform;
        }
        else
        {
            camera.Player2 = characters[selectedCharacterIndex].transform;
        }
        
    }
}
