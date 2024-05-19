using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossSettings : MonoBehaviour
{
    public GameObject VictoryPanel;

    public void LossPressed()
    {
        VictoryPanel.SetActive(true);
        Time.timeScale = 0f; // ������������� ����� ��� ����������� ������
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // ������������ �����
    }

    public void ChangeScrene()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

}
