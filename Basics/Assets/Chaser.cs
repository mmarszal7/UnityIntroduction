using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 1f;

    private CharacterController CharacterController;


    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var displacementFromPlayer = playerTransform.position - transform.position;
        displacementFromPlayer.y = 0;

        if (displacementFromPlayer.magnitude > 1.5)
            CharacterController.Move(displacementFromPlayer * speed * Time.deltaTime);
    }
}
