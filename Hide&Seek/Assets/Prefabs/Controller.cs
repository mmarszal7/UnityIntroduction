using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10f;

    private Camera viewCamera;
    private Rigidbody rigidBody;
    private Vector3 velocity;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        var direction = input.normalized;
        velocity = direction * speed;

        var mousePosition = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        mousePosition.y = 0.0f;
        transform.LookAt(mousePosition + Vector3.up * transform.position.y);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
    }
}