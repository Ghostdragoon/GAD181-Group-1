using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // Use TextMesh Pro namespace
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f;
    public float explosionTime = 10f;
    public GameObject explosionEffect;
    public TextMeshProUGUI statusText;
    public AudioClip explosionSound;
    public AudioClip defuseSound;
    public Slider bombDefuseSlider;
    public TextMeshProUGUI timerText;

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

        bombDefuseSlider.maxValue = defuseTime;
        bombDefuseSlider.value = 0;
    }

    private void Update()
    {
        if (player != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            isDefusing = !isDefusing;
        }

        if (isDefusing)
        {
            currentDefuseTime += Time.deltaTime;
            if (currentDefuseTime >= defuseTime)
            {
                statusText.text = "Bomb status: Defused";
                IsDefused = true;
                audioSource.PlayOneShot(defuseSound);

                float delayForDeactivation = defuseSound.length + 0.5f; // Extra half a second for safe measure
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
        Invoke("DestroyBomb", explosionSound.length + 0.5f);
        hasExploded = true;
    }

    private void DeactivateBomb()
    {
        gameObject.SetActive(false);
    }

    private void DisableExplosionEffect()
    {
        explosionEffect.SetActive(false);
    }

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
}










