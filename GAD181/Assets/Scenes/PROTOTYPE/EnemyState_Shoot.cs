using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyState_Shoot : IState
{
    private EnemyAiRef enemyReferences;
    private Transform target;

    public EnemyState_Shoot(EnemyAiRef enemyReferences)
    {
        this.enemyReferences = enemyReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Engaging Enemy");
        target = GameObject.FindWithTag("Target").transform;
    }
    public void OnExit()
    {
        Debug.Log("Target Neutralized");
        enemyReferences.animator.SetBool("Shooting", false);
        target = null;
    }

    public void Tick ()
    {
        Vector3 lookPos = target.position - enemyReferences.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        enemyReferences.transform.rotation = Quaternion.Slerp(enemyReferences.transform.rotation, rotation, 0.2f);

        enemyReferences.animator.SetBool("Shooting", true);
    }
    public Color GizmoColor()
    {
        return Color.red;
    }

}
