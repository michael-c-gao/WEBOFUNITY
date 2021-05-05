using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI LifestealText;
    public TextMeshProUGUI SpeedText;

    public float StartingHealth = 100;
    public float StartingDamage = 10;
    public float StartingLifesteal = 0;
    public float StartingSpeed = 10;

    private float health;
    private float damage;
    private float lifesteal;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        health = StartingHealth;
        damage = StartingDamage;
        lifesteal = StartingLifesteal;
        speed = StartingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + health;
        DamageText.text = "Damage: " + damage;
        LifestealText.text = "Lifesteal: " + lifesteal;
        SpeedText.text = "Speed: " + speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }


    //Stat setters and getters
    public void setHealth(float newHealth)
    {
        health = newHealth;
    }
    public float getHealth()
    {
        return health;
    }
    public void setDamage(float newDamage)
    {
        damage = newDamage;
    }
    public float getDamage()
    {
        return damage;
    }
    public void setLifesteal(float newLifesteal)
    {
        lifesteal = newLifesteal;
    }
    public float getLifesteal()
    {
        return lifesteal;
    }
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float getSpeed()
    {
        return speed;
    }
}
