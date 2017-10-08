using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallController : MonoBehaviour {

    private void Start()
    {
        StartCoroutine (AutoDestroyCounter());
    }

     private IEnumerator AutoDestroyCounter()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
    
    public void CollisionWithWall()
    {
        //Subtract wall hp

        //Trigger explosion
        StopCoroutine("AutoDestroyCounter");
        Destroy(this.gameObject);
    }



    
}
