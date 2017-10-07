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
    const int QueryResultMaxCount = 512;
    private SpatialUnderstandingDllTopology.TopologyResult[] resultsTopology = new SpatialUnderstandingDllTopology.TopologyResult[QueryResultMaxCount];

    public List<SpatialLocation> spatialLocationList;

    public void ProcessScanToLocations()
    {
        spatialLocationList = new List<SpatialLocation>();
        StartCoroutine(GetSpawnLocations());
    }


    //Examples of ways to et locations and store them in location list. 
    IEnumerator GetSpawnLocations()
    {
        //Example Floor 1
        float minHeight = 0;
        float maxHeight = 0.125f;
        SpatialUnderstandingDllObjectPlacement.Solver_RemoveAllObjects();
        IntPtr resultsTopologyPtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsTopology);
        int locationCount = SpatialUnderstandingDllTopology.QueryTopology_FindPositionsOnFloor(
            minHeight, maxHeight,
            resultsTopology.Length, resultsTopologyPtr);

        SpatialLocation floor1 = new SpatialLocation();
        floor1.position = resultsTopology[0].position;
        floor1.normal = resultsTopology[0].normal;
        floor1.name = "floor1"; // this sould be a descriptive name of what positin is. 
        spatialLocationList.Add(floor1);


        //Example Wall Location
        resultsTopologyPtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsTopology);
        locationCount = SpatialUnderstandingDllTopology.QueryTopology_FindLargestWall(resultsTopologyPtr);

        SpatialLocation wall1 = new SpatialLocation();
        wall1.position = resultsTopology[0].position;
        wall1.normal = resultsTopology[0].normal;
        wall1.name = "wall1"; // this sould be a descriptive name of what positin is. 
        spatialLocationList.Add(wall1);

        Debug.Log("Number of locations stored is : " + spatialLocationList.Count);
        yield return null;
    }

    //returns a ranom ship spawn location
    public Vector3 GetRandomShipSpawnLocation()
    {
        Vector3 rndLocation = Vector3.zero;

        // search spatial location list 

        return rndLocation;
    }
}
