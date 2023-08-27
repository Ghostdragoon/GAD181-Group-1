using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Added Debug Log to track button clicks
        Debug.Log("Start Game button was clicked!");

        // Load the game scene when the "Start Game" button is clicked
        SceneManager.LoadScene("Final map 1");
    }

    public void StartNewTutorial()
    {
        // Added Debug Log to track button clicks
        Debug.Log("New Tutorial button was clicked!");

        // Load the tutorial scene when the "New Tutorial" button is clicked
        SceneManager.LoadScene("Final Tutorial");
    }
}

