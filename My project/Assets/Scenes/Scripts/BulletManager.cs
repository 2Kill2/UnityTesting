using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;

namespace AlexScripts
{

    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private Camera Cam;

        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] private PlayerInputScript Inputs;

        [SerializeField] private float FireRate = 0.2f;

        private void Update()
        {
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                OnFirePressed();
                Debug.Log("Fire pressed: " + Inputs.Fire);
            }
            Inputs.Fire = false;

        }

        private void OnFirePressed()
        {
            Vector3 direction = Cam.transform.forward;
            FireWait();
            Instantiate(bulletPrefab, Cam.transform.position, Cam.transform.rotation);
        }

        private void FireWait()
        {
            // Implement fire rate logic here if needed
            // For example, you can use a coroutine to manage the firing rate
            // or simply use a timer to prevent firing too frequently.
            WaitForSeconds wait = new WaitForSeconds(FireRate);
        }

    }
}
