using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollider : MonoBehaviour
{
  public float damageDelay = 2f;
  public float damageTimer;

  public void Update()
  {
    
    
      damageTimer += Time.deltaTime;
     
    
  }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (damageTimer >= damageDelay)
            {
                Debug.Log("Damage");
                other.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
                damageTimer = 0f;
            }
        }
    }
}
