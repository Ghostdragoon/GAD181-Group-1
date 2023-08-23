using UnityEngine;
using UnityEngine.UI;

public class FlagController : MonoBehaviour
{
    public Text flagStatusText;
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
                sphereBeneathFlag.GetComponent<Renderer>().material.color = Color.green;

                gameObject.SetActive(false);  // Deactivate the flag
            }
            else
            {
                flagStatusText.text = "Capturing Flag...";
            }
        }
        else if (isEnemyInside)
        {
            flagStatusText.text = "Flag Contested!";
        }
        else
        {
            currentCaptureTime = 0f;
            flagStatusText.text = "Capture the Flag!";
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
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            isEnemyInside = false;
        }
    }
}


