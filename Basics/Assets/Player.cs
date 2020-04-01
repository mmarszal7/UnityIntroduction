using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public GameObject coin;
    public Camera Camera;
    private CharacterController CharacterController;

    private float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CharacterController = GetComponent<CharacterController>();

        for (var i = 0; i < 5; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 90)));
        }
    }

    void Update()
    {
        // Movement
        var move = transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");
        CharacterController.Move(move * speed * Time.deltaTime);

        // Camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void OnTriggerEnter(Collider triggerEvent)
    {
        if (triggerEvent.gameObject.tag.Equals("Coin"))
            Destroy(triggerEvent.gameObject);

        Instantiate(coin, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 90)));
    }
}
