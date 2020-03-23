using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform playerTransform;

    public float speed = 7f;

    void Update()
    {
        var displacementFromPlayer = playerTransform.position - transform.position;
        var directionToPlayer = displacementFromPlayer.normalized;
        var valocity = directionToPlayer * speed;

        if (displacementFromPlayer.magnitude > 1.5)
            transform.Translate(valocity * Time.deltaTime);
    }
}
