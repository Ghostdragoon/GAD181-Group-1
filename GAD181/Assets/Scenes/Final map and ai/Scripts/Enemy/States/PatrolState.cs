using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public override void Enter()
    {
        
    }
    public override void Perform()
    {
        Patrol();
        if (rifleMan.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
        
    }
    public void Patrol()
    {
        if(rifleMan.Agent.remainingDistance < 0.2f)
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
        }
    }
}
