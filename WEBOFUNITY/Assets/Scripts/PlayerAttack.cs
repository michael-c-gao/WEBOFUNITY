using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isAttacking;
    public GameObject player;
    public GameObject spider;

    private PlayerStats statsScript;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        statsScript = player.GetComponent<PlayerStats>();
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
            if (other.transform.CompareTag("Ant"))
            {
                Object.Destroy(other.gameObject, 0.25f);
                statsScript.setDamage(statsScript.getDamage() + 1);
            }
        }
    }
}