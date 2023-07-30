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
        if (!isLevelComplete && Bomb.IsDefused && FlagController.IsCaptured)
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        isLevelComplete = true;
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }
}




