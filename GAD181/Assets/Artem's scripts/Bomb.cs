using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f;
    public float explosionTime = 10f;
    public GameObject explosionEffect;
    public TextMeshProUGUI statusText;
    public AudioClip explosionSound;
    public AudioClip defuseSound;
    public AudioClip defusingProcessSound;
    public Slider bombDefuseSlider;
    public TextMeshProUGUI timerText;
    public GameObject gameOverUI; // Reference to the GameOver UI canvas

    private AudioSource mainAudioSource;
    private AudioSource defuseAudioSource;
    public static bool IsDefused = false;
    private Collider player = null;
    private float currentDefuseTime = 0f;
    private float currentExplosionTime = 0f;
    private bool isDefusing = false;
    private bool hasExploded = false;

    private void Start()
    {
        explosionEffect.SetActive(false);
        IsDefused = false;
        mainAudioSource = GetComponent<AudioSource>();
        defuseAudioSource = gameObject.AddComponent<AudioSource>(); // Create a separate AudioSource for the defuse sound
        gameOverUI.SetActive(false); // Ensure game over UI is hidden at start

        bombDefuseSlider.maxValue = defuseTime;
        bombDefuseSlider.value = 0;
    }

    private void Update()
    {
        if (player != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            isDefusing = !isDefusing;
            if (isDefusing)
            {
                mainAudioSource.loop = true;
                mainAudioSource.clip = defusingProcessSound;
                mainAudioSource.Play();
            }
            else
            {
                mainAudioSource.Stop();
            }
        }

        if (isDefusing)
        {
            currentDefuseTime += Time.deltaTime;
            if (currentDefuseTime >= defuseTime)
            {
                statusText.text = "Bomb status: Defused";
                IsDefused = true;
                mainAudioSource.Stop();
                defuseAudioSource.PlayOneShot(defuseSound); // Play defuse sound on a separate AudioSource
            }
            else
            {
                statusText.text = "Bomb status: Defusing";
            }

            bombDefuseSlider.value = currentDefuseTime;
            timerText.text = (defuseTime - currentDefuseTime).ToString("0.0") + "s";
        }
        else
        {
            currentExplosionTime += Time.deltaTime;
            if (currentExplosionTime >= explosionTime && !hasExploded)
            {
                Explode();
            }
            else
            {
                statusText.text = "Bomb status: Armed";
            }

            timerText.text = (explosionTime - currentExplosionTime).ToString("0.0") + "s";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            isDefusing = false;
            mainAudioSource.Stop();
        }
    }

    private void Explode()
    {
        Debug.Log("Bomb exploded!");
        statusText.text = "Bomb status: Exploded";
        mainAudioSource.PlayOneShot(explosionSound);

        explosionEffect.SetActive(true);
        explosionEffect.transform.parent = null;

        Invoke("DisableExplosionEffect", 2f);
        hasExploded = true;

        // Stop the game and show the game over UI
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor for gameplay
        Cursor.visible = false; // Hide the cursor
    }

    private void DisableExplosionEffect()
    {
        explosionEffect.SetActive(false);
    }
}














