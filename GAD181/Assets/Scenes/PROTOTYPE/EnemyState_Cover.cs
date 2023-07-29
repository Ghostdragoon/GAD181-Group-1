using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Cover : IState
{
   private EnemyAiRef  enemyReferences;
    private StateMachine stateMachine;

    public EnemyState_Cover(EnemyAiRef enemyReferences)
    {
        this.enemyReferences = enemyReferences;

        stateMachine = new StateMachine();

        var enemyShoot = new EnemyState_Shoot(enemyReferences);
        var enemyDelay = new EnemyState_Delay(1f);
        var enemyReload = new EnemyState_Reload(enemyReferences);

        At(enemyShoot, enemyReload, () => enemyReferences.shooter.ShouldReload());
        At(enemyReload, enemyDelay, () => !enemyReferences.shooter.ShouldReload());
        At(enemyDelay, enemyShoot, () => enemyDelay.IsDone());

        stateMachine.SetState(enemyShoot);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        
    }
    
    

    public void OnEnter()
    {
        enemyReferences.animator.SetBool("Combat", true);
    }
    public void OnExit()
    {
        enemyReferences.animator.SetBool("Combat", false);
    }

    public void Tick()
    {
        stateMachine.Tick();
    }

    public Color GizmoColor()
    {
        return stateMachine.GetGizmoColor();
    }
}
