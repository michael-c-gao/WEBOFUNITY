using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackCD = 0;
    public bool inRange = false;

    public GameObject Player;
    float currentPlayerHealth = 0f;

    float currentAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {

        currentAttack = this.GetComponentInParent<EnemyStats>().attack;

    }

    // Update is called once per frame
    void Update()
    {

        inRange = this.transform.parent.GetComponentInParent<EnemyController>().inAttackRange;
        print(inRange);

    }

    void FixedUpdate()
    {

        if (attackCD < 0)
        {
            attackCD += 1;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (inRange && attackCD >= 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                currentPlayerHealth = Player.GetComponent<PlayerStats>().getHealth();
                print(currentPlayerHealth);
                Player.GetComponent<PlayerStats>().setHealth(currentAttack);
                print(currentPlayerHealth);
                attackCD = -100;
            }
        }
    }
}
