using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AlexScripts
{
    public class AimingSystem : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        public PlayerInputScript Input;

        private void Update()
        {
            if (Input.OnAim())
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 30f, Time.deltaTime * 10f);
            }
            else
            {
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60f, Time.deltaTime * 10f);
            }
        }

      

    }

}
