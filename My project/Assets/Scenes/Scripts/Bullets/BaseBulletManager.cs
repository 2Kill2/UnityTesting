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
    [SerializeField] protected ParticleSystem muzzleFlash;
    [Header("Enemy Bullet")]
    [SerializeField] protected enemyBullet enemyBullet;
    [Header("Sound effect")]
    [SerializeField] protected AudioSource ShootingSource;
    [SerializeField] protected AudioClip ShootingSound;


    protected void SpawnPhysicsBullet(Transform shootersTransform)
    {
        // does not call collision until physics system collides
        PhysicsBullet spawnedBullet = Instantiate(physicsBullet, shootersTransform.transform.position, shootersTransform.transform.rotation);
        spawnedBullet.Initialize(this);

        ShootingSource.PlayOneShot(ShootingSound);

        // Spawn muzzle flash effect
        //Instantiate(muzzleFlash, shootersTransform.position, shootersTransform.rotation);
        // adding this code makes player (ONLY PLAYER) shoot bullets with no cooldown, WTF.
    }


    protected void SpawnEnemyBullet(Transform shootersTransform)
    {
        // does not call collision until physics system collides
        enemyBullet spawnedBullet = Instantiate(enemyBullet, shootersTransform.transform.position, shootersTransform.transform.rotation);
        spawnedBullet.Initialize(this);

        ShootingSource.PlayOneShot(ShootingSound);
        // Add muzzleflash here
        Instantiate(muzzleFlash, ShootingSource.transform.position, ShootingSource.transform.rotation);
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
