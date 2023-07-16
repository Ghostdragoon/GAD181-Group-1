using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class JugState_Shoot : IState
{
    private JugAiRef jugReferences;
    private Transform target;

    public JugState_Shoot(JugAiRef jugReferences)
    {
        this.jugReferences = jugReferences;
    }

    public void OnEnter()
    {
        Debug.Log("Engaging enemy");
        target = GameObject.FindWithTag("Target").transform;
    }
    public void OnExit()
    {
        Debug.Log("Target Neutralized");
        jugReferences.animator.SetBool("Shooting", false);
        target = null;
    }

    public void Tick()
    {
        Vector3 lookPos = target.position - jugReferences.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        jugReferences.transform.rotation = Quaternion.Slerp(jugReferences.transform.rotation, rotation, 0.2f);

        jugReferences.animator.SetBool("Shooting", true);
    }
    public Color GizmoColor()
    {
        return Color.red;
    }

}
