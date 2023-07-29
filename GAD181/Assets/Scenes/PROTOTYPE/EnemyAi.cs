using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    public Transform target;

    private EnemyAiRef enemyReferences;

    private float shootingDistance;

    private float pathUpdateDeadline;   

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyAiRef>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shootingDistance = enemyReferences.navMeshAgent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
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
            enemyReferences.animator.SetBool("Shooting", inRange);
        }
        enemyReferences.animator.SetFloat("Speed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
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
        if (Time.time >= pathUpdateDeadline)
        {
            Debug.Log("Updating Path ...");
            pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
            enemyReferences.navMeshAgent.SetDestination(target.position);
        }
    }
}
