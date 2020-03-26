using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Light Spotlight;
    public LayerMask viewMask;
    public Action SpottedPlayer;

    private bool isRotating = false;

    private void Update()
    {
        if (isRotating)
            return;

        var direction = transform.forward.normalized;
        var velocity = direction * Speed;
        transform.position += velocity * Time.deltaTime;

        CheckCollision();
        CheckIfSpottedPlayer();
    }

    private void CheckIfSpottedPlayer()
    {
        var player = FindObjectOfType<Player>().transform;

        if (Vector3.Distance(transform.position, player.position) < Spotlight.range / 2)
        {
            var dirToPlayer = (player.position - transform.position).normalized;
            var angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < Spotlight.spotAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    SpottedPlayer?.Invoke();
                }
            }
        }
    }

    private void CheckCollision()
    {
        var boardThreshold = (50 - Spotlight.range) / 2;

        RaycastHit hitInfo;
        var hit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, Spotlight.range);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Spotlight.range, hit ? Color.red : Color.yellow);

        var tipPosition = transform.position + transform.TransformDirection(Vector3.forward) * Spotlight.range;
        if (hit || Mathf.Abs(tipPosition.x) > boardThreshold || Mathf.Abs(tipPosition.z) > boardThreshold)
            StartCoroutine(RotateEnemy(Random.Range(-180.0f, 180.0f)));
    }

    private IEnumerator RotateEnemy(float targetAngle)
    {
        isRotating = true;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            var angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, 90 * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
        isRotating = false;
    }
}
