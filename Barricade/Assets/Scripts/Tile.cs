using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour, IInputHandler, IInputClickHandler, IFocusable{
    public bool isClicked;
    public bool hasEnclosedNeighbor;
    public GridTileManager myManager;
    [SerializeField]
    private GameObject towerPrefab;
    private GameObject myTower;

    public void Initialize(GridTileManager manager)
    {
        myManager = manager;
        myTower = Instantiate(towerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        myTower.transform.parent = this.transform;
        myTower.transform.localPosition = new Vector3(0, 0, 0);
        myTower.SetActive(false);
    }

    public void OnFocusEnter()
    {
       // throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
       // throw new NotImplementedException();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log(name+"Clicked");
        
        isClicked = !isClicked;
        myTower.SetActive(isClicked);
        //throw new NotImplementedException();
        if (isClicked == true)
        {
            myManager.SelectTile(gameObject.name, gameObject.transform.localPosition);
        }
        else
        myManager.SelectTile(gameObject.name, gameObject.transform.localPosition);
        {
            myManager.DeleteTile(name, gameObject.transform.localPosition); 
        }
    }

    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log(name);
        
        //throw new NotImplementedException();
        
    }

    public void OnInputUp(InputEventData eventData)
    {
        //myManager.DeleteTile(gameObject.name); 
        //throw new NotImplementedException();
    }
}
