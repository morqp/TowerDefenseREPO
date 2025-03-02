using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Transform target;

    void Start()
    {
        //
    }

    void Update()
    {
        if(target != null)
        {
            MoveTowards(target);
        }
    }

    private void MoveTowards( Transform pTarget)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pTarget.position, step);
    }

    public void SetTarget( GameObject pTarget)
    {

        target= pTarget.transform;

    }


}
