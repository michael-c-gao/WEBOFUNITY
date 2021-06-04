using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private AudioSource spiderAttackingAudioSource;
    public AudioClip spiderAttackingSound;

    Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        spiderAttackingAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused && !GameOverScreen.isGameOver)
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

            if (characterAnimator.GetBool("isAttacking"))
            {
                if (!spiderAttackingAudioSource.isPlaying)
                {
                    spiderAttackingAudioSource.clip = spiderAttackingSound;
                    spiderAttackingAudioSource.Play();
                }
            }

            if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spider_Attack_1")
                && characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                characterAnimator.SetBool("isAttacking", false);
            }

        }
    }
}
