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

        private void Update()
        {
            if (Inputs.OnAim() && Inputs.Fire)
            {
                OnFirePressed();
            }
            Inputs.Fire = false;
        }

        private void OnFirePressed()
        {
            Vector3 direction = Cam.transform.forward;

            Instantiate(bulletPrefab, Cam.transform.position, Cam.transform.rotation);
        }

    }
}
