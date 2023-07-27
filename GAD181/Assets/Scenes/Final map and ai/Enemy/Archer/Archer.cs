using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject ArcherObj;
    public float distanceFromPlayer;
    public GameObject Player;
    public Animator anim;
    public float ShootInterval = 4f;
    public float ShootTimer;


    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceFromPlayer < 20)
        {
            Debug.Log("Player is in range");
            anim.SetBool("playerInRange", true);
            
            if (ShootTimer >= ShootInterval)
            {
                ShootTimer = 0f;
                anim.SetTrigger("Shoot");
                Debug.Log("Shooting");
            }
            else
            {
                ShootTimer += Time.deltaTime;
                Debug.Log("Waiting to shoot");
            }

        }
        else
        {
            anim.SetBool("playerInRange", false);
            Debug.Log("Searching for player");
        }
    }
}
