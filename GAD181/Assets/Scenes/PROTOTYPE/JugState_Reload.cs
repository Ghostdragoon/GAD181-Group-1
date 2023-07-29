using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugState_Reload : IState
{
    private JugAiRef jugReferences;
    public JugState_Reload(JugAiRef jugReferences)
    {
        this.jugReferences = jugReferences;
    }
    public void OnEnter()
    {
        Debug.Log("Changing Jug Mags");
        jugReferences.animator.SetFloat("Cover", 1);
        jugReferences.animator.SetTrigger("Reload");
    }
    public void OnExit()
    {
        Debug.Log("Eliminating Hostiles");
        jugReferences.animator.SetFloat("Cover", 0);
    }

    public void Tick()
    {

    }

    public Color GizmoColor()
    {
        return Color.yellow;
    }
}
