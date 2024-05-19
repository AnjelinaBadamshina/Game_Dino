using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class MainMenu : MonoBehaviour
{
    public Button[] lvls;

    public Button level2B; // Кнопка, которая загружает уровень 2
    public Button level3B; // Кнопка, которая загружает уровень 3
    int levelComplete; // Уровень, до которого игрок дошел, сохраненный в PlayerPrefs

    private void Start()
    {

        // Блок отвечающий за разблокирование конопок уровней

        levelComplete = PlayerPrefs.GetInt("levelComplete", 0);

        level2B.interactable = false;
        level3B.interactable = false;

        switch (levelComplete)
        {
            case 3:
                level2B.interactable = true; // Разблокировать кнопку для второго уровня
                break;
            case 4:
                level2B.interactable = true; // Разблокировать кнопку для второго уровня
                level3B.interactable = true; // Разблокировать кнопку для третьего уровня
                break;
            case 5:
                level2B.interactable = true; // Разблокировать кнопку для второго уровня
                level3B.interactable = true; // Разблокировать кнопку для третьего уровня
                break;
        }



        // Блок отвечающий за разблокирование кристалов собранных на уровнях

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

    // Метод, который загружает уровень по его индексу
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level); // Загружает сцену по индексу
    }

    // Сброс всех данных и блокировка кнопок
    public void Reset()
    {

        level2B.interactable = false; // Заблокировать кнопку для второго уровня
        level3B.interactable = false; // Заблокировать кнопку для третьего уровня

        // Удаляем данные о пройденных уровнях
        PlayerPrefs.DeleteKey("levelComplete");

        // Удаляем данные о количестве собранных кристалов для каждого уровня
        for (int i = 3; i < 6; i++)
        {

            // Удаляем данные о количестве собранных кристалов для текущего уровня
            PlayerPrefs.DeleteKey("CrystalRecordLevel" + i);
        }

        PlayerPrefs.Save(); // Сохраняем изменения в PlayerPrefs

        // Обновляем отображение кристалов на кнопках уровней
        for (int i = 3; i < 6; i++)
        {
            lvls[i - 3].transform.GetChild(0).gameObject.SetActive(false);
            lvls[i - 3].transform.GetChild(1).gameObject.SetActive(false);
            lvls[i - 3].transform.GetChild(2).gameObject.SetActive(false);
        }


    }
}
