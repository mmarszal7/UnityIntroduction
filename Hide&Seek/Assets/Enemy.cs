using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Vector3 velocity;
    private static float rayLength = 10;
    private float boardThreshold = (50 - rayLength) / 2;

    private void Update()
    {
        var direction = transform.forward.normalized;
        velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;

        CheckCollision();
    }

    private void CheckCollision()
    {
        RaycastHit hitInfo;
        var hit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, rayLength);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayLength, hit ? Color.red : Color.yellow);

        var tipPosition = transform.position + transform.TransformDirection(Vector3.forward) * rayLength;
        if (hit || Mathf.Abs(tipPosition.x) > boardThreshold || Mathf.Abs(tipPosition.z) > boardThreshold)
            StartCoroutine(RotateEnemy(Random.Range(-180.0f, 180.0f)));
    }

    private IEnumerator RotateEnemy(float targetAngle)
    {
        while (Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle) > 0.05f)
        {
            var angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, 90 * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }
}
