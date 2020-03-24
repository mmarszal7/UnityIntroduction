using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rigidbody;

    private Vector3 velocity;

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
        print(triggerEvent.gameObject.name);
        if (triggerEvent.gameObject.tag.Equals("Coin"))
            Destroy(triggerEvent.gameObject);
    }
}
