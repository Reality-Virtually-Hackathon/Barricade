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

public class UIMenuManager : Singleton<UIMenuManager>
{

   // public GameObject menuButtonPrefab;
    public GameObject appControlMenuParentGameObject;


    public void ActivateAppControlMenu()
    {
        appControlMenuParentGameObject.SetActive(true);

    }

    public void DeactivateAppControlMenu()
    {
        appControlMenuParentGameObject.SetActive(false);

    }



    public void AppControlMenuButtonEventReceiver(string buttonName)
    {

        switch (buttonName)
        {

            case "Scan":
                ScanSelected();
                break;
            case "Connect":
                ConnectionSelected();
                break;
            case "Game":
                GameSelected();
                break;
            default:
                break;

        }

    }

    private void ScanSelected()
    {
        AppStateManager.Instance.Rescan();
        DeactivateAppControlMenu();
    }

    private void ConnectionSelected()
    {
        AppStateManager.Instance.Connection();

        DeactivateAppControlMenu();
    }
    private void GameSelected()
    {
        AppStateManager.Instance.StartGame();
        DeactivateAppControlMenu();
    }
}
