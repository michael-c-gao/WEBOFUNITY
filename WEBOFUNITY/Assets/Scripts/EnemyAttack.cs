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
        currentAttack = 20f;

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

        if ((animationEnd >= (attackDelay + animationDuration)) && stopMove) // at animation point where attack makes contact (frame 45-50 beetle)        //notworking
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

    //void attackWindup(float delay)
    //{

    //    while (stopMove)
    //    {
    //        if (Time.time == delay + animationDuration) // at animation point where attack makes contact (frame 45-50 beetle)
    //        {     
    //            attackPlayer();
    //            stopMove = false;
    //        }
    //    }
   
    //}

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
        inAttackRange = true;

        if (inRange && attackCD >= 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                initiateAttack = true;                            // animation begins in animationController here
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
        inAttackRange = false;
    }   

}

 

//for time delay in attack: https://answers.unity.com/questions/1500346/i-am-trying-to-make-my-enemy-ai-have-an-attack-del.html
//its not the same but essentially we want the delay to occur
//prior to the attack not inbetween

//processof thot
//ontriggerstay ->trigger animation +timer ->damage calculation afteer animation ends(timer ends) and IF PLAYER IS STILL IN ATTACKSPHERE
//not sure how to do the last one, occurs in ontriggerstay so obtain a bool from there to check if player is still in range