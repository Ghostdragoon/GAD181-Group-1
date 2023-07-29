using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugState_RunToCover : IState
{
    private JugAiRef jugReferences;
    private JugCoverArea jugCoverArea;


    public JugState_RunToCover(JugAiRef jugReferences, JugCoverArea jugCoverArea)
    {
        this.jugReferences = jugReferences;
        this.jugCoverArea = jugCoverArea;
    }
    public void OnEnter()
    {
        JugCover nextjugCover = this.jugCoverArea.GetRandomJugCover(jugReferences.transform.position);
        jugReferences.navMeshAgent.SetDestination(nextjugCover.transform.position);
    }
    public void OnExit()
    {
        jugReferences.animator.SetFloat("Speed", 0f);
    }
    public void Tick()
    {
        jugReferences.animator.SetFloat("Speed", jugReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
    }

    public Color GizmoColor()
    {
        return Color.blue;
    }

    public bool HasArrivedAtCover()
    {
        return jugReferences.navMeshAgent.remainingDistance < 0.1f;
    }
}

