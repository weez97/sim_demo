using EventTools;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Animator))]
public class AnimationEventHandler : MonoBehaviour
{
    private Animator anim;
    private SortingGroup sortingGroup;

    //use this for initialisation
    private void Awake()
    {
        anim = GetComponent<Animator>();
        sortingGroup = GetComponent<SortingGroup>();
    }

    private void OnEnable()
    {
        CustomEventHandler.MoveEvent += UpdateAnimator;
    }

    private void OnDisable()
    {
        CustomEventHandler.MoveEvent -= UpdateAnimator;
    }

    private void UpdateAnimator(float x, float y, Player.State state, Player.Direction dir, float posY)
    {
        // movement
        anim.SetFloat("xInput", x);
        anim.SetFloat("yInput", y);

        // direction
        anim.SetInteger("direction", (int)dir);

        switch (state)
        {
            case Player.State.idle:
                anim.SetTrigger("idle");
                break;
            case Player.State.walking:
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                break;
            case Player.State.running:
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", true);
                break;
        }

        // layering
        // sortingGroup.sortingOrder = -(int)posY;
    }
}
