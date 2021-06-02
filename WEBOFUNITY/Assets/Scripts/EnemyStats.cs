using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public GameObject Player;

    public float BaseValue;
    public float StartingHealth = 50;
    public float StartingAttack = 20;
    public float StartingSpeed = 3;       // speed doesnt do anything so far

    public float health;
    public float attack;
    public float speed;

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
        speed = StartingSpeed;

        //display health as a bar

    }

    // Update is called once per frame
    void Update()
    {
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
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float getSpeed()
    {
        return speed;
    }
}