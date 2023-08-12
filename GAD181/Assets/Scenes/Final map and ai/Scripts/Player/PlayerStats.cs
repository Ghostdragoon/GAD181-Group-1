using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth = 30;
    public int damage;
    public GameObject gameOverUI;

    public HealthBar healthBar;
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    } 

    public void Start()
    {
        health = maxHealth;
        healthBar.MaxHealth(maxHealth);

        gameOverUI.SetActive(false);
    }

    public void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;

            // Lock the camera and make the mouse cursor visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Game Restarted");

        // Revert the camera and cursor settings
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        // Delay the scene loading for a short amount of time
        yield return new WaitForSecondsRealtime(0.1f);

        // Reset the time scale
        Time.timeScale = 1f;

        // Load the new scene
        SceneManager.LoadScene("Spawn room");
    }
}



