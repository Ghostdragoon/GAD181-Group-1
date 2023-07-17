using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolArea : MonoBehaviour
{
    private PatrolPath[] PatrolPoints;

    private void Awake()
    {
        PatrolPath = GetComponentsInChildren<PatrolPoints>();
    }

    public PatrolPoints GetRandomCover(Vector3 agentLocation)
    {
        return PatrolPoints[Random.Range(0, covers.Length - 1)];
    }
}
