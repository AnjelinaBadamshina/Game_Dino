using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalPicker : MonoBehaviour
{
    private CrystalCounter crystalCounter; // ������ �� ��������� ������ CrystalCounter

    public AudioSource Audio;

    private void Start()
    {
        // ������� ������ � �������� CrystalCounter � �������� ������ �� ��� ��������� CrystalCounter
        crystalCounter = FindObjectOfType<CrystalCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, ����� �� ������ � �������, ������� ��������� ���
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // ����������� ������� ���������� � ������ CrystalCounter
            crystalCounter.IncreaseCrystalCount();

            // ������������� ����
            Audio.Play();

            // ���������� ������ ����� �������������
            Destroy(gameObject);
        }
    }
}
