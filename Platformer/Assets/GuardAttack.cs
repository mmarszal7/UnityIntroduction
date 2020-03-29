using UnityEngine;

public class GuardAttack : StateMachineBehaviour
{
    private Rigidbody2D rigidBody;
    private Player player;
    private float attackRange = 0.3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindObjectOfType<Player>();
        rigidBody = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.transform.position, rigidBody.position) <= attackRange)
        {
            player.Damaged();
        }
    }
}
