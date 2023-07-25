using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public RifleMan rifleMan;
    public Statemachine stateMachine;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
