using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // ���������� ������� ��������, ����� ���������, ��� ���������� ������ ���� ��������� LevelController
    public static LevelController instance = null;

    // ������ ������� �����/������
    int sceneIndex;
    // ����� ������� �������, ������� ��� �������, ����������� � PlayerPrefs
    int levelComplete;

    // ������ �� ������ ��� �����, ������� ��������� ����������� ������ � UI
    public VictorySettings victorySettings;

    int Crystal;

    private CrystalCounter crystalCounter; // ������ �� ��������� CrystalCounter

    // ����� ��� ������������, ��������� �� ��� ��������� �������
    private bool character1Finished = false;
    private bool character2Finished = false;

    // ����� Unity, ������� ���������� ��� ������������� �������
    void Start()
    {
        // ���� ��� ������ ��������� ���������, ������ ��� ����������
        if (instance == null)
        {
            instance = this;
        }

        // �������� ������ ������� �����
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ��������� �������� ������ �������� ����������� ������ �� PlayerPrefs
        levelComplete = PlayerPrefs.GetInt("levelComplete", 0);

        crystalCounter = FindObjectOfType<CrystalCounter>(); // ������� ������ CrystalCounter � �����

    }


    // ����� ��� �������, ��� �������� �������� �������
    public void CharacterFinished(int characterNumber)
    {
        // ���� ������ �������� �������� �������
        if (characterNumber == 1)
        {
            character1Finished = true;
        }
        // ���� ������ �������� �������� �������
        else if (characterNumber == 2)
        {
            character2Finished = true;
        }

        // ���� ��� ��������� ��������� �������, ��������� ������ ������
        if (character1Finished && character2Finished)
        {
            ShowVictoryPanel();
        }
    }

    // ����� ��� �������, ��� �������� ������� �������� ����
    public void CharacterLeft(int characterNumber)
    {
        // ���� ������ �������� ������� �������� ����
        if (characterNumber == 1)
        {
            character1Finished = false;
        }
        // ���� ������ �������� ������� �������� ����
        else if (characterNumber == 2)
        {
            character2Finished = false;
        }
    }

    // ����� ��� ����������� ������ ������ � ���������� ������� ������
    private void ShowVictoryPanel()
    {
        // ���������, �������� �� ������ victorySettings
        if (victorySettings != null)
        {
            // ���������� ������ ������ ��� ��������� ������ ������
            victorySettings.VictoryPressed();

            // ���� ������� ������� ������ ������ �������� �����������, ��������� �������� levelComplete
            if (sceneIndex > levelComplete)
            {
                PlayerPrefs.SetInt("levelComplete", sceneIndex); // ��������� ����� ���������� �������
                PlayerPrefs.Save(); // ����������, ��� ������ ���������
            }

            // ����������, ����� �� ������������ ��� �������������� ������ "��������� �������"
            if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1) // ���������, ���� �� ��������� �������
            {
                victorySettings.EnableNextLevelButton(); // ��������� ������� �� ��������� �������
            }
            else // ���� ��� ��������� �������
            {
                victorySettings.DisableNextLevelButton(); // ������������ ������ "��������� ���9����"
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
