using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCapturePoint : MonoBehaviour
{
    public float captureTime = 5.0f;  // Time in seconds to capture the flag
    public bool isCaptured = false;   // Flag status
    public bool isContested = false;  // Contested status

    private float captureProgress = 0.0f;
    private bool isPlayerInZone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // Assuming the player object has the tag "Player"
        {
            isPlayerInZone = true;
            if (!isContested)
            {
                StartCoroutine(CaptureFlag());
            }
        }
        else if (other.gameObject.tag == "Enemy") // Assuming the enemy object has the tag "Enemy"
        {
            isContested = true;
            Debug.Log("Flag is being contested by enemy!"); // Debug message for flag contesting
            StopCoroutine(CaptureFlag());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInZone = false;
            if (!isContested)
            {
                StopCoroutine(CaptureFlag());
                captureProgress = 0.0f;
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            isContested = false;
            if (isPlayerInZone)
            {
                StartCoroutine(CaptureFlag());
            }
        }
    }

    IEnumerator CaptureFlag()
    {
        while (captureProgress < captureTime && !isContested)
        {
            captureProgress += Time.deltaTime;
            if (captureProgress >= captureTime)
            {
                isCaptured = true;
                Debug.Log("Flag Captured!");
            }
            yield return null;
        }
    }
}
