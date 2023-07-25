using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameObject levelCompleteUI; // Assign the level complete UI in the Inspector

    private void Start()
    {
        // Hide the level complete UI at the start
        levelCompleteUI.SetActive(false);
    }

    // Assuming the player is tagged "Player" in the editor
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowLevelCompleteUI();
        }
    }

    private void ShowLevelCompleteUI()
    {
        // Show the level complete UI when the player reaches the marker point
        levelCompleteUI.SetActive(true);
    }
}
