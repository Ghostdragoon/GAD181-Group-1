using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public Transform target;



    private float shootingDistance;

    private float pathUpdateDeadline;
    public NavMeshAgent navMeshagent;
    public Animator animator;


    private void Awake()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start ()
    {
        shootingDistance = navMeshagent.stoppingDistance;
    }

    void Update ()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }
    private void UpdatePath()
    {
           navMeshagent.SetDestination(target.position);
    }

}
