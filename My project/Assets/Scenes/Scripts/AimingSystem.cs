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
        [SerializeField] private Animator animator; // Added Animator reference  

        private void Update()
        {
            bool isAiming = Input.GetMouseButton(1);
            CameraTarget.SetActive(isAiming);

            if (isAiming)
            {
                transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
                animator.SetBool("isAiming", true); // Updated to use Animator's SetBool method  
            }
            else
            {
                animator.SetBool("isAiming", false); // Ensure to reset the state when not aiming   
            }
        }
    }

}
