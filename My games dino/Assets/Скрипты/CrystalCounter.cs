using UnityEngine;
using UnityEngine.UI;

public class CrystalCounter : MonoBehaviour
{
    public int crystal = 0;         // ���������� ��� �������� ���������� ����������� ����������
    public Text crystalText;        // ������ �� ��������� ����, ������������ ���������� ����������


    // ����� ��� ���������� ���������� ���������� � ���������� ���������� ����
    public void IncreaseCrystalCount()
    {
        if (crystal <= 3)
        {
            crystal = crystal+1;                      // ����������� ������� ����������
            Debug.Log(crystal);
        }

        crystalText.text = crystal.ToString();   // ��������� ��������� ����, ������������ ���������� ����������
    }
}


