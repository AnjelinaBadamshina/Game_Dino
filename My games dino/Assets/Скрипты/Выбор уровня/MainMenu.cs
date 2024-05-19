using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class MainMenu : MonoBehaviour
{
    public Button[] lvls;

    public Button level2B; // ������, ������� ��������� ������� 2
    public Button level3B; // ������, ������� ��������� ������� 3
    int levelComplete; // �������, �� �������� ����� �����, ����������� � PlayerPrefs

    private void Start()
    {

        // ���� ���������� �� ��������������� ������� �������

        levelComplete = PlayerPrefs.GetInt("levelComplete", 0);

        level2B.interactable = false;
        level3B.interactable = false;

        switch (levelComplete)
        {
            case 3:
                level2B.interactable = true; // �������������� ������ ��� ������� ������
                break;
            case 4:
                level2B.interactable = true; // �������������� ������ ��� ������� ������
                level3B.interactable = true; // �������������� ������ ��� �������� ������
                break;
            case 5:
                level2B.interactable = true; // �������������� ������ ��� ������� ������
                level3B.interactable = true; // �������������� ������ ��� �������� ������
                break;
        }



        // ���� ���������� �� ��������������� ��������� ��������� �� �������

        for (int i = 3; i < 6; i++)
        {

            if (PlayerPrefs.HasKey("CrystalRecordLevel" + i))
            {

                if (PlayerPrefs.GetInt("CrystalRecordLevel" + i) == 1)
                {
                    lvls[i - 3].transform.GetChild(0).gameObject.SetActive(true);
                    lvls[i - 3].transform.GetChild(1).gameObject.SetActive(false);
                    lvls[i - 3].transform.GetChild(2).gameObject.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("CrystalRecordLevel" + i) == 2)
                {
                    lvls[i - 3].transform.GetChild(0).gameObject.SetActive(true);
                    lvls[i - 3].transform.GetChild(1).gameObject.SetActive(true);
                    lvls[i - 3].transform.GetChild(2).gameObject.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("CrystalRecordLevel" + i) == 3)
                {
                    lvls[i - 3].transform.GetChild(0).gameObject.SetActive(true);
                    lvls[i - 3].transform.GetChild(1).gameObject.SetActive(true);
                    lvls[i - 3].transform.GetChild(2).gameObject.SetActive(true);
                }


            }

            if (!PlayerPrefs.HasKey("CrystalRecordLevel" + i) || PlayerPrefs.GetInt("CrystalRecordLevel" + i) == 0)
            {
                lvls[i - 3].transform.GetChild(0).gameObject.SetActive(false);
                lvls[i - 3].transform.GetChild(1).gameObject.SetActive(false);
                lvls[i - 3].transform.GetChild(2).gameObject.SetActive(false);
            }




        }


    }

    // �����, ������� ��������� ������� �� ��� �������
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level); // ��������� ����� �� �������
    }

    // ����� ���� ������ � ���������� ������
    public void Reset()
    {

        level2B.interactable = false; // ������������� ������ ��� ������� ������
        level3B.interactable = false; // ������������� ������ ��� �������� ������

        // ������� ������ � ���������� �������
        PlayerPrefs.DeleteKey("levelComplete");

        // ������� ������ � ���������� ��������� ��������� ��� ������� ������
        for (int i = 3; i < 6; i++)
        {

            // ������� ������ � ���������� ��������� ��������� ��� �������� ������
            PlayerPrefs.DeleteKey("CrystalRecordLevel" + i);
        }

        PlayerPrefs.Save(); // ��������� ��������� � PlayerPrefs

        // ��������� ����������� ��������� �� ������� �������
        for (int i = 3; i < 6; i++)
        {
            lvls[i - 3].transform.GetChild(0).gameObject.SetActive(false);
            lvls[i - 3].transform.GetChild(1).gameObject.SetActive(false);
            lvls[i - 3].transform.GetChild(2).gameObject.SetActive(false);
        }


    }
}
