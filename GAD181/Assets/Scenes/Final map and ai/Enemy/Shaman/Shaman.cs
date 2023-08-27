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
    public GameObject Flame;
    public GameObject Meteor;




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
            Vector3 lookPos = Player.transform.position - ShamanObj.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            ShamanObj.transform.rotation = Quaternion.Slerp(ShamanObj.transform.rotation, rotation, 0.2f);
            anim.SetBool("playerInRange", true);
            Flame.SetActive(true);
            if (castTimer >= castInterval )
            {
                castTimer = 0f;
                anim.SetTrigger("castSpell");
                Instantiate(Meteor, Player.transform.position, Quaternion.identity); 
               
            }
            else
            {
                Flame.SetActive(true);
                castTimer += Time.deltaTime;
                
            }
        }
        else
        {
            Flame.SetActive(false);
            anim.SetBool("playerInRange", false);
            
        }
    }

   
}
