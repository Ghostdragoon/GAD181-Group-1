using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public GameObject cam;
    private float xRotation = 0f;

    public float xSens = 30f;
    public float ySens = 30f;

    // Flag to disable camera rotation
    public bool disableRotation = false;

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

