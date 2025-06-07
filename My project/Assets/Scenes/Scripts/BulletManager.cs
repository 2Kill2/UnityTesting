using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;



    public class BulletManager : BaseBulletManager
    {
        
        [SerializeField] private Camera Cam;

        [SerializeField] private PhysicsBullet PhysicsBullet;

        [SerializeField] private PlayerInputScript Inputs;
        [SerializeField] public LayerMask RaycastMask;

        [SerializeField] private ShootType ShootingCalculation;
        
        public enum ShootType
        {
            Raycast = 0, 
            Physics = 1
        }

        private void Update()
        {
            //change to new input system
            if (Inputs.Aim && Inputs.Fire)
            {
                OnFirePressed();
                //Debug.Log("Fire pressed: " + Inputs.Fire);
            }
            Inputs.Fire = false;

        }

        private void OnFirePressed()
        {

            switch (ShootingCalculation)
            {
                case ShootType.Raycast:
                    DoRaycast();
                    break;
                case ShootType.Physics:
                    SpawnPhysicsBullet(Cam.transform);
                    break;
                default:
                    Debug.LogError("Invalid shooting calculation type selected.");
                    break;
            }

        }
        


        private void DoRaycast()
        {
            
            LayerMask layerMask = LayerMask.GetMask("Wall", "Player", "Camera");

            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hit, Mathf.Infinity, RaycastMask))
            {
                RaycastBullet raycastBullet = Instantiate(BulletParticle, hit.point, Quaternion.LookRotation(hit.normal));
                raycastBullet.Initialize(this);
                Debug.Log("Hit: " + hit.collider.name);
                OnProjectileCollision(hit.point, hit.normal);
                raycastBullet.TargetObject(hit.transform.gameObject);
            }
        }

        

        private void SpawnParticle(Vector3 position, Vector3 rotation)
        {
            Instantiate(BulletParticle, position, Quaternion.Euler(rotation));
        }



        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(Cam.transform.position, Cam.transform.position + Cam.transform.forward * 100f);
        }
        private void CleanupParticle()
        {

        }

    }

