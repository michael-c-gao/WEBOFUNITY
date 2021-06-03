using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public AudioClip beetleWalkingSound;
    private AudioSource beetleWalkingAudioSource;

    public bool isDead = false;
    int deathCounter = 0;

    public bool inAttackRange = false;

    public bool isChasing = false;
    public float lookRadius = 10f;
    public GameObject Player;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    // Source of reference: https://youtu.be/xppompv1DBg
    void Start()
    {
        target = Player.transform;
        agent = GetComponent<NavMeshAgent>();
        beetleWalkingAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        target = Player.transform;
        float distance = Vector3.Distance(target.position, transform.position);

        isChasing = chaseStatus(distance);
        //print(isChasing);

        if(isChasing)
        {
            agent.SetDestination(target.position);
            
            if(distance <= agent.stoppingDistance)
            {
                //Face player
                FaceTarget();
                inAttackRange = true;
                agent.isStopped = true;                                     //want the navmeshagent to stop until the animation and attack in manager and enemyattack are complete

            }
            else
            {
                if (!beetleWalkingAudioSource.isPlaying)
                {
                    beetleWalkingAudioSource.clip = beetleWalkingSound;
                    beetleWalkingAudioSource.Play();
                }
                inAttackRange = false;
                agent.isStopped = false;
            }
        }

    }




    bool chaseStatus(float distance)
    {
        return (distance <= lookRadius);
    }

    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
