using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabler : MonoBehaviour
{

    public GameObject Canvas;
    private void Awake()
    {
        Canvas.SetActive(true);
    }
}
