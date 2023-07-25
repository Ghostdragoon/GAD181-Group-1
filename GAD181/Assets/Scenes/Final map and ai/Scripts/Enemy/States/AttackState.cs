using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;

    public override void Enter()
    {
        
    }
    public override void Exit()
    {
        
    }
    public override void Perform()
    {
        if (rifleMan.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 7))
            {
                rifleMan.Agent.SetDestination(rifleMan.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
    
            else
        {
        losePlayerTimer += Time.deltaTime;
                if (losePlayerTimer > 7)
                {
                    stateMachine.ChangeState(new PatrolState());
                }
        }
    }
}
