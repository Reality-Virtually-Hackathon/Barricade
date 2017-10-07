using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager: MonoBehaviour {

    //Storing the ship prefab and other stuff later

    public GameObject shipPrefab;

    private List<GameObject> listOfSpawnedShips;

    private void Start()
    {
        listOfSpawnedShips = new List<GameObject>();
    }

    public void StartSpawningShips()
    {
        //For now we just continoussly spawn, later we check for the correct phase

        InvokeRepeating("SpawnShip", 0, 4);
    }

    //Gets a random floor location and spawns a ship on it. 
    public void SpawnShip()
    {
        Debug.Log("Called spawnship");
        Vector3 spawnLocation = SpatialLocationFinderManager.Instance.GetRandomShipSpawnLocation();
        GameObject curShip = Instantiate(shipPrefab, null);
        curShip.transform.SetParent(GameManager.Instance.gameStage.transform);
        curShip.transform.position = spawnLocation;
        listOfSpawnedShips.Add(curShip);

    }

    
}
