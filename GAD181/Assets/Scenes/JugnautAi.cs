using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugnautAi : MonoBehaviour
{
    private JugAiRef jugReferences;
    private StateMachine stateMachine;

    public void Start()
    {
        jugReferences = GetComponent<JugAiRef>();
        stateMachine = new StateMachine();


        JugCoverArea jugCoverArea = FindObjectOfType<JugCoverArea>();

        var runTojugCover = new JugState_RunToCover(jugReferences, jugCoverArea);
        var delayAfterRun = new JugState_Delay(2f);
        var cover = new JugState_Cover(jugReferences);


        At(runTojugCover, delayAfterRun, () => runTojugCover.HasArrivedAtCover());
        At(delayAfterRun, cover, () => delayAfterRun.IsDone());



        stateMachine.SetState(runTojugCover);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from, to, condition);
        
    }
    void Update()
    {
        stateMachine.Tick();
    }

    private void OnDrawGizmos()
    {
        if (stateMachine != null)
        {
            Gizmos.color = stateMachine.GetGizmoColor();
            Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.4f);
        }
    }
}
