using System.Collections;
using System.Collections.Generic;
using AlexScripts;
using UnityEngine;

namespace AlexScripts
{

    public class BulletManager : MonoBehaviour
    {
        
        [SerializeField] private Camera Cam;

        [SerializeField] private PhysicsBullet PhysicsBullet;
        [SerializeField] private RaycastBullet BulletParticle;

        [SerializeField] private PlayerInputScript Inputs;
        [SerializeField] private LayerMask RaycastMask;

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
                    SpawnPhysicsBullet();
                    break;
                default:
                    Debug.LogError("Invalid shooting calculation type selected.");
                    break;
            }

        }
        
        private void SpawnPhysicsBullet()
        {
            // does not call collision until physics system collides
            PhysicsBullet spawnedBullet = Instantiate(PhysicsBullet, Cam.transform.position, Cam.transform.rotation);
            spawnedBullet.Initialize(this);
        }

        private void DoRaycast()
        {
            LayerMask layerMask = LayerMask.GetMask("Wall", "Player");

            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hit, Mathf.Infinity, RaycastMask))
            {

                Debug.Log("Hit: " + hit.collider.name);
                OnProjectileCollision(hit.point, hit.normal);
            }
        }

        public void OnProjectileCollision(Vector3 position, Vector3 rotation)
        {

            
            SpawnParticle(position, rotation);
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
}
