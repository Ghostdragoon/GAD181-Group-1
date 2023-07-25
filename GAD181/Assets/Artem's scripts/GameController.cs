using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management

public class GameController : MonoBehaviour
{
    public Canvas uiCanvas; // Assign the UI Canvas in the inspector
    public string gameScene; // Assign this in the inspector to the name of your game scene
    public string settingsScene; // Assign this in the inspector to the name of your settings scene

    private void Start()
    {
        uiCanvas.enabled = false; // Hide the UI at start
    }

    public void ShowUI(Vector3 screenPos)
    {
        // Position the UI at the specified screen position
        uiCanvas.transform.position = screenPos;
        uiCanvas.enabled = true;
    }

    public void HideUI()
    {
        uiCanvas.enabled = false;
    }

    public bool IsUIActive()
    {
        return uiCanvas.enabled;
    }

    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameScene);
    }

    public void GoToSettings()
    {
        // Load the settings scene
        SceneManager.LoadScene(settingsScene);
    }

    public void GoBack()
    {
        // Return to the main menu (assuming this script is attached to a GameObject in your main menu scene)
        SceneManager.LoadScene("MainMenu");
    }
}

