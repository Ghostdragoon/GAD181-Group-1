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

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceFromPlayer < 10)
        {
            Debug.Log("Player is in range");
            anim.SetBool("playerInRange", true);
            Chase();
            agent.SetDestination(Player.transform.position);
            
            if (distanceFromPlayer < 2)
            {
                Attack();
            }

        }
        else
        {
            anim.SetBool("playerInVision", false);
            Debug.Log("Searching for player");
            Patrol();
        } 
    }

    public void Attack()
    {
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            anim.SetTrigger("Attack");
            Debug.Log("Attacking");
        }
        else
        {
            attackTimer += Time.deltaTime;
            Debug.Log("Waiting to attack");
        }
    }

    public void Chase()
    {
       
    }

    public void Patrol()
    {
        anim.SetBool("isChasing", false);
    }
}


/*  if(rifleMan.Agent.remainingDistance < 0.2f)
        {
            if(waypointIndex < rifleMan.path.waypoints.Count - 1)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex = 0;
            }
            rifleMan.Agent.SetDestination(rifleMan.path.waypoints[waypointIndex].position);
        }*/
