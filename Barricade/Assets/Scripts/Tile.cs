using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour, IInputHandler, IInputClickHandler, IFocusable{
    public bool isClicked;
    public bool hasEnclosedNeighbor;
    public GridTileManager myManager;

    public void Initialize(GridTileManager manager)
    {
        myManager = manager; 
    }

    public void OnFocusEnter()
    {
        throw new NotImplementedException();
    }

    public void OnFocusExit()
    {
        throw new NotImplementedException();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log(name+"Clicked");
        
        isClicked = !isClicked; 
        //throw new NotImplementedException();
        if (isClicked == true)
        {
            //myManager.SelectTile(name);
            myManager.SelectTile(gameObject.name, gameObject.transform.position);
        }
        else
        myManager.SelectTile(gameObject.name, gameObject.transform.position);
        {
            myManager.DeleteTile(name); 
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
