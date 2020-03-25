using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum WrappingMode
{
    Collision = -1,
    Wrapping = 1
}

public class Player : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text score;

    public float speed = 10f;
    public float spawningSpeed = 2.0f;
    public GameObject FallingObject;
    public WrappingMode wrappingMode;

    private Rigidbody rBody;
    private Vector3 velocity;
    private float screenHalfWidth;

    private void Start()
    {
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + ((float)wrappingMode * transform.localScale.x / 2.0f);

        rBody = GetComponent<Rigidbody>();
        InvokeRepeating("CreateFallingObject", 0.0f, 1.0f / spawningSpeed);
    }

    private void Update()
    {
        var input = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
        var direction = input.normalized;
        velocity = direction * speed;

        if (gameOverScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        rBody.position += velocity * Time.fixedDeltaTime;

        if (rBody.position.z > screenHalfWidth)
            rBody.position = new Vector3(0, -8, (float)wrappingMode * -screenHalfWidth);
        if (rBody.position.z < -screenHalfWidth)
            rBody.position = new Vector3(0, -8, (float)wrappingMode * screenHalfWidth);
    }

    private void OnTriggerEnter(Collider triggerEvent)
    {
        if (triggerEvent.gameObject.tag.Equals("FallingObject"))
        {
            transform.Translate(new Vector3(0, -10));
            gameOverScreen.SetActive(true);
            score.text = Time.timeSinceLevelLoad.ToString("F2");
        }
    }

    private void CreateFallingObject()
    {
        var createdObject = Instantiate(
            FallingObject,
            new Vector3(0, Camera.main.orthographicSize + 2, Random.Range(-screenHalfWidth, screenHalfWidth)),
            Quaternion.Euler(new Vector3(Random.Range(-30.0f, 30.0f), 0, 0))
        );

        createdObject.transform.localScale += new Vector3(0, Random.Range(0.0f, 3.0f), Random.Range(0.0f, 3.0f));
    }
}
