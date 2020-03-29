using UnityEngine;

public class Guard : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public float attackRange = 0.25f;
    public float speed = 2f;

    private float health = 100f;
    private float timeFromLastAttack = 1f;
    private Player player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        timeFromLastAttack += Time.deltaTime;

        if (health <= 0 || timeFromLastAttack < 0.5f)
            return;

        LookAtPlayer();
        var target = new Vector2(player.transform.position.x, rigidBody.position.y);
        var newPos = Vector2.MoveTowards(rigidBody.position, target, speed * Time.fixedDeltaTime);
        rigidBody.MovePosition(newPos);

        if (Vector2.Distance(player.transform.position, rigidBody.position) <= attackRange && timeFromLastAttack > 0.5f)
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

    public bool isFlipped = false;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
