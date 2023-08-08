using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
   public float damage = 5f;
   public GameObject playerCam;

   public Transform gunBarrell;
   public TrailRenderer bulletTrail;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
        {
            var bullet = Instantiate(bulletTrail, gunBarrell.position, Quaternion.identity);
            bullet.AddPosition(gunBarrell.position);
            {
                bullet.transform.position = transform.position + (playerCam.transform.forward * 200);
            }

            if (hit.collider.tag == "Enemy")
            {
                //Debug.Log(hit.transform.name);
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

                if (enemyHealth == true)
                {
                    enemyHealth.EnemyTakeDamage(damage);
                }
            }
        }
    }
}
