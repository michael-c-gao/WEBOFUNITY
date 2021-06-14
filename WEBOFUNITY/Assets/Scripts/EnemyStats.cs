using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public GameObject Player;


    public float BaseValue;
    public float StartingHealth;
    public float StartingAttack;

    public float health;
    public float attack;

    
    // Start is called before the first frame update
    void Start()
    {

        health = StartingHealth;
        attack = StartingAttack;

        //display health as a bar

    }

    // Update is called once per frame
   
        

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