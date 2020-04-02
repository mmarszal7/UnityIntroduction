using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPoint;
    public GameObject Bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(Bullet, BulletPoint.transform.position, transform.rotation);
    }
}
