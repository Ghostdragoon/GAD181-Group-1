using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public int health = 100;
   public int damage;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
