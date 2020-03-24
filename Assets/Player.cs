using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rigidbody;

    private Vector3 velocity;

    public GameObject coin;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        var direction = input.normalized;
        velocity = direction * speed;
    }

    void FixedUpdate()
    {
        rigidbody.position += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider triggerEvent)
    {
        if (triggerEvent.gameObject.tag.Equals("Coin"))
            Destroy(triggerEvent.gameObject);

        Instantiate(coin, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 90)));
    }
}
