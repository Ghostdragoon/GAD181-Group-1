using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public GameObject cam;
    private float xRotation = 0f;

    public float xSens = 30f;
    public float ySens = 30f;

    public bool disableRotation = false;

    private void Update()
    {
        HandleCursorLock();
    }

    private void HandleCursorLock()
    {
        if (disableRotation)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ProcessLook(Vector2 input)
    {
        if (disableRotation)
        {
            return;
        }

        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSens);
    }
}






