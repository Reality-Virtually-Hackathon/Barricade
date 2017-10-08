using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonController : MonoBehaviour
{
    private Rigidbody rb;

    Vector3 BallisticVel(Transform target, float angle)
    {
        Vector3 dir = target.position - transform.position; // get target direction 
        float h = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal direction 
        float dist = dir.magnitude; // get horizontal distance 
        float a = angle * Mathf.Deg2Rad; // convert angle to radians 
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle 
        dist += h / Mathf.Tan(a); // correct for small height differences 
                                  // calculate the velocity magnitude 
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }

   
    public Transform myTarget;
    public GameObject cannonball;  
    public float shootAngle = 30; // elevation angle

    void FixedUpdate()
    {
        if (Input.GetKeyDown("b"))
        {
            // press b to shoot 
            //gameobject
            GameObject ball = Instantiate(cannonball, transform.position, Quaternion.identity) as GameObject;
            rb = ball.GetComponent<Rigidbody>();
            rb.velocity = BallisticVel(myTarget, shootAngle);
            Destroy(ball, 5);

        }
    }
}