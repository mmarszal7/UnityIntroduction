using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Guard;
    public GameObject Player;
    public Camera Camera;

    public GameObject Scene;
    public float sceneWidth = 7.03f;

    private List<GameObject> scenes;

    private readonly float spawnDistance = 2;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, 1.0f);
        scenes = new List<GameObject>
        {
            Instantiate(Scene, new Vector3(sceneWidth, 0, 0), new Quaternion(0, 0, 0, 0)),
            Instantiate(Scene, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)),
            Instantiate(Scene, new Vector3(-sceneWidth, 0, 0), new Quaternion(0, 0, 0, 0))
        };
    }

    private void Update()
    {
        Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.6f, -10);

        // Auto generate scenes, based on players position
        var sceneNumber = Mathf.Ceil(Player.transform.position.x / sceneWidth);
        sceneNumber -= Player.transform.forward.z < 0 ? 0 : 1;

        if (!scenes.Select(s => s.transform.position.x).Contains(sceneNumber * sceneWidth))
            scenes.Add(Instantiate(Scene, new Vector3(sceneNumber * sceneWidth, 0, 0), new Quaternion(0, 0, 0, 0)));

        var scenesToRemove = scenes.Where(s => Vector3.Distance(s.transform.position, Player.transform.position) > 10).ToList();
        scenesToRemove.ForEach(s =>
        {
            Destroy(s);
            scenes.Remove(s);
        });
    }

    private void SpawnEnemy()
    {
        if (FindObjectsOfType<Guard>().Length > 20)
            return;

        var spawnPosition = Player.transform.position + new Vector3(spawnDistance, 0f, 0f);
        Instantiate(Guard, spawnPosition, new Quaternion(0, 0, 0, 0));
    }
}
