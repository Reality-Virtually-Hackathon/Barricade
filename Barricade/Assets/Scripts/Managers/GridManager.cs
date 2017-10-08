using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public GameObject tile; 

    public int height;
    public int width;
    private Vector3 startPosition;
    public List<bool> allTiles;
    private const float z = (float)0.2;

    private GameObject gridParent;
    private GameObject gridSubParent; // so gird s centred. 
    public void CreateGrid()
    {
        //Create Empty Object called grid in the game Stage
         gridParent = new GameObject();
        gridParent.name = "Grid";
        gridParent.transform.SetParent(GameManager.Instance.gameStage.transform);

        gridSubParent = new GameObject();
        gridSubParent.name = "GridSubParent";
        gridSubParent.transform.SetParent(gridParent.transform);
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < width; z++)
            {
                GameObject currTile = Instantiate(tile);
                currTile.transform.position = CalculatePosition(x, z);
                currTile.gameObject.transform.SetParent(gridSubParent.transform, false); 
                currTile.gameObject.name = x.ToString() + " " + z.ToString();
                //Orienting the tile downwards.
                currTile.transform.localEulerAngles = new Vector3(-90, 0, 0);
             
            }
        }

        //Repositioning the grid to be on a table.
        gridSubParent.transform.localPosition = new Vector3(-4.5f, 0, -4.5f);

        gridParent.transform.position = SpatialLocationFinderManager.Instance.GetGridSpawnLocation();
        gridParent.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }
    Vector3 CalculatePosition(int x, int z)
    {
        float offset = (float)0.1; 
        float xPos = startPosition.x + x + offset;
        float zPos = startPosition.z + z; 

        return new Vector3(xPos, 0, zPos);
    }

}
