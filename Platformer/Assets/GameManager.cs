using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Guard;
    public GameObject Player;
    public Camera camera;

    private float spawnDistance = 2;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, 1.0f);
    }

    void Update()
    {
        camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.6f, -10);
    }

    void SpawnEnemy()
    {
        var spawnPosition = Player.transform.position + new Vector3(spawnDistance, 0f, 0f);
        Instantiate(Guard, spawnPosition, new Quaternion(0, 0, 0, 0));
    }
}
