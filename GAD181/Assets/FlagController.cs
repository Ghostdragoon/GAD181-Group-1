using UnityEngine;
using UnityEngine.UI;

public class FlagController : MonoBehaviour
{
    public Text flagStatusText;
    public float captureTime = 5f;

    private float currentCaptureTime = 0f;
    private bool isPlayerInside = false;
    private bool isEnemyInside = false;

    void Update()
    {
        if (isPlayerInside && !isEnemyInside)
        {
            currentCaptureTime += Time.deltaTime;
            if (currentCaptureTime >= captureTime)
            {
                flagStatusText.text = "Flag Captured!";
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

