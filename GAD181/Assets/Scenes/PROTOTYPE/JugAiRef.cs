using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JugAiRef : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public JugShooting jugShooter;

    public float pathUpdateDelay = 0.2f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        jugShooter = GetComponent<JugShooting>();

    }
}

