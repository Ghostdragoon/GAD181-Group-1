using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene when the "Start Game" button is clicked
        SceneManager.LoadScene("Final map");
    }
}
