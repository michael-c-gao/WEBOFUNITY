using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool isAttacking;
    public GameObject spider;

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
            if (other.transform.CompareTag("Beetle"))
            {
                enemyHealth = other.GetComponentInChildren<EnemyStats>().getHealth();
                other.GetComponentInChildren<EnemyStats>().setHealth(enemyHealth - currentAttack);
                print("took damage");
                print(currentAttack);
                if (other.GetComponentInChildren<EnemyStats>().getHealth() == 0f)
                {
                    print("at 0 health");
                    Object.Destroy(other.gameObject, 0.25f);
                    currentHealth = statsScript.getHealth();
                    statsScript.setHealth(currentHealth + 100f);
                }
                // statsScript.setDamage(statsScript.getDamage() + 1);
            }

            isAttacking = false;
        }
    }
    //private bool isAttacking;
    //public GameObject player;
    //public GameObject spider;

    //private PlayerStats statsScript;
    //float playerAttack = 0f;

    //float enemyHealth = 0f;

    //public GameObject Beetle;

    //// Start is called before the first frame update
    //void Start()
    //{

    //    isAttacking = false;
    //    statsScript = player.GetComponent<PlayerStats>();
    //    playerAttack = player.GetComponent<PlayerStats>().damage;

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        isAttacking = true;
    //    }
    //    else if (Input.GetMouseButtonUp(1))
    //    {
    //        isAttacking = false;
    //    }

    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (isAttacking)
    //    {
    //        if (other.transform.CompareTag("Beetle"))
    //        {
    //            //object.destroy(other.gameobject, 0.25f);                //want this to occur after death animatin
    //            enemyHealth = Beetle.GetComponentInChildren<EnemyStats>().getHealth();

    //            Beetle.GetComponentInChildren<EnemyStats>().setHealth(enemyHealth - playerAttack);

    //            if ((Beetle.GetComponentInChildren<EnemyStats>().getHealth()) == 0)
    //            {
    //                Object.Destroy(other.gameObject, 0.25f);
    //            }
    //            statsScript.setDamage(statsScript.getDamage() + 1);
    //        }
    //    }
    //}
}