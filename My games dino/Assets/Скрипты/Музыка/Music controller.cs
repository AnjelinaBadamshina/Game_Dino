using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance; // Singleton
    private AudioSource audioSrc;
    private float musicVolume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохранить объект между сценами
        }
        else
        {
            Destroy(gameObject); // Уничтожить дубликат
        }
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null) return;

        // Установить громкость из сохраненных данных
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        if (audioSrc == null) return;

        musicVolume = volume;
        audioSrc.volume = musicVolume; // Установка громкости
        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // Сохранение громкости
    }

    public float GetVolume()
    {
        return musicVolume; // Возвращает текущее значение громкости
    }
}
