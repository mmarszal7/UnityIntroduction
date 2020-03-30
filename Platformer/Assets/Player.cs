using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;

    public AudioSource attackSound;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemies;
    public float speed = 0.2f;

    private float timeFromLastAttack = 1f;

    void Update()
    {
        // Attack
        timeFromLastAttack += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeFromLastAttack > 0.4f)
        {
            animator.SetTrigger("attack");
            attackSound.Play();
            timeFromLastAttack = 0f;

            Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemies).ToList().ForEach(e => e.GetComponent<Guard>().Damaged());
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

        controller.Move(move * speed, false, jump);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Damaged()
    {
        animator.SetTrigger("damaged");
    }
}
