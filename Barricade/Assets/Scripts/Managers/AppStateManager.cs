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

public class AppStateManager : Singleton<AppStateManager>
{

    //Manages the entire stete of the application
    //General Flow - Connect - > Scan - > Start Game

    public TextToSpeech textToSpeechManager;
    //public GameObject manualIPEnter;
    public PrefabSpawnManager spawnManager;

    private void Start()
    {
        ScanManager.Instance.DeactivateText();
       // manualIPEnter.SetActive(false);
    }
    private void Update()
    {

    }

    /// <summary>
    /// Connect launches a window to connect to server after inputting server ip port and address. 
    /// </summary>
    public void Connection()
    {
        UIMenuManager.Instance.DeactivateAppControlMenu();
        //manualIPEnter.SetActive(true);
        Debug.Log("ConnectionCalled");
    }

    /// <summary>
    /// Rescan  wipes previous mesh and retriggers the spatialUnderstanding scanning.
    /// </summary>
    public void Rescan()
    {
        Debug.Log("Rescan called");
        CompVoiceSpeak("Please scan your playspace");
        SpatialUnderstanding.Instance.scanState = SpatialUnderstanding.ScanStates.None;
        SpatialUnderstanding.Instance.RequestBeginScanning();
        ScanManager.Instance.ActivateText();

    }
    /// <summary>
    /// Called when user has finished scanning the play space. 
    /// </summary>
    public void ScanningDone()
    {
        CompVoiceSpeak("Scanning Done");
        ScanManager.Instance.DeactivateText();
        SpatialLocationFinderManager.Instance.ProcessScanToLocations();
        UIMenuManager.Instance.ActivateAppControlMenu();
    }

    /// <summary>
    /// Starts a fresh instance of the game. 
    /// </summary>
    public void StartGame()
    {
        Debug.Log("StartedGame");
        CompVoiceSpeak("Starting the game.");
        //later feed in 2 variables (bool connected and int for num of players)
        GameManager.Instance.Launch(false, 3);

    }

    /// <summary>
    /// Starts a fresh instance of the game. 
    /// </summary>
    public void TextureRoom()
    {
        Debug.Log("Texturing Room");

       CompVoiceSpeak("Texturing the room.");
        //later feed in 2 variables (bool connected and int for num of players)
        //GameManager.Instance.Launch(false, 3);
        SpatialLocationFinderManager.Instance.TextureRoom();

    }

    /// <summary>
    /// Reads audio in comp voice with source on camera. 
    /// </summary>
    /// <param name="text"></param>
    public void CompVoiceSpeak(string text)
    {
        textToSpeechManager.StartSpeaking(text);
    }
}


