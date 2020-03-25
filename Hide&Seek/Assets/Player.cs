using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rBody;
    private Vector3 velocity;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        var direction = input.normalized;
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        rBody.position += velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider triggerEvent)
    {
        print(triggerEvent.gameObject.name);
        if (triggerEvent.gameObject.name.Equals("FinishPoint"))
            print("Win!");
    }
}
