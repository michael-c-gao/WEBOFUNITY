using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

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
    }

    // Update is called once per frame
    void Update()
    {
        target = Player.transform;
        float distance = Vector3.Distance(target.position, transform.position);

        isChasing = chaseStatus(distance);
        print(isChasing);

        if(isChasing)
        {
            agent.SetDestination(target.position);
            
            if(distance <= agent.stoppingDistance)
            {
                //Face player
                FaceTarget();
                inAttackRange = true;

            }
            else
            {
                inAttackRange = false;
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
