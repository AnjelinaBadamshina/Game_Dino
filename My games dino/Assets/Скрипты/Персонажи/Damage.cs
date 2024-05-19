using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
    public Transform respawnPointPlayer1; // Первая точка возрождения
    public Transform respawnPointPlayer2; // Вторая точка возрождения
    public int collisionDamage;
    public string tagPlayer1;
    public string tagPlayer2;


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<HealthHero>() != null)
        {
            HealthHero healthManager = coll.gameObject.GetComponent<HealthHero>(); // Получаем компонент здоровья первого персонажа
            HealthHero healthManager2 = null;

            if (coll.gameObject.CompareTag(tagPlayer1))
                healthManager2 = GameObject.FindGameObjectWithTag(tagPlayer2).GetComponent<HealthHero>();
            else if (coll.gameObject.CompareTag(tagPlayer2))
                healthManager2 = GameObject.FindGameObjectWithTag(tagPlayer1).GetComponent<HealthHero>();

            // Применяем урон к обоим персонажам
            healthManager.SetHealth(- collisionDamage);

            // Перемещаем персонажей на их соответствующие точки возрождения
            if (coll.gameObject.CompareTag(tagPlayer1))
            {
                healthManager.transform.position = respawnPointPlayer1.position;
                healthManager2.transform.position = respawnPointPlayer2.position;
                
            }
            else if (coll.gameObject.CompareTag(tagPlayer2))
            {
                healthManager.transform.position = respawnPointPlayer2.position;
                healthManager2.transform.position = respawnPointPlayer1.position;
                
            }
            // Сохраняем здоровье после получения урона (если требуется)
            SaveLoadManager.SavePlayerHealth(HealthHero.totalHealth);

        }
    }

}
