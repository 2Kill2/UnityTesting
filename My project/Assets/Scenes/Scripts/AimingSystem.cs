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
        [SerializeField] private float aimFOV = 30f;
        [SerializeField] private float normalFOV = 60f;
        [SerializeField] private float smoothSpeed = 10f;
        private void Update()
        {
            bool isAiming = Input.GetMouseButton(1);
            float targetFOV = isAiming ? aimFOV : normalFOV;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * smoothSpeed);
            //Debug.Log("Current FOV: " + cam.fieldOfView);

        }



    }

}
