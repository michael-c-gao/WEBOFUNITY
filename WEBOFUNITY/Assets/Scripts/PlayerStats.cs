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
    public float StartingSpeed;                

    public static float health;
    public float damage;
    public float speed;

    void Start()
    {
        health = StartingHealth;
        damage = StartingDamage;
        speed = StartingSpeed;
    }

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

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float getSpeed()
    {
        return speed;
    }
}
