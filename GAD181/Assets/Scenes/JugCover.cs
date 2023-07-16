using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugCover : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position, Vector3.one * 0.3f);
    }
}
