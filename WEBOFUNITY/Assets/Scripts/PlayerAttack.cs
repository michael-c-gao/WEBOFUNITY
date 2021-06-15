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

    // Start is called before the first frame update
    void Start()
    {

        isAttacking = false;
        statsScript = this.GetComponentInParent<PlayerStats>();
        currentAttack = statsScript.getDamage();

    }

    // Update is called once per frame
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
            if (other.transform.CompareTag("hello"))
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
                    statsScript.setHealth(currentHealth + 80f);
                }

            }
        }

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
                    statsScript.setHealth(currentHealth + 80f);
                }

            }
        }
        isAttacking = false;

    }

                





            
        
    
}