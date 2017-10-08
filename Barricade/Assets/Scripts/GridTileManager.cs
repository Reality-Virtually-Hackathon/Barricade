using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileManager : MonoBehaviour {

    public FindNeighbors myNeighbors;
    public WallDetecter myWallDetect;
    public GameObject tower;
    public List<Vector3> isClickedPositions;
    //public Wall
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            //SelectTile("");

        }
        else if (Input.GetMouseButtonDown(1))
        {

            //DeleteTile("");
        }
    }
    public void SelectTile(string name, Vector3 position)
    {
        print("hi");
        Instantiate(tower, position, new Quaternion(0, 0, 0, 0));
        /*
              //print(hit.transform.name);
              GameObject currSelected = GameObject.Find(hit.transform.name);
              currSelected.GetComponent<Tile>().isClicked = true;
              //print(hit.transform.position); 
              Instantiate(tower, new Vector3((float)hit.transform.position.x, (float)hit.transform.position.y, (float)hit.transform.position.z), new Quaternion(0, 0, 0, 0));
              currSelected.GetComponent<Renderer>().material.color = Color.blue;

              isClickedPositions.Add(new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z));
              myNeighbors.calculateNeighbors(hit.transform.name);
              //print (hit.transform.position.x + " a" +  hit.transform.position.y);
              //print(currSelected.transform.position + "yo"); 
              myWallDetect.FindSelected(currSelected.transform.localPosition.x, currSelected.transform.localPosition.y);
  */


    }

    public void DeleteTile(string name)
    {
            /*
            print("hello");
           // GameObject currSelected = hit.transform.gameObject;
            print(currSelected.name);

            //print(hit.transform.name);
            //GameObject currSelected = GameObject.Find(hit.transform.name);
            //print(hit.transform.name.ToString()); 
            currSelected.GetComponent<Tile>().isClicked = true;
            //print(hit.transform.position);
            
            if (hit.transform.gameObject.tag == "Piece")
            {
                GameObject.Destroy(currSelected);
            }
            
            //Instantiate(tower, new Vector3((float)hit.transform.position.x, (float)hit.transform.position.y, (float)hit.transform.position.z), new Quaternion(0, 0, 0, 0));
            currSelected.GetComponent<Renderer>().material.color = Color.blue;

            isClickedPositions.Add(new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z));
            myNeighbors.calculateNeighbors(hit.transform.name);
            //print (hit.transform.position.x + " a" +  hit.transform.position.y);
            //print(currSelected.transform.position + "yo"); 
            myWallDetect.FindSelected(currSelected.transform.localPosition.x, currSelected.transform.localPosition.y);
            */
        
        
        
    }



}
