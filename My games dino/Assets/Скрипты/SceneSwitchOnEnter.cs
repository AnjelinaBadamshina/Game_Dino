using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchOnEnter : MonoBehaviour
{
    void Update()
    {
        // ���������, ������ �� ������� Enter (KeyCode.Return ��� ��������� � ���������� ����������)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // ������������� �� ��������� �����
            SceneManager.LoadScene(1); // ��� SceneManager.LoadScene(sceneIndex);
        }
    }
}



