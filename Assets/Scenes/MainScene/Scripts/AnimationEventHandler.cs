using System.Collections;
using System.Collections.Generic;
using CharacterAnimator;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEventHandler : MonoBehaviour
{
    private Animator anim;

    //use this for initialisation
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MoveEvent += UpdateAnimator;
    }

    private void OnDisable()
    {
        EventHandler.MoveEvent -= UpdateAnimator;
    }

    private void UpdateAnimator(float x, float y, State state, Direction dir)
    {
        // movement
        anim.SetFloat("xInput", x);
        anim.SetFloat("yInput", y);

        // direction
        anim.SetInteger("direction", (int)dir);

        switch (state)
        {
            case State.idle:
                anim.SetTrigger("idle");
                break;
            case State.walking:
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                break;
            case State.running:
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);
                break;
        }

    }
}
