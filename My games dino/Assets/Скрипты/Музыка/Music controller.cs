using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static AudioSource music; // �������� ������� ������
    [SerializeField] private AudioSource[] sounds; // ��������� �����
    private float musicVolume;
    private float soundsVolume;

    [SerializeField] private Slider musicSlider; // ������ �� ������� ��� ����������� ��������� ������
    [SerializeField] private Slider soundsSlider; // ������ �� ������� ��� ����������� ��������� ������

    private void Awake()
    {
        // ���������, ���� �� ������ � �������
        if (transform.childCount > 0)
        {
            // ���� ������ ��� �� �������� ����� �������, ��������� ���
            if (music == null)
            {
                music = transform.GetChild(0).GetComponent<AudioSource>();
                music.transform.SetParent(null); // � DontDestroyOnLoad ����� �������� ������ �������, � ������� ��� ����������
                DontDestroyOnLoad(music.gameObject); // ��������� ������ ����� �������
            }
            else
            {
                // ���� ������ ��� ����, �� ������� �����
                Destroy(transform.GetChild(0).gameObject);
            }
        }

        // ���������� ��������� �� ����������� ������
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        soundsVolume = PlayerPrefs.GetFloat("SoundsVolume", 1f);

    }

    void Start()
    {
        // ���������� ��������� ��� ���� AudioSource
        foreach (var source in sounds)
            source.volume = soundsVolume;

        // ���������� ������� ��������� � ��������� �� null
        if (musicSlider != null)
            musicSlider.value = musicVolume;
        if (soundsSlider != null)
            soundsSlider.value = soundsVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        music.volume = musicVolume; // ��������� ���������
        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // ���������� ���������
    }

    public void SetSoundsVolume(float volume)
    {
        soundsVolume = volume;
        foreach (var source in sounds) // ��������� ��������� ��� ���� ������
            source.volume = soundsVolume;
        PlayerPrefs.SetFloat("SoundsVolume", soundsVolume); // ���������� ���������
    }
}