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
            DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������
        }
        else
        {
            Destroy(gameObject); // ���������� ��������
        }
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null) return;

        // ���������� ��������� �� ����������� ������
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        if (audioSrc == null) return;

        musicVolume = volume;
        audioSrc.volume = musicVolume; // ��������� ���������
        PlayerPrefs.SetFloat("MusicVolume", musicVolume); // ���������� ���������
    }

    public float GetVolume()
    {
        return musicVolume; // ���������� ������� �������� ���������
    }
}
