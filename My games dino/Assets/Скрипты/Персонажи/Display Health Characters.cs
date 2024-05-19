using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class DisplayHealthCharacters : MonoBehaviour
{
    private Slider slider;

   public void Start()
    {
        SetMaxHealth(HealthHero.maxHealth);
    }

    public void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void Update()
    {
         SetHealth(HealthHero.totalHealth);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }


}
