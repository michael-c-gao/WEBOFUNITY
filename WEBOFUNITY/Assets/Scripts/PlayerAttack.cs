using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool isAttacking;
    public GameObject spider;
    public GameOverScreen GameOverScreen;

    float enemyHealth;
    float currentHealth;
    float currentAttack;

    private PlayerStats statsScript;

    void Start()
    {

        isAttacking = false;
        statsScript = this.GetComponentInParent<PlayerStats>();
        currentAttack = statsScript.getDamage();

    }

    void Update()
    {


        if (Input.GetMouseButtonDown(1))
        {
            isAttacking = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAttacking = false;
        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (isAttacking)
        {
            if (other.transform.CompareTag("Beetle"))
            {
                enemyHealth = other.GetComponentInChildren<EnemyStats>().getHealth();
                other.GetComponentInChildren<EnemyStats>().setHealth(enemyHealth - currentAttack);
                if (other.GetComponentInChildren<EnemyStats>().getHealth() <= 0f)
                {
                    if (other.gameObject.transform.parent != null)
                    {
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }

                    for (int i = 0; i < other.gameObject.transform.childCount; i++)
                    {
                        Destroy(other.gameObject.transform.GetChild(i).gameObject);
                    }

                    Object.Destroy(other.gameObject, 0.25f);

                    currentHealth = statsScript.getHealth();
                    statsScript.setHealth(currentHealth + 60f);
                }
            }

            if (other.transform.CompareTag("Boss"))
            {
                enemyHealth = other.GetComponentInChildren<EnemyStats>().getHealth();
                other.GetComponentInChildren<EnemyStats>().setHealth(enemyHealth - currentAttack);
                if (other.GetComponentInChildren<EnemyStats>().getHealth() <= 0f)
                {
                    GameOverScreen.Setup();
                    if (other.gameObject.transform.parent != null)
                    {
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }

                    for (int i = 0; i < other.gameObject.transform.childCount; i++)
                    {
                        Destroy(other.gameObject.transform.GetChild(i).gameObject);
                    }

                    Object.Destroy(other.gameObject, 0.25f);

                    currentHealth = statsScript.getHealth();
                    statsScript.setHealth(currentHealth + 100f);
                }
                
            }
            isAttacking = false;
        }
    }



 
}