using UnityEngine;

public class Guard : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        InvokeRepeating("Damaged", 0, 2);
    }

    private void Damaged() => animator.SetTrigger("damaged");
}
