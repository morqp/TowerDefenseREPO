using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;

    public float damage = 2f;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }


}
