using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : ShootingScript
{
    [SerializeField] private float shootingInterval;
    private float shootingTimer;

    public GameObject inTowerSpawnPos;

    [SerializeField] private GameObject bulletPrefab;
    


    protected override void Start()
    {
        base.Start();

        spawnPos = inTowerSpawnPos;

        shootingTimer = shootingInterval;

        bullet = bulletPrefab;

    }

    
    private void OnTriggerStay(Collider other)
    {
        shootingTimer += Time.deltaTime;

        if (shootingTimer >= shootingInterval)
        {
            shootingTimer = 0f;
            Shoot();
        }
    }



}
