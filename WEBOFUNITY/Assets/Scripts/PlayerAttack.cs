using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isAttacking;
    public GameObject spider;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {        
        //transform.position = spider.transform.position + new Vector3(0f, 0.2f, 0.6f);
        //transform.rotation = spider.transform.rotation;

        if (Input.GetKeyDown("f"))
        {
            isAttacking = true;
        }
        else if (Input.GetKeyUp("f"))
        {
            isAttacking = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isAttacking)
        {
            if (other.transform.CompareTag("Enemy"))
            {
                other.transform.position += new Vector3(0, 0, 5);
                print("Working here on trigger");
            }
        }
    }
}
