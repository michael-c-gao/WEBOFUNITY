using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioClip beetleAttackSound;
    private AudioSource beetleAttackAudioSource;
    
    public int attackCD = 0;
    public bool inRange = false;
    //public float attackDelay;
    //public bool initiateAttack = false;

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

    }

    void FixedUpdate()
    {

        if (attackCD < 0)
        {
            attackCD += 1;
        }

        //code below must trigger after onTriggerStay       move this to update potentially so theres no delay

        //if(initiateAttack = true{
        //      //freeze movement of the beetle
        //      attackWindup();
        //      initiateAttack = false;
        //      }
        
    }

    void attackWindup()
    {
        //attackDelay = Time.time;        //set time delay; might need to place this in fixedupdate tied to ontriggerstay somehow
        //begin attack animation
        //if (current Time.time == attackDelay + durationOfAnimation) {     //(at end of animation) 
        //      attackPlayer()
        //      }

    }

    void attackPlayer()
    {
        currentPlayerHealth = Player.GetComponent<PlayerStats>().getHealth();
        print(currentPlayerHealth);
        Player.GetComponent<PlayerStats>().setHealth(currentAttack);
        print(currentPlayerHealth);
        attackCD = -100;
        if (!beetleAttackAudioSource.isPlaying)
        {
            beetleAttackAudioSource.clip = beetleAttackSound;
            beetleAttackAudioSource.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (inRange && attackCD >= 0)
        {
            if (other.transform.CompareTag("Player"))
            {
                attackPlayer();                                 //comment this out after attack delat is complete
                //initiateAttack = true;
            }
        }
    }
}


//for time delay in attack: https://answers.unity.com/questions/1500346/i-am-trying-to-make-my-enemy-ai-have-an-attack-del.html
//its not the same but essentially we want the delay to occur
//prior to the attack not inbetween

//processof thot
//ontriggerstay ->trigger animation +timer ->damage calculation afteer animation ends(timer ends) and IF PLAYER IS STILL IN ATTACKSPHERE
//not sure how to do the last one, occurs in ontriggerstay so obtain a bool from there to check if player is still in range