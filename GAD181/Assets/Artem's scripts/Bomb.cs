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

    private AudioSource audioSource;
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
        audioSource = GetComponent<AudioSource>();
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
                audioSource.loop = true;
                audioSource.clip = defusingProcessSound;
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }

        if (isDefusing)
        {
            currentDefuseTime += Time.deltaTime;
            if (currentDefuseTime >= defuseTime)
            {
                statusText.text = "Bomb status: Defused";
                IsDefused = true;
                audioSource.Stop();
                audioSource.PlayOneShot(defuseSound);

                float delayForDeactivation = defuseSound.length + 0.5f;
                Invoke("DeactivateBomb", delayForDeactivation);
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
            audioSource.Stop();
        }
    }

    private void Explode()
    {
        Debug.Log("Bomb exploded!");
        statusText.text = "Bomb status: Exploded";
        audioSource.PlayOneShot(explosionSound);

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

    private void DeactivateBomb()
    {
        gameObject.SetActive(false);
    }

    private void DisableExplosionEffect()
    {
        explosionEffect.SetActive(false);
    }
}













