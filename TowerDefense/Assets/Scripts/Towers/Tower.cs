using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : ShootingScript
{
    [SerializeField] private float shootingInterval;
    private float shootingTimer = 0;




    protected override void Start()
    {
        base.Start();

        shootingInterval = 1f;
    }

    protected override void Update()
    {
        base.Update();

        shootingTimer += Time.deltaTime;

        if(shootingTimer >= shootingInterval)
        {
            Shoot();
            shootingTimer = 0f;
        }


    }



}
 