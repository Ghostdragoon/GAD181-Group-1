using UnityEngine;
using UnityEngine.SceneManagement;  // Required for reloading the scene

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompleteUI; // UI that appears when the level is complete
    public NewPlayerLook playerLook;   // Reference to the NewPlayerLook script
    public Canvas canvas1;             // Reference to the first canvas
    public Canvas canvas2;             // Reference to the second canvas

    private bool isLevelComplete = false;

    void Start()
    {
        levelCompleteUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Debug logs to monitor the status of each objective
        Debug.Log("Bomb Status: " + Bomb.IsDefused + " | Flag Status: " + FlagController.IsCaptured);

        if (!isLevelComplete && Bomb.IsDefused && FlagController.IsCaptured)
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        Debug.Log("Level completed!"); // This will show up in the console once the level is complete

        isLevelComplete = true;
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;

        // Disable the player's ability to look around
        playerLook.enabled = false;

        // Disable both canvases
        if (canvas1 != null) canvas1.gameObject.SetActive(false);
        if (canvas2 != null) canvas2.gameObject.SetActive(false);

        // Unlock the cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // This method is to restart the scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}









