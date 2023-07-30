using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Swordsman : MonoBehaviour
{
    public GameObject SwordsmanObj;
    public float distanceFromPlayer;
    public GameObject Player;
    public Animator anim;
    public float attackInterval = 2f;
    public float attackTimer;
    public NavMeshAgent agent;
    public GameObject slash;
    public Transform Slashspace;



    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        
        attackTimer += Time.deltaTime;

        distanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceFromPlayer < 10)
        {
            anim.SetBool("IsPatrolling", false);
            anim.SetBool("playerInVision", true);
            agent.SetDestination(Player.transform.position);

            if (distanceFromPlayer < 3 && attackTimer >= attackInterval)
                
            {
                anim.SetBool("PlayerInRange", true);
                attackTimer = 0f;
                anim.SetTrigger("SwordAttack");
                Player.GetComponent<PlayerStats>().TakeDamage(10);
                Instantiate(slash, Slashspace.transform.position, Quaternion.identity);
                
            }
            else
            {
            anim.SetBool("PlayerInRange", false);
            anim.SetBool("playerInVision", false);
            anim.SetBool("IsPatrolling", true);
            Debug.Log("Searching for player");
            }

        }
    }

}




