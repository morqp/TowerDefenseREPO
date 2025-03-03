using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : ShootingScript
{
    [SerializeField] private float shootingInterval;
    private float shootingTimer;

    [SerializeField] private GameObject inTowerSpawnPos;


    


    protected override void Start()
    {
        base.Start();

        spawnPos = inTowerSpawnPos;

        shootingTimer = shootingInterval;
    }

    protected override void Update()
    {
        base.Update();


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
