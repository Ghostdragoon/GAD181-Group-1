using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiRef : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public EnemyShooting shooter;

    public float pathUpdateDelay = 0.2f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        shooter = GetComponent<EnemyShooting>();
    }
}
