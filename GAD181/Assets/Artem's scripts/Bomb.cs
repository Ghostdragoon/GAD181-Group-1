using UnityEngine;
using UnityEngine.InputSystem;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f; // Time required to defuse the bomb
    public float explosionTime = 10f; // Time until the bomb explodes
    public GameObject explosionEffect; // Explosion effect prefab

    private Collider player = null;
    private float currentDefuseTime = 0f;
    private float currentExplosionTime = 0f;
    private bool isDefusing = false;
    private bool hasExploded = false;

    private void Update()
    {
        if (isDefusing)
        {
            currentDefuseTime += Time.deltaTime;
            if (currentDefuseTime >= defuseTime)
            {
                // Defusing successful
                Debug.Log("Bomb defused!");
                Destroy(gameObject);
            }
        }
        else
        {
            currentExplosionTime += Time.deltaTime;
            if (currentExplosionTime >= explosionTime && !hasExploded)
            {
                // Bomb explodes
                Explode();
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

    public void Interact()
    {
        if (player != null && !hasExploded)
        {
            isDefusing = true;
        }
    }

    private void Explode()
    {
        Debug.Log("Bomb exploded!");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        hasExploded = true;
    }
}
