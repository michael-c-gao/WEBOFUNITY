using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleAnimationManager : MonoBehaviour
{

    bool walkTrigger = false;
    bool attackTrigger = false;
    int attackTimer = 0;

    Animator beetleAnimator;

   
    void Start()
    {
        
        beetleAnimator = GetComponent<Animator>();

    }

    
    void Update()
    {
        walkTrigger = this.GetComponentInParent<EnemyController>().isChasing;
        attackTrigger = this.GetComponentInChildren<EnemyAttack>().initiateAttack;
        attackTimer = this.GetComponentInChildren<EnemyAttack>().attackCD;

        if (walkTrigger)
        {
            beetleAnimator.SetBool("isAlert", true);
        }
        else
        {
            beetleAnimator.SetBool("isAlert", false);
        }

        if(attackTrigger && (attackTimer >= 0))
        {
            beetleAnimator.SetBool("inBiteRange", true);
        }
        else
        {
            beetleAnimator.SetBool("inBiteRange", false);
        }

    }
}
