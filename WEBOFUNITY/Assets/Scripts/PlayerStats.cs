using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public TextMeshProUGUI HealthText;

    public float StartingHealth;
    public float StartingDamage;
    public float StartingLifesteal;             //remove
    public float StartingSpeed;                 //remove

    public static float health;
    public float damage;
    public float lifesteal;
    public float speed;

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

        if(health <= 0)
        {
            GameOverScreen.Setup();
        }
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
