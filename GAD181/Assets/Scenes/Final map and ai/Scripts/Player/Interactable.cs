using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promtMessage;

    protected virtual void Interact()
    {

    }

    public void BaseInteract()
    {
        Interact();
    }
}
