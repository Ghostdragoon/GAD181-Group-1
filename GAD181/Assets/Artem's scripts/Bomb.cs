using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f;
    public float explosionTime = 10f;
    public GameObject explosionEffect;
    public Text statusText;
    public AudioClip explosionSound;
    public AudioClip defuseSound;
    public Slider bombTimerSlider;
    public Text timerText;

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

        bombTimerSlider.maxValue = explosionTime;
        bombTimerSlider.value = explosionTime;
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
                gameObject.SetActive(false);
            }
            else
            {
                statusText.text = "Bomb status: Defusing";
            }

            bombTimerSlider.value = defuseTime - currentDefuseTime;
            timerText.text = (defuseTime - currentDefuseTime).ToString("0.0") + "s";
        }
        else
        {
            currentExplosionTime += Time.deltaTime;
            if (currentExplosionTime >= explosionTime && !hasExploded)
            {
                Explode();
                explosionEffect.SetActive(true);
            }
            else
            {
                statusText.text = "Bomb status: Armed";
            }

            bombTimerSlider.value = explosionTime - currentExplosionTime;
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
        Destroy(gameObject);
        hasExploded = true;
    }

    private void DisableExplosionEffect()
    {
        explosionEffect.SetActive(false);
    }
}





