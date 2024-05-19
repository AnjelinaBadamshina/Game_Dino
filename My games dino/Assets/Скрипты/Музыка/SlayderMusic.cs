using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // ������ �� ������� ��� ����������� ���������

    void Start()
    {
        // �������� ������������ ��������� MusicController
        MusicController musicController = MusicController.instance;

        // ���� ��������� MusicController �� ������, ������� �� ������
        if (musicController == null) return;

        // ���� ������ �� volumeSlider �� �������� null
        if (volumeSlider != null)
        {
            // ������������� �������� �������� � ������������ � ������� ������� ���������
            volumeSlider.value = musicController.GetVolume();

            // ��������� ��������� ��� ��������� �������� ��������
            volumeSlider.onValueChanged.AddListener(value =>
            {
                musicController.SetVolume(value);
            });
        }
    }
}
