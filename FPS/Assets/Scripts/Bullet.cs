using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power = 100f;

    public GameObject effectOnDestroy;

    private int lifeTime = 3;

    void Start()
    {
        var Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.AddForce(transform.forward * power);

        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider triggerEvent)
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Instantiate(effectOnDestroy, transform.position, transform.rotation);
    }
}
