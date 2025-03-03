using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingScript : TargetingScript
{
    //get the bullet prefab and raycast it/instantiate it to the enemy that Shoot picks

    public GameObject bullet;

    protected GameObject spawnPos;

   

    public virtual void Shoot()
    {   
            
        if (currentTarget != null && bullet != null)
        {

            GameObject projectile = Instantiate(bullet, spawnPos.transform.position, spawnPos.transform.rotation);

            projectile.GetComponent<BulletScript>().SetTarget(currentTarget);


        }

    }




}
