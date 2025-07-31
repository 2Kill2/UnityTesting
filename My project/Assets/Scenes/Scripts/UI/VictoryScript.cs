using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;
using Unity.VisualScripting;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject victoryTrigger;
    [SerializeField] private Canvas victoryCanvas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryCanvas.enabled = true;
            if (victoryCanvas.enabled == true)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Debug.Log("VictoryScript has fucked up");
            }
        }

    }
}
