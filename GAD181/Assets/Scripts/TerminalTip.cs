using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalTip : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
