using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialenter : MonoBehaviour
{
    private void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }

    }
}