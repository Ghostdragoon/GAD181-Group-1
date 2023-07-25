using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Reload : IState
{
    private EnemyAiRef enemyReferences;
    public EnemyState_Reload (EnemyAiRef enemyReferences)
    {
        this.enemyReferences = enemyReferences;
    }
    public void OnEnter()
    {
        Debug.Log("Changing Mags");
        enemyReferences.animator.SetFloat("Cover",1);
        enemyReferences.animator.SetTrigger("Reload");
    }
    public void OnExit()
    {
        Debug.Log("Re-Engaging Hostiles");
        enemyReferences.animator.SetFloat("Cover",0);
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.yellow;
    }
}
