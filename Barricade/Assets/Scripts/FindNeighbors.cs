using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNeighbors : MonoBehaviour {

	public GameObject[] calculateNeighbors(string objectsName)
    {
        char[] nameChar = objectsName.ToCharArray(); 
        int x = int.Parse(nameChar[0].ToString());
        int y = int.Parse(nameChar[2].ToString());

        string northName = x + " " + (y + 1);
        string northEastName = (x - 1) + " " + (y + 1);
        string northWestName = (x + 1) + " " + (y + 1); 
        string southName = x + " " + (y - 1);
        string southEastName = (x - 1) + " " + (y - 1);
        string southWestName = (x + 1) + " " + (y - 1); 
        string eastName = (x + 1) + " " + y; 
        string westName = (x - 1) + " " + y;

        GameObject NorthEast = GameObject.Find(northEastName);
        GameObject NorthWest = GameObject.Find(northWestName);
        GameObject North = GameObject.Find(northName);
        GameObject South = GameObject.Find(southName);
        GameObject SouthEast = GameObject.Find(southEastName);
        GameObject SouthWest = GameObject.Find(southWestName);
        GameObject East = GameObject.Find(eastName);
        GameObject West = GameObject.Find(westName);

        GameObject[] allNeighbors = { NorthEast, NorthWest, North, South, SouthEast, SouthWest, East, West };
        return allNeighbors; 

   
        /*
        if (NorthEast != null)
        {
            NorthEast.GetComponent<Renderer>().material.color = Color.red;
        }
        if (NorthWest != null)
        {
            NorthWest.GetComponent<Renderer>().material.color = Color.red;
        }
        if (North != null)
        {
            North.GetComponent<Renderer>().material.color = Color.red;
        }
        if (South != null)
        {
            South.GetComponent<Renderer>().material.color = Color.red;
        }
        if (SouthEast != null)
        {
            SouthEast.GetComponent<Renderer>().material.color = Color.red;
        }
        if (SouthWest != null)
        {
            SouthWest.GetComponent<Renderer>().material.color = Color.red;
        }
        if (East != null)
        {
            East.GetComponent<Renderer>().material.color = Color.red;
        }
        if (West != null)
        {
            West.GetComponent<Renderer>().material.color = Color.red;
        } */

    }
}
