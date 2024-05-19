using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LevelController.instance != null) // Проверка на null, чтобы избежать ошибок
        {
            if (collision.CompareTag("Player1"))
            {
                LevelController.instance.CharacterFinished(1); // Player1 пересек триггер
            }
            else if (collision.CompareTag("Player2"))
            {
                LevelController.instance.CharacterFinished(2); // Player2 пересек триггер
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LevelController.instance != null) // Проверка на null, чтобы избежать ошибок
        {
            if (collision.CompareTag("Player1"))
            {
                LevelController.instance.CharacterLeft(1); // Player1 покинул триггер
            }
            else if (collision.CompareTag("Player2"))
            {
                LevelController.instance.CharacterLeft(2); // Player2 покинул триггер
            }
        }
    }
}
