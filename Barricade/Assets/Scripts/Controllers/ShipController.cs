using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public int fireRate = 3;

    public GameObject canonTurret;
    public GameObject canonBall;
    public GameObject canonBallSpawnPoint;
    private void Start()
    {
        canonTurret.SetActive(false);
        canonBall = GameManager.Instance.shipManager.canonBallPrefab;
        InvokeRepeating("Fire", 1, fireRate);
    }

    private Vector3 GetRandomTarget()
    {
        Vector3 target= Vector3.zero; // get target later. 
        //returns a random wall transform to target
        return target;
    }

    private void Fire()
    {
        canonTurret.SetActive(true);
        GameObject cnnBall = Instantiate(canonBall);
        cnnBall.transform.SetParent(GameManager.Instance.gameStage.transform);
        //sets the cnnBall position to edge of turret
        cnnBall.transform.localPosition = canonBallSpawnPoint.transform.position;
        cnnBall.GetComponent<Rigidbody>().velocity = BallisticVel(GetRandomTarget(), 30);
        //Instantiate a canon ball at the edge of the turret
        //Add a force velocity to the canon ball. 
        canonTurret.SetActive(false);
    }

    Vector3 BallisticVel(Vector3 target, float angle)
    {
        Vector3 dir = target - transform.position; // get target direction 
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
}
