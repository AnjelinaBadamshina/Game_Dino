using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static AudioSource music; // Источник фоновой музыки
    [SerializeField] private AudioSource[] sounds; // Источники звука
    private float musicVolume;
    private float soundsVolume;

    [SerializeField] private Slider musicSlider; // Ссылка на слайдер для регулировки громкости музыки
    [SerializeField] private Slider soundsSlider; // Ссылка на слайдер для регулировки громкости звуков

    private void Awake()
    {
        // Проверяем, есть ли объект с музыкой
        if (transform.childCount > 0)
        {
            // Если объект еще не сохранен между сценами, сохраняем его
            if (music == null)
            {
                music = transform.GetChild(0).GetComponent<AudioSource>();
                music.transform.SetParent(null); // В DontDestroyOnLoad можно засунуть только объекты, у которых нет роддителей
                DontDestroyOnLoad(music.gameObject); // Сохранить объект между сценами
            }
            else
            {
                // Если объект уже есть, то удаляем копию
                Destroy(transform.GetChild(0).gameObject);
            }
        }

        // Установить громкость из сохраненных данных
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        soundsVolume = PlayerPrefs.GetFloat("SoundsVolume", 1f);

    }

    void Start()
    {
        // Установить громкость для всех AudioSource
        foreach (var source in sounds)
            source.volume = soundsVolume;

        // Установить уровень слайдеров с проверкой на null
        if (musicSlider != null)
            musicSlider.value = musicVolume;
        if (soundsSlider != null)
            soundsSlider.value = soundsVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        music.volume = musicVolume; // Установка громкости
        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // Сохранение громкости
    }

    public void SetSoundsVolume(float volume)
    {
        soundsVolume = volume;
        foreach (var source in sounds) // Установка громкости для всех звуков
            source.volume = soundsVolume;
        PlayerPrefs.SetFloat("SoundsVolume", soundsVolume); // Сохранение громкости
    }
}