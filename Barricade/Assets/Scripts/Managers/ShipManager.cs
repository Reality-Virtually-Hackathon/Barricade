using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager: MonoBehaviour {

    //Storing the ship prefab and other stuff later

    public GameObject shipPrefab;

    public float shipMinHeight=0; // Dimension of a ship. used when finding spawnable locations. 
    public float shipMaxHeight=0.125f;

    public float shipSpawnnterval;

    private List<GameObject> listOfSpawnedShips;

    public bool spawnShipsChecker;
    private void Start()
    {
        spawnShipsChecker = false;
        listOfSpawnedShips = new List<GameObject>();
    }


    public void StartSpawningShips()
    {
        //For now we just continoussly spawn, later we check for the correct phase

        InvokeRepeating("SpawnShip", 0, shipSpawnnterval);
    }

    //Gets a random floor location and spawns a ship on it. 
    public void SpawnShip()
    {
        if (!spawnShipsChecker)
        {
            return; // do not spawn ships. 
        }
        Debug.Log("Called spawnship");
        Vector3 spawnLocation = SpatialLocationFinderManager.Instance.GetRandomShipSpawnLocation();
        GameObject curShip = Instantiate(shipPrefab, null);
        curShip.transform.SetParent(GameManager.Instance.gameStage.transform);
        curShip.transform.position = spawnLocation;
        listOfSpawnedShips.Add(curShip);

    }

    
}
