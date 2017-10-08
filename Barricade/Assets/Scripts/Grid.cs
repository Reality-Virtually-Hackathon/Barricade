using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public GameObject tile; 

    public int height;
    public int width;
    private Vector3 startPosition;
    public List<bool> allTiles;
    public GridTileManager myTileManager; 
    private const float z = (float)0.2; 
	// Use this for initialization
	void Start () {
        CreateGrid(); 
	}
    
    void CreateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                GameObject currTile = Instantiate(tile);
                currTile.GetComponent<Tile>().Initialize(myTileManager); 
                currTile.transform.localPosition = CalculatePosition(x, y);
                currTile.gameObject.transform.SetParent(this.gameObject.transform, false); 
                currTile.gameObject.name = x.ToString() + " " + y.ToString();
             
            }
        }
    }
    Vector3 CalculatePosition(int x, int y)
    {
        float offset = (float)0.1; 
        float xPos = startPosition.x + x + offset;
        float yPos = startPosition.y + y; 

        return new Vector3(xPos, 0, yPos);
    }

}
