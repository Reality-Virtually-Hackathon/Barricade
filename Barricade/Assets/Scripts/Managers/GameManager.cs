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
    public GridManager gridManager;
    public ShipManager shipManager;
    public GameObject gameStage; // this will be the sharing stage that has world anchor on it. 
    int numOfPlayers;
    public List<Player> currentPlayers;
    public Player localPlayer;

    public int phaseDuration;
    public bool buildPhaseActive; // if false we are in attack phase. 

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
        gridManager.CreateGrid();
        shipManager.StartSpawningShips();
        StartCoroutine(PhaseCounter());

    }

    IEnumerator PhaseCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(phaseDuration);
            SwitchPhase();
        }
    }

    public void SwitchPhase()
    {
        Debug.Log("Called Switch Phase");
        if (buildPhaseActive)
        {
            StartAttackPhase();
            buildPhaseActive = false;
            return;
        }
        else
        {
            StartBuildPhase();
            buildPhaseActive = true;
            return;
        }
    }


   public void StartBuildPhase()
    {
        shipManager.spawnShipsChecker= false;
        shipManager.DestoryAllActiveShips();
    }

    public void StartAttackPhase()
    {
        shipManager.spawnShipsChecker = true;
    }

    //Wipes all game info and returns to menu. 
    public void ResetGame()
    {
        localPlayer = null;
        currentPlayers.Clear();
        GlobalPlayerController.Instance.DeActivate();
        StopCoroutine("PhaseCounter"); // Stop the phase counter.
        shipManager.spawnShipsChecker = false; // reset ship spawn checker for next game. 
    }
}
