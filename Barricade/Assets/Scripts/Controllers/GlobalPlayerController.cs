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


public class GlobalPlayerController : Singleton<GlobalPlayerController> , IInputHandler{

    [HideInInspector]
    public bool isActive;

    private GameObject currentBlock;
    public void Start()
    {
        isActive = false;
    }
    public void Activate()
    {
        isActive = true;
        InputManager.Instance.ClearFallbackInputStack();
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public void DeActivate()
    {
        isActive = false;
        InputManager.Instance.ClearFallbackInputStack();
    }

    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("user clicked");
        //Create random piece (or get it from game manager.
        currentBlock = Instantiate(GameManager.Instance.buildingBlockManager.testBuildingBlock, null);
        currentBlock.transform.parent = GameManager.Instance.gameStage.transform;

        currentBlock.transform.position = (Camera.main.transform.position + Camera.main.transform.forward * 1.5f);
        currentBlock.GetComponent<BlockDragger>().HostTransform = GameManager.Instance.gameStage.transform;
        currentBlock.GetComponent<BlockDragger>().OnInputDown(eventData);
        
    }

    public void OnInputUp(InputEventData eventData)
    {
        currentBlock = null;
    }
}
