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



public class SpatialLocationFinderManager : Singleton<SpatialLocationFinderManager>
{

    private SpatialUnderstandingDllTopology.TopologyResult[] resultsTopology = new SpatialUnderstandingDllTopology.TopologyResult[512];

    public List<SpatialLocation> spatialLocationList;

    public void ProcessScanToLocations()
    {
        spatialLocationList = new List<SpatialLocation>();
        StartCoroutine (GetSpawnLocations());
    }


    //Examples of ways to et locations and store them in location list. 
    private IEnumerator GetSpawnLocations()
    {

        yield return new WaitForSeconds(3);

        //IntPtr resultsTopologyPtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsTopology);
        //int locationCount = SpatialUnderstandingDllTopology.QueryTopology_FindLargestPositionsOnFloor(
        //    resultsTopology.Length, resultsTopologyPtr);

        //Debug.Log(locationCount);
        //Debug.Log(resultsTopology[0].position);
        //END OF TEST EXAMPLES.. FINDING LOCATIONS FOR THE FLOOR NOW. 
        SpatialUnderstandingDllObjectPlacement.Solver_RemoveAllObjects();
        SpaceVisualizer.Instance.ClearGeometry();

        IntPtr resultsTopologyPtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsTopology);
        int locationCount = SpatialUnderstandingDllTopology.QueryTopology_FindPositionsOnFloor(
            GameManager.Instance.shipManager.shipMaxHeight, GameManager.Instance.shipManager.shipMinHeight,
            resultsTopology.Length, resultsTopologyPtr);

        Debug.Log(locationCount);
        Debug.Log("First test position" + resultsTopology[0].position);



        foreach (SpatialUnderstandingDllTopology.TopologyResult potentialShipFloor in resultsTopology)
        {
            SpatialLocation shipFloor = new SpatialLocation();
            shipFloor.position = potentialShipFloor.position;
            shipFloor.normal = potentialShipFloor.normal;
            shipFloor.name = "shipFloor"; // this sould be a descriptive name of what positin is. 
            spatialLocationList.Add(shipFloor);
            Debug.Log(shipFloor.position);
        }
        Debug.Log(spatialLocationList.Count);

        yield return null;

    }
    private List<SpatialLocation> shipFloorLocationList;
    //returns a ranom ship spawn location
    public Vector3 GetRandomShipSpawnLocation()
    {
        shipFloorLocationList = new List<SpatialLocation>();

        foreach (SpatialLocation curLocation in spatialLocationList)
        {
            if (curLocation.name == "shipFloor")
            {
                shipFloorLocationList.Add(curLocation);
            }
        }

        //Getting a random Location
        System.Random r = new System.Random();
        SpatialLocation rndLocation = shipFloorLocationList[r.Next(shipFloorLocationList.Count)];

        Vector3 rndPositon = rndLocation.position;

        return rndPositon;
    }
}
