using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    public float interactionRange = 3f; // Player needs to be within 3 units
    public Canvas uiCanvas; // Assign the UI Canvas in the inspector

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; // Assuming the player has a tag of "Player"
        uiCanvas.enabled = false; // Hide the UI at start
    }

    private void Update()
    {
        // Check distance to player every frame
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < interactionRange)
        {
            // Player is close enough to interact
            if (Input.GetKeyDown(KeyCode.E))
            {
                // E has been pressed
                // Toggle UI visibility
                uiCanvas.enabled = !uiCanvas.enabled;
            }
        }
        else if (uiCanvas.enabled)
        {
            // Player is not in range, but UI is still active
            // Hide UI
            uiCanvas.enabled = false;
        }
    }
}
