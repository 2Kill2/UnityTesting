using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;


    public class EnemyBulletManager : BaseBulletManager
    {
        [SerializeField] Transform bulletSpawnPoint;

        void Start()
        {
            
        }

        void Update()
        {
            //todo add a way to trigger the shooting, ONLY when it sees the player

        }

        private void Fire()
        {
            SpawnPhysicsBullet(bulletSpawnPoint);
        }



    }
