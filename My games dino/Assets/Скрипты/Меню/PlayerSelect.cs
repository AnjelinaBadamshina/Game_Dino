using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters; // ������ ��� �������� ����������
    private int index; // ������� ������ ���������� ���������
    [SerializeField] private string PrefName;

    private void Start()
    {
        index = PlayerPrefs.GetInt(PrefName, 0); // �������� ������ ���������� ��������� �� ����������
        characters = new GameObject[transform.childCount]; // �������������� ������ ���������� �������� ������ ���������� �������� ��������

        // ��������� ������ ����������
        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        // ��������� ��� ���������
        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        // �������� ��������� ��������
        if (index >= 0 && index < characters.Length)
        {
            characters[index].SetActive(true);
        }
    }

    // ����� ��� ������ ����������� ���������
    public void SelectLeft()
    {
        characters[index].SetActive(false); // ��������� �������� ���������
        index--; // ��������� ������
        if (index < 0) // ���� ������ ���� ������ ����, ��������� � ���������� ���������
        {
            index = characters.Length - 1;
        }
        characters[index].SetActive(true); // �������� ��������� ��������
        SaveCharacter(); // ��������� ���������� ���������
    }

    // ����� ��� ������ ���������� ���������
    public void SelectRight()
    {
        characters[index].SetActive(false); // ��������� �������� ���������
        index++; // ����������� ������
        if (index == characters.Length) // ���� ������ ������ ������������� ��������, ��������� � ������� ���������
        {
            index = 0;
        }
        characters[index].SetActive(true); // �������� ��������� ��������
        SaveCharacter(); // ��������� ���������� ���������
    }

    // ����� ��� ���������� ���������� ���������
    public void SaveCharacter()
    {
        PlayerPrefs.SetInt(PrefName, index); // ��������� ��������� �������� � PlayerPrefs
    }
}
