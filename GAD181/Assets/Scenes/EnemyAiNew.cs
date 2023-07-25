using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyAiNew : MonoBehaviour
{
    private EnemyAiRef enemyReferences;
    private StateMachine stateMachine;
    
    public void Start()
    {
        enemyReferences = GetComponent<EnemyAiRef>();
        stateMachine = new StateMachine();


        CoverArea coverArea = FindObjectOfType<CoverArea>();

        var runToCover = new EnemyState_RunToCover(enemyReferences, coverArea);
        var delayAfterRun = new EnemyState_Delay(2f);
        var cover = new EnemyState_Cover(enemyReferences);
        

        At(runToCover, delayAfterRun, () => runToCover.HasArrivedAtCover());
        At(delayAfterRun, cover, () => delayAfterRun.IsDone());



        stateMachine.SetState(runToCover);

        void At(IState from, IState to, Func<bool> condition) => stateMachine.AddTransition(from,to, condition);
        void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    void Update()
    {
        stateMachine.Tick();
    }

    private void OnDrawGizmos()
    {
        if (stateMachine != null )
        {
            Gizmos.color = stateMachine.GetGizmoColor();
            Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.4f);
        }
    }
}
