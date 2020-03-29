using UnityEngine;

public class Guard : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public float attackRange = 0.25f;

    private float health = 100f;
    private float timeFromLastAttack = 1f;
    private Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (health <= 0)
            return;

        var target = new Vector2(player.transform.position.x + attackRange, rigidBody.position.y);
        var newPos = Vector2.MoveTowards(rigidBody.position, target, 2f * Time.fixedDeltaTime);
        rigidBody.MovePosition(newPos);

        timeFromLastAttack += Time.deltaTime;
        if (Vector2.Distance(player.transform.position, rigidBody.position) <= attackRange + 0.05f && timeFromLastAttack > 0.5f)
        {
            player.Damaged();
            animator.SetTrigger("attack");
            timeFromLastAttack = 0f;
        }
    }

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
