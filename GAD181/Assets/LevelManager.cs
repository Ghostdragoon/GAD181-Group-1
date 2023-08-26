using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompleteUI; // UI that appears when the level is complete

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
    }
}








