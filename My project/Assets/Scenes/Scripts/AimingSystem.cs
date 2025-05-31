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
        [SerializeField] private GameObject CameraTarget;
        private void Update()
        {
            bool isAiming = Input.GetMouseButton(1);
            CameraTarget.SetActive(isAiming);

            if (isAiming)
            {
                transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
                
            }
            
        }



    }

}
