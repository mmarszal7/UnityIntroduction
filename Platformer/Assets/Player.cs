using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;

    private float timeFromLastAttack = 1f;

    void Update()
    {
        // Attack
        timeFromLastAttack += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeFromLastAttack > 0.5f)
        {
            animator.SetTrigger("attack");
            timeFromLastAttack = 0f;
        }

        // Jump
        var jump = false;
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            jump = true;
        }

        // Move
        var move = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));

        controller.Move(move * 0.1f, false, jump);
    }
}
