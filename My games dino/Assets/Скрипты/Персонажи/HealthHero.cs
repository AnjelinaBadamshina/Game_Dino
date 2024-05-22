using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HealthHero : MonoBehaviour
{
    public static int maxHealth { get; private set; } = 3; // Максимальное здоровье каждого персонажа
    public static int totalHealth { get; private set; } // Текущее здоровье

    private Animator animator;

    public LossSettings lossSettings;

    [SerializeField] private CameraController cameraController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        totalHealth = maxHealth; // Установим здоровье при старте игры
    }

    public void SetHealth(int bonusHealth)
    {
        totalHealth += bonusHealth; // Увеличиваем здоровье при лечении

        if (totalHealth > maxHealth)
        {
            totalHealth = maxHealth; // Не даем здоровью превысить максимальное значение
        }

        if (bonusHealth < 0)
        {
            animator.SetTrigger("Pain");
            cameraController.Reset();

        }

        if (totalHealth <= 0)
        {
            Die(); // Если здоровье заканчивается, вызываем метод смерти
        }
    }

    void Die()
    {
        if (lossSettings != null)
            lossSettings.LossPressed();
    }
}
