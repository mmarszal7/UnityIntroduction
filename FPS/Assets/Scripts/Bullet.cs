using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float power = 100f;

    private int lifeTime = 10;

    void Start()
    {
        var Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.AddForce(transform.forward * power);

        Invoke("DestroyBullet", lifeTime);
    }

    void DestroyBullet() => Destroy(gameObject);

    void OnTriggerEnter(Collider triggerEvent)
    {
        DestroyBullet();
    }
}
