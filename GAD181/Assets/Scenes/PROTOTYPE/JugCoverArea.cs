using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugCoverArea : MonoBehaviour
{
    private JugCover[] JugCovers;

    private void Awake()
    {
        JugCovers = GetComponentsInChildren<JugCover>();
    }

    public JugCover GetRandomJugCover(Vector3 agentLocation)
    {
        return JugCovers[Random.Range(0, JugCovers.Length - 1)];
    }

}
