using UnityEngine;

public class PauseMenuForPlayerLook : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public PlayerLook playerLook;  // Reference to the PlayerLook script

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Disable the camera's ability to look around
        playerLook.enabled = false;

        // Make the mouse cursor visible and unlock it
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Enable the camera's ability to look around
        playerLook.enabled = true;

        // Hide the cursor and lock it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
