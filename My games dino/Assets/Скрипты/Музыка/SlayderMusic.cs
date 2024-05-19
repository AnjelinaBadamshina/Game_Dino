using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // Ссылка на слайдер для регулировки громкости

    void Start()
    {
        // Получаем единственный экземпляр MusicController
        MusicController musicController = MusicController.instance;

        // Если экземпляр MusicController не найден, выходим из метода
        if (musicController == null) return;

        // Если ссылка на volumeSlider не является null
        if (volumeSlider != null)
        {
            // Устанавливаем значение слайдера в соответствии с текущим уровнем громкости
            volumeSlider.value = musicController.GetVolume();

            // Обновляем громкость при изменении значения слайдера
            volumeSlider.onValueChanged.AddListener(value =>
            {
                musicController.SetVolume(value);
            });
        }
    }
}
