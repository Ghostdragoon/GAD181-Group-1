using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f; // Time required to defuse the bomb
    public float explosionTime = 10f; // Time until the bomb explodes

    // Reference to the explosion effect object in the scene
    public GameObject explosionEffect;

    // Reference to the UI text element to display bomb status
    public Text statusText;

    // Static variable to keep track of the bomb status
    public static bool IsDefused = false;

    private Collider player = null;
    private float currentDefuseTime = 0f;
    private float currentExplosionTime = 0f;
    private bool isDefusing = false;
    private bool hasExploded = false;

    private void Start()
    {
        // Ensure explosion effect is initially disabled
        explosionEffect.SetActive(false);
        IsDefused = false; // Reset the status at the start of the scene
    }

    private void Update()
    {
        // Check if E key is pressed and player is near
        if (player != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            isDefusing = !isDefusing; // Toggle defusing status
        }

        if (isDefusing)
        {
            currentDefuseTime += Time.deltaTime;
            if (currentDefuseTime >= defuseTime)
            {
                // Defusing successful
                Debug.Log("Bomb defused!");
                statusText.text = "Bomb status: Defused";
                IsDefused = true;
                gameObject.SetActive(false);
            }
            else
            {
                statusText.text = "Bomb status: Defusing";
            }
        }
        else
        {
            currentExplosionTime += Time.deltaTime;
            if (currentExplosionTime >= explosionTime && !hasExploded)
            {
                // Bomb explodes
                Explode();
                explosionEffect.SetActive(true);
            }
            else
            {
                statusText.text = "Bomb status: Armed";
            }
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

        // Enable explosion effect
        explosionEffect.SetActive(true);

        // Unparent the explosion effect
        explosionEffect.transform.parent = null;

        // Schedule to disable explosion effect after 2 seconds
        Invoke("DisableExplosionEffect", 2f);

        Destroy(gameObject);
        hasExploded = true;
    }


    private void DisableExplosionEffect()
    {
        // Disable explosion effect
        explosionEffect.SetActive(false);
    }
}



