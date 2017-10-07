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

public class GameManager : Singleton<GameManager>
{
    public BuildingBlocksManager buildingBlockManager;
    public ShipManager shipManager;
    public GameObject gameStage; // this will be the sharing stage that has world anchor on it. 
    int numOfPlayers;
    public List<Player> currentPlayers;
    public Player localPlayer;


    /// Launches the networked game with X players, if not connected, it is a bot game with X-1 AI.
    public void Launch(bool networked, int numofPlayers)
    {
        if (networked)
        {
            return; //later. 
        }
        else //Bot Game.
        {
            currentPlayers = new List<Player>();
            localPlayer = new Player();
            localPlayer.Initiliaze(false); // human player
            currentPlayers.Add(localPlayer);
 
            for(int i=0; i < numofPlayers-1; i++)
            {
                Player player = new Player();
                player.Initiliaze(true); // bot player. 
                currentPlayers.Add(player);
            }
        }

        
        GlobalPlayerController.Instance.Activate();
        //Start spawning ships
        shipManager.StartSpawningShips();
    }

    //Wipes all game info and returns to menu. 
    public void ClearGame()
    {
        localPlayer = null;
        currentPlayers.Clear();
        GlobalPlayerController.Instance.DeActivate();
    }
}
