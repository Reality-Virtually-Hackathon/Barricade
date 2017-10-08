using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {
    public FindNeighbors myNeighbors;
    public WallDetecter myWallDetect; 
    public GameObject tower; 
    //public Wall
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) { 
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //print(hit.transform.name);
                GameObject currSelected = GameObject.Find(hit.transform.name);
                currSelected.GetComponent<Tile>().isClicked = true; 
                //print(hit.transform.position); 
                Instantiate(tower, new Vector3((float)hit.transform.position.x,(float) hit.transform.position.y,(float) hit.transform.position.z), new Quaternion(0, 0, 0, 0)); 
                currSelected.GetComponent<Renderer>().material.color = Color.blue;
                myNeighbors.calculateNeighbors(hit.transform.name);
                //print (hit.transform.position.x + " a" +  hit.transform.position.y);
                //print(currSelected.transform.position + "yo"); 
                myWallDetect.FindSelected(currSelected.transform.localPosition.x, currSelected.transform.localPosition.y); 
                

            }
        }
    }

}
