using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public GameObject Player;
    public GameOverScreen GameOverScreen;

    public float BaseValue;
    public float StartingHealth;
    public float StartingAttack;

    public float health;
    public float attack;

    //// These classes are to be used for the potential addition of scaling/modified enemy stats
    //public EnemyHealth(StartingHealth)
    //{
        
    //}

    //public EnemyAttack(StartingDamage)
    //{
    //    BaseValue = baseValue;
    //}

    //public EnemySpeed(StartingSpeed)
    //{
    //    BaseValue = baseValue;
    //}

    // Start is called before the first frame update
    void Start()
    {

        health = StartingHealth;
        attack = StartingAttack;

        //display health as a bar

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOverScreen.Setup();
        }
        //if enemy.attack triggers on player
        //  player.playerhealth -= enemy.attack
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
    public void setAttack(float newAttack)
    {
        attack = newAttack;
    }
    public float getAttack()
    {
        return attack;
    }
}