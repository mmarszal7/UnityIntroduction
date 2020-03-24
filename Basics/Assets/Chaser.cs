using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform playerTransform;

    public float speed = 7f;

    private Rigidbody rigidbody;

    private Vector3 velocity;

    private Vector3 displacementFromPlayer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        displacementFromPlayer = playerTransform.position - transform.position;
        velocity = displacementFromPlayer.normalized * speed;
    }

    void FixedUpdate()
    {
        if (displacementFromPlayer.magnitude > 1.5)
            rigidbody.position += velocity * Time.fixedDeltaTime;
    }
}
