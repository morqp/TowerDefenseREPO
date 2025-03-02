using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetingScript : MonoBehaviour
{
    // when in range calculate the collision.other that is furthest on the track
    //but the agent.distance left is infinity a majority of the time so idk how that works
    //maybe as the entities enter the range they get queued
    //and when the current target dies || is out of range it gets the next one in queue
    //and checks the other one if its still in range
    //and that s the new target


    protected List<GameObject> enemiesInRange = new List<GameObject>();

    protected GameObject currentTarget;
    
    
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (currentTarget == null)
        {
            ChooseNextTarget();
        }

    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with smth");
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY IN RANGE");
            if (!enemiesInRange.Contains(other.gameObject))
            {
                enemiesInRange.Add(other.gameObject);
                Debug.Log("added to the list");
            }
            if (currentTarget == null)
            {
                currentTarget = other.gameObject;
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            if (currentTarget == other.gameObject)
            {
                Debug.Log("choosing target");
                ChooseNextTarget();
            }
        }
    }

    protected virtual void ChooseNextTarget()
    {
        if (enemiesInRange.Count > 0)
        {
            currentTarget = enemiesInRange[0];
            Debug.Log("choosing target");

        }
        else
        {
            currentTarget = null;


        }
    }

    /*
    protected virtual GameObject ChosenTarget()
    {

        return currentTarget;
    }
    */


}





