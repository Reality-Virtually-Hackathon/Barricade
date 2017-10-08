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
using System.Collections.ObjectModel;
using HoloToolkit.Examples.SpatialUnderstandingFeatureOverview;



public class SpatialLocationFinderManager : Singleton<SpatialLocationFinderManager>
{

    private SpatialUnderstandingDllTopology.TopologyResult[] resultsTopology = new SpatialUnderstandingDllTopology.TopologyResult[512];
    private SpatialUnderstandingDllShapes.ShapeResult[] resultsShape = new SpatialUnderstandingDllShapes.ShapeResult[512];
    public List<SpatialLocation> spatialLocationList;

    public void ProcessScanToLocations()
    {
        spatialLocationList = new List<SpatialLocation>();
        StartCoroutine(GetSpawnLocations());
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
        foreach (SpatialUnderstandingDllTopology.TopologyResult potentialShipFloor in resultsTopology)
        {
            SpatialLocation shipFloor = new SpatialLocation();
            shipFloor.position = potentialShipFloor.position;
            shipFloor.normal = potentialShipFloor.normal;
            shipFloor.name = "shipFloor"; // this sould be a descriptive name of what positin is. 
            spatialLocationList.Add(shipFloor);

        }

        // GETTING SPAWN LOCATION FOR GRID
        //    SpaceVisualizer.Instance.ClearGeometry();
        //    resultsTopologyPtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsTopology);
        //    locationCount = SpatialUnderstandingDllTopology.QueryTopology_FindLargestPositionsOnFloor(
        //resultsTopology.Length, resultsTopologyPtr);

        //    SpatialLocation gridSittingLoc = new SpatialLocation();
        //    gridSittingLoc.position = resultsTopology[0].position;
        //    gridSittingLoc.normal = resultsTopology[0].normal;
        //    gridSittingLoc.name = "gridSittingLoc"; // this sould be a descriptive name of what positin is. 
        //    spatialLocationList.Add(gridSittingLoc);


        //SpatialUnderstandingDllObjectPlacement.Solver_RemoveAllObjects();
        //SpaceVisualizer.Instance.ClearGeometry();
        //float sitMinHeight = 0f;
        //float sitMaxHeight = 1.2f;
        //float sitMinFacingClearance = 2f;
        //SpatialUnderstandingDllObjectPlacement.Solver_RemoveAllObjects();
        //resultsTopologyPtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsTopology);
        //int locationCount3 = SpatialUnderstandingDllTopology.QueryTopology_FindPositionsSittable(
        //    sitMinHeight, sitMaxHeight, sitMinFacingClearance,
        //    resultsTopology.Length, resultsTopologyPtr);
        //SpatialLocation gridSittingLoc = new SpatialLocation();
        //gridSittingLoc.position = resultsTopology[0].position;
        //gridSittingLoc.normal = resultsTopology[0].normal;
        //gridSittingLoc.name = "gridSittingLoc"; // this sould be a descriptive name of what positin is. 
        //spatialLocationList.Add(gridSittingLoc);



        SpatialUnderstandingDllObjectPlacement.Solver_RemoveAllObjects();
        SpaceVisualizer.Instance.ClearGeometry();
        IntPtr resultsShapePtr = SpatialUnderstanding.Instance.UnderstandingDLL.PinObject(resultsShape);
        int shapeCount = SpatialUnderstandingDllShapes.QueryShape_FindShapeHalfDims(
            "Grid",
            resultsShape.Length, resultsShapePtr);
        Debug.Log(resultsShape[0].position);
        Debug.Log(resultsShape[0].halfDims);
        SpatialLocation gridSittingLoc = new SpatialLocation();
        gridSittingLoc.position = resultsShape[0].position;
        gridSittingLoc.normal = resultsShape[0].halfDims;
        gridSittingLoc.name = "gridSittingLoc"; // this sould be a descriptive name of what positin is. 
        spatialLocationList.Add(gridSittingLoc);
        yield return null;

    }

    public Vector3 GetGridSpawnLocation()
    {
        Vector3 spwnLoc = Vector3.zero;
        if (spatialLocationList != null)
        {
            foreach (SpatialLocation curLocation in spatialLocationList)
            {
                if (curLocation.name == "gridSittingLoc") // unnecessary loopingl.. yesh cmon man. 
                {
                    spwnLoc = curLocation.position;

                    break;
                }
            }
        }
        Debug.Log(spwnLoc);
        return spwnLoc;
    }
    private List<SpatialLocation> shipFloorLocationList;
    //returns a ranom ship spawn location
    public Vector3 GetRandomShipSpawnLocation()
    {
        shipFloorLocationList = new List<SpatialLocation>();

        ////Added for quick testing
        //spatialLocationList = new List<SpatialLocation>();
        //if (spatialLocationList.Count ==0)
        //{
        //    return new Vector3(1,-1 ,1); // quick testing. 
        //}
        
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
