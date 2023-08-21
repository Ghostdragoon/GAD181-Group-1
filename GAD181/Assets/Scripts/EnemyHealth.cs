using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10f;
    public GameObject hitText;


    public void EnemyTakeDamage(float amount)
    {
        if (hitText)
        {
            ShowText();
        }

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ShowText()
    {
        Instantiate(hitText, transform.position, Quaternion.identity, transform);
    }
}
