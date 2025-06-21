using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlexScripts;

public class BaseBulletManager : MonoBehaviour
{
    [Header("Physics Bullet")]
    [SerializeField] private PhysicsBullet physicsBullet;
    [Header("Particle")]
    [SerializeField] protected RaycastBullet BulletParticle;
    [Header("Enemy Bullet")]
    [SerializeField] protected enemyBullet enemyBullet;

    protected void SpawnPhysicsBullet(Transform shootersTransform)
    {
        // does not call collision until physics system collides
        PhysicsBullet spawnedBullet = Instantiate(physicsBullet, shootersTransform.transform.position, shootersTransform.transform.rotation);
        spawnedBullet.Initialize(this);
    }


    protected void SpawnEnemyBullet(Transform shootersTransform)
    {
        // does not call collision until physics system collides
        enemyBullet spawnedBullet = Instantiate(enemyBullet, shootersTransform.transform.position, shootersTransform.transform.rotation);
        spawnedBullet.Initialize(this);
    }

    public void OnProjectileCollision(Vector3 position, Vector3 rotation)
    {


        SpawnParticle(position, rotation);
    }

    private void SpawnParticle(Vector3 position, Vector3 rotation)
    {
        Instantiate(BulletParticle, position, Quaternion.Euler(rotation));
    }


}
