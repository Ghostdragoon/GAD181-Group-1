using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RifleMan : MonoBehaviour
{
    private Statemachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    public UnityEngine.AI.NavMeshAgent Agent { get => agent;}
    [SerializeField]private string activeStateName;
    public Path path;
    private GameObject Player;
    public float sightDistance = 20f;
    public float FOV = 85f;
    public float eyehieght;

    void Start ()
    {
        stateMachine = GetComponent<Statemachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Initialise();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        CanSeePlayer();
        activeStateName = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    { 
        if (Player != null)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < sightDistance)
            {
                Vector3 targetDir = Player.transform.position - transform.position - (Vector3.up * eyehieght);
                float angleToPlayer = Vector3.Angle(targetDir, transform.forward);
                if (angleToPlayer >= -FOV && angleToPlayer <= FOV)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyehieght), targetDir);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.collider.gameObject.tag == "Player")
                        {
                            Debug.DrawRay(ray.origin, targetDir * sightDistance, Color.green);
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, targetDir * sightDistance, Color.red);
                }
            }
        }
        return false;
    }
}
