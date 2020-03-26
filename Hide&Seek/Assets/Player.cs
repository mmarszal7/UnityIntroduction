using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action Won;

    private void OnTriggerEnter(Collider triggerEvent)
    {
        if (triggerEvent.gameObject.name.Equals("FinishPoint"))
            Won?.Invoke();
    }
}
