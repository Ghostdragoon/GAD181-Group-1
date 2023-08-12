using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Collider to detect the player
    public Collider playerDetectionCollider;

    // Reference to the PlayerLook script
    public PlayerLook playerLook;

    // Reference to the PauseMenu script to know if the game is paused
    public PauseMenu pauseMenu;

    // This flag will tell if the player is near enough to interact
    private bool isPlayerNearby = false;

    private void Update()
    {
        // Only change camera rotation if the game is not paused
        if (!pauseMenu.IsPaused())
        {
            if (isPlayerNearby)
            {
                // Disable camera rotation
                playerLook.disableRotation = true;
            }
            else
            {
                // Enable camera rotation
                playerLook.disableRotation = false;
            }
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



