using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shaman : MonoBehaviour
{
    public GameObject ShamanObj;
    public float distanceFromPlayer;
    public GameObject Player;
    public Animator anim;
    public float castInterval = 4f;
    public float castTimer;


    
    // raycast to find game object tagged player 
    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceFromPlayer < 40)
        {
            Debug.Log("Player is in range");
            anim.SetBool("playerInRange", true);
            if (castTimer >= castInterval)
            {
                castTimer = 0f;
                anim.SetTrigger("castSpell");
                Debug.Log("Casting Spell");
                
            }
            else
            {
                castTimer += Time.deltaTime;
                Debug.Log("Waiting to cast spell");
            }
            
        }
        else
        {
            anim.SetBool("playerInRange", false);
            Debug.Log("Searching for player");
        }
    }
}
