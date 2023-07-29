using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_RunToCover : IState
{
    private EnemyAiRef enemyReferences;
    private CoverArea coverArea;


    public EnemyState_RunToCover(EnemyAiRef enemyReferences, CoverArea coverArea)
    {
        this.enemyReferences = enemyReferences;
        this.coverArea = coverArea;
    }
    public void OnEnter()
    {
        Cover nextCover = this.coverArea.GetRandomCover(enemyReferences.transform.position);
        enemyReferences.navMeshAgent.SetDestination(nextCover.transform.position);
    }
    public void OnExit()
    {
        enemyReferences.animator.SetFloat("Speed", 0f);
    }
    public void Tick()
    {
        enemyReferences.animator.SetFloat("Speed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
    }

    public Color GizmoColor()
    {
        return Color.blue;
    }

    public bool HasArrivedAtCover()
    {
        return enemyReferences.navMeshAgent.remainingDistance < 0.1f;
    }
}
