using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;

    private float timeFromLastAttack = 1f;

    void Update()
    {
        timeFromLastAttack += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeFromLastAttack > 0.5f)
        {
            animator.SetTrigger("attack");
            timeFromLastAttack = 0f;
        }

        var move = Input.GetAxisRaw("Horizontal");
        var jump = Input.GetAxisRaw("Jump") > 0.1;

        animator.SetFloat("speed", Mathf.Abs(move));
        if (jump)
            animator.SetTrigger("jump");

        controller.Move(move * 0.1f, false, jump);
    }
}
