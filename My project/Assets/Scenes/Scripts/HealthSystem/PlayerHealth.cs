using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerHealth : HealthSystem
{
    protected override void Die()
    {
        ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(DieSound);
        //Destroy(gameObject);
       
        // lock the playe position
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        deathScreen.gameObject.SetActive(true);
        if (deathScreen.isActiveAndEnabled && Inputs.Fire)
            {
             //restart the game or load main menu
             UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
        if (deathScreen.isActiveAndEnabled && Inputs.Aim)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SimpleLevel");
        }
    }
}
