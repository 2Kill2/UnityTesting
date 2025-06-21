using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;
using Unity.VisualScripting;


public class EnemyBulletManager : BaseBulletManager
    {
        [SerializeField] Transform bulletSpawnPoint;

    [SerializeField] private ShootType ShootingCalculation;

    public enum ShootType
    {
        
        Physics = 0
    }
    public void Fire(Vector3 Target)
    {
        switch (ShootingCalculation)
        {
            
                
            case ShootType.Physics:
                SpawnEnemyBullet(bulletSpawnPoint);
                break;
            default:
                Debug.LogError("Invalid shooting calculation type selected.");
                break;
        }
    }

    
    

}
