using UnityEngine;

public class FallingObject : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
