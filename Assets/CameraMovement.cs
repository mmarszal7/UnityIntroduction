using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //playerPosition.rotation = Quaternion.AngleAxis(Input.mousePosition.x, Vector3.up);
    }
}
