using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections.ObjectModel;
using UnityEngine.VR.WSA;
using System;
using HoloToolkit.Examples.SpatialUnderstandingFeatureOverview;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;

public class ShipManager: MonoBehaviour {

    //Storing the ship prefab and other stuff later

    public GameObject shipPrefab;
    public GameObject canonBallPrefab;

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
        //Local ship.
        Debug.Log("Called spawnship");
        Vector3 spawnLocation = SpatialLocationFinderManager.Instance.GetRandomShipSpawnLocation();
        //SINGLE PLAYER SPAWNINING. 
        //GameObject curShip = Instantiate(shipPrefab, null);
        //curShip.transform.SetParent(GameManager.Instance.gameStage.transform);
        //curShip.transform.position = spawnLocation;

        //listOfSpawnedShips.Add(curShip);


        //Netwoked Spawn

        AppStateManager.Instance.spawnManager.Spawn(
  new SyncShip(),
  spawnLocation,
  Quaternion.identity,
  GameManager.Instance.gameStage,
  "My Obj",
  false);


    }

    public void DestoryAllActiveShips()
    {

        foreach(GameObject shipToDestroy in listOfSpawnedShips)
        {
            Destroy(shipToDestroy);
        }
        listOfSpawnedShips.Clear();
    }

    
}
