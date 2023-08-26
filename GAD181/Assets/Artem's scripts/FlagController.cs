using UnityEngine;
using TMPro; // TextMesh Pro namespace

public class FlagController : MonoBehaviour
{
    public TextMeshProUGUI flagStatusText;
    public GameObject sphereBeneathFlag; // Reference to the sphere
    public float captureTime = 5f;

    // Static variable to keep track of the flag status
    public static bool IsCaptured = false;

    private float currentCaptureTime = 0f;
    private bool isPlayerInside = false;
    private bool isEnemyInside = false;

    void Start()
    {
        IsCaptured = false; // Reset the status at the start of the scene
        SetSphereColor(Color.red); // Set the initial color to red
        flagStatusText.text = "Capture the Flag!";
    }

    void Update()
    {
        if (isPlayerInside && !isEnemyInside)
        {
            currentCaptureTime += Time.deltaTime;

            if (currentCaptureTime >= captureTime)
            {
                flagStatusText.text = "Flag Captured!";
                IsCaptured = true;

                // Change the color of the sphere beneath the flag to green
                SetSphereColor(Color.green);
            }
            else
            {
                flagStatusText.text = "Capturing Flag...";
                SetSphereColor(Color.green);
            }
        }
        else if (isEnemyInside)
        {
            flagStatusText.text = "Flag Contested!";
            SetSphereColor(Color.red);
        }
        else if (!IsCaptured)
        {
            currentCaptureTime = 0f;
            flagStatusText.text = "Capture the Flag!";
            SetSphereColor(Color.red);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            isEnemyInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (!IsCaptured)
            {
                SetSphereColor(Color.red); // Player steps out before capture is complete
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            isEnemyInside = false;
        }
    }

    // Helper method to change the sphere color
    void SetSphereColor(Color color)
    {
        Renderer rend = sphereBeneathFlag.GetComponent<Renderer>();
        if (rend)
        {
            rend.material.color = color;
        }
        else
        {
            Debug.LogError("No Renderer found on the sphere beneath the flag!");
        }
    }
}








