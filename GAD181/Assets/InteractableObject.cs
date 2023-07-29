using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Collider to detect the player
    public Collider playerDetectionCollider;

    // Reference to the PlayerLook script
    public PlayerLook playerLook;

    // This flag will tell if the player is near enough to interact
    private bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby)
        {
            // Interact code here, which should be called in MainController script
            // So, no need to add anything here for now

            // Disable camera rotation
            playerLook.disableRotation = true;

            // Show system cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Enable camera rotation
            playerLook.disableRotation = false;

            // Hide system cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // This function is called when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the player entered the trigger, set isPlayerNearby to true
        if (other == playerDetectionCollider)
        {
            isPlayerNearby = true;
        }
    }

    // This function is called when something leaves the trigger
    private void OnTriggerExit(Collider other)
    {
        // If the player left the trigger, set isPlayerNearby to false
        if (other == playerDetectionCollider)
        {
            isPlayerNearby = false;
        }
    }

    public bool GetIsPlayerNearby()
    {
        return isPlayerNearby;
    }
}

