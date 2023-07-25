using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugState_Cover : IState
{
    private JugAiRef jugReferences;
    private StateMachine stateMachine;

    public JugState_Cover(JugAiRef jugReferences)
    {
        this.jugReferences = jugReferences;

        stateMachine = new StateMachine();

        var jugShoot = new JugState_Shoot(jugReferences);
        var jugDelay = new JugState_Delay(1f);
        var jugReload = new JugState_Reload(jugReferences);

        At(jugShoot, jugReload, () => jugReferences.jugShooter.ShouldReload());
        At(jugReload, jugDelay, () => !jugReferences.jugShooter.ShouldReload());
        At(jugDelay, jugShoot, () => jugDelay.IsDone());

        stateMachine.SetState(jugShoot);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        
    }



    public void OnEnter()
    {
        jugReferences.animator.SetBool("Combat", true);
    }
    public void OnExit()
    {
        jugReferences.animator.SetBool("Combat", false);
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

