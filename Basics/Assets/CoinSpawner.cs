using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;

    void Start()
    {
        for (var i = 0; i < 5; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 90)));
        }
    }

    void OnTriggerEnter(Collider triggerEvent)
    {
        if (triggerEvent.gameObject.tag.Equals("Coin"))
            Destroy(triggerEvent.gameObject);

        Instantiate(coin, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 90)));
    }
}
