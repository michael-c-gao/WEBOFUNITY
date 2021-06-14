using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioClip beetleAttackSound;
    private AudioSource beetleAttackAudioSource;

    public int attackCD = 0;
    
    public float attackDelay;
    public float animationEnd;
    public float animationDuration;
    
    public bool inRange = false;
    public bool inAttackRange = false;
    public bool initiateAttack = false;
    public bool stopMove = false;
    bool repeatAttack = false;

    public GameObject Player;
    float currentPlayerHealth = 0f;

    float currentAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {

        currentAttack = this.GetComponentInParent<EnemyStats>().attack;
        beetleAttackAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        inRange = this.transform.parent.GetComponentInParent<EnemyController>().inAttackRange;
        animationEnd = Time.time;

        if (initiateAttack == !stopMove) {
            //movement of the beetle triggered to stop in enemyController through this bool
            attackDelay = Time.time;
            stopMove = true;
            //attackWindup(attackDelay);
            
            //print(initiateAttack);
        }

        if ((animationEnd >= (attackDelay + animationDuration)) && stopMove ) // at animation point where attack makes contact (frame 45-50 beetle)        //notworking
        {
            if (inAttackRange)
            {
                attackPlayer();
                stopMove = false;
                repeatAttack = true;
            }
            initiateAttack = false;

        }


    }

        void FixedUpdate()
    {

        if (attackCD < 0)
        {
            attackCD += 1;
        }

    }

    void attackPlayer()
    {
        currentPlayerHealth = Player.GetComponent<PlayerStats>().getHealth();
        Player.GetComponent<PlayerStats>().setHealth(currentPlayerHealth - currentAttack);
        attackCD = -100;
        if (!beetleAttackAudioSource.isPlaying)
        {
            beetleAttackAudioSource.clip = beetleAttackSound;
            beetleAttackAudioSource.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (inRange && attackCD >= 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                initiateAttack = true;                            // animation begins in animationController here
                inAttackRange = true;
                print("entered attack");
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        
        if (inRange && attackCD >= 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                initiateAttack = true;                            // animation begins in animationController here
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        print("exit attack");
        inAttackRange = false;
    }   

}
