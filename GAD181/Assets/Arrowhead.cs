using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowhead : MonoBehaviour
{
    public void OnColliderEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
