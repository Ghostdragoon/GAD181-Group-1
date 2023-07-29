using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Camera mainCharacterCamera;
    public CinemachineVirtualCamera[] vCams;
    public float transitionTime = 3.0f;  // Transition time in seconds

    private KeyCode[] cameraSwitchKeys;
    private CinemachineVirtualCamera currentVCam;

    void Start()
    {
        // Assuming that we have up to 9 cameras including the main character camera
        cameraSwitchKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        currentVCam = vCams[0];  // We assume that the first camera is the initial active one
    }

    void Update()
    {
        // Switch to main character camera
        if (Input.GetKeyDown(cameraSwitchKeys[0]))
        {
            SwitchToMainCamera();
        }

        for (int i = 0; i < vCams.Length; i++)
        {
            if (Input.GetKeyDown(cameraSwitchKeys[i + 1])) // Each camera corresponds to a number key
            {
                SwitchCamera(vCams[i]);
            }
        }
    }

    private void SwitchCamera(CinemachineVirtualCamera newVCam)
    {
        if (currentVCam != newVCam)
        {
            // Lower the priority of all the virtual cameras
            ResetPriorities();

            // Set the standard camera depth to a low value
            mainCharacterCamera.depth = -1;

            // Start the transition to the new camera
            StartCoroutine(IncreasePriorityOverTime(newVCam, transitionTime));
            currentVCam = newVCam;
        }
    }

    private void SwitchToMainCamera()
    {
        // Lower the priority of all the virtual cameras
        ResetPriorities();

        // Set the standard camera depth to a high value
        mainCharacterCamera.depth = 1;
    }

    private IEnumerator IncreasePriorityOverTime(CinemachineVirtualCamera vCam, float time)
    {
        float elapsedTime = 0f;
        while (elapsedTime < time)
        {
            vCam.Priority = (int)Mathf.Lerp(0, 11, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        vCam.Priority = 11;  // Make sure the target priority is reached at the end
    }

    private void ResetPriorities()
    {
        foreach (var vCam in vCams)
        {
            vCam.Priority = 0;
        }
    }
}




