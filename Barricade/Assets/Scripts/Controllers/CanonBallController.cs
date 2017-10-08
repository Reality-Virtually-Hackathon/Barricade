using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallController : MonoBehaviour {

    private void Start()
    {
        
    }

    public void CollisionWithWall()
    {
        //Subtract wall hp

        //Trigger explosion

        Destroy(this.gameObject);
    }



    
}
