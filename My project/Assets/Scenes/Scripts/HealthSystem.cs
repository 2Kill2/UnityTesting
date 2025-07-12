using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace AlexScripts
{

    [SerializeField]
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;
        [SerializeField] private Color defaultcolor;
        [SerializeField] private AudioClip hitSound;
        [SerializeField] private ParticleSystem deathEffect;
        [SerializeField] private AudioClip DieSound;
        [SerializeField] private Canvas deathScreen;
        [SerializeField] private PlayerInputScript Inputs;
        private void Start()
        {
            currentHealth = maxHealth;
            defaultcolor = gameObject.GetComponent<Renderer>().material.color;
        }

        private void Update()
        {
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            hitflash();
            //activate hit marker & sound
            //AudioSource.PlayOneShot(hitSound);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void hitflash() 
        {
            //make flash red
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            //wait 0.1 seconds
            StartCoroutine(ResetColor());
        }

        private IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Renderer>().material.color = defaultcolor;
        }

        [SerializeField] protected AudioSource audioSource;

        private void Die()
        {

            //AudioSource.PlayOneShot(DieSound);
            ParticleSystem effect = Instantiate(deathEffect, transform.position, Quaternion.identity);

            GetComponent<Rigidbody>().isKinematic = true; //stop player from moving
            GetComponent<MeshRenderer>().enabled = false; //hide player mesh, this does not work because the script is attached to the player object, not the mesh renderer
            
            deathScreen.gameObject.SetActive(true);

            audioSource.PlayOneShot(DieSound);

            if (deathScreen.isActiveAndEnabled && Inputs.Fire)
            {
                //restart the game or load main menu
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            }
            if (deathScreen.isActiveAndEnabled && Inputs.Aim)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("SimpleLevel");
            }
            //stop time
            //Time.timeScale = 0f; //pause the game
        }
        public float GetCurrentHealth()
        {
            return currentHealth;
        }
        public float GetMaxHealth()
        {
            return maxHealth;
        }
    }
}
