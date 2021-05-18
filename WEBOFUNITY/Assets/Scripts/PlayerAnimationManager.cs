using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            characterAnimator.SetBool("isAttacking", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            characterAnimator.SetBool("isAttacking", false);
        }
        else if (   
               Input.GetKey("w")
            || Input.GetKey("a")
            || Input.GetKey("s")
            || Input.GetKey("d")
            )
        {
            characterAnimator.SetBool("isWalking", true);
        }
        else
        {
            characterAnimator.SetBool("isWalking", false);
        }
    }
}
