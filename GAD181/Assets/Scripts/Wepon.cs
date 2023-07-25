using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
   public float damage = 1f;

    public Camera playerCam;
    

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
            Debug.Log(hit.transform.name);
            EnemyVer1 target = hit.transform.GetComponent<EnemyVer1>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
