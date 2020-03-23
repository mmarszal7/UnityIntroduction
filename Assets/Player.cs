using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        var input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        var direction = input.normalized;
        var velocity = direction * speed;
        transform.Translate(velocity * Time.deltaTime);
    }
}
