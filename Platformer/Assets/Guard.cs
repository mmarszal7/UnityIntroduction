using UnityEngine;

public class Guard : MonoBehaviour
{
    public Animator animator;

    private float health = 100f;

    public void Damaged()
    {
        if (health <= 0)
            return;

        health -= 50f;
        animator.SetTrigger("damaged");

        if (health <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
