using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Persistence;
using HoloToolkit.Unity.SpatialMapping;



public class ButtonBehaviour : MonoBehaviour, IFocusable, IInputClickHandler, IInputHandler
{
    [Header("Materials")]
    public Material mat_enter;
    public Material mat_exit;

    [Header("Values")]
    public float focusScale = 1.06f;
    public float scaleSpeed = 3f;

    private string this_name;
    private Renderer rend;
    private bool isGazed;
    private Vector3 originalScale;
    private Camera mainCam;
    private void Start()
    {
        this_name = gameObject.name;
        mainCam = Camera.main;
        rend = transform.GetComponent<Renderer>();
        if (rend)
        {
            if (mat_exit != null) // Buttons may not have any materials other than original
                rend.material = mat_exit;
            originalScale = transform.localScale;
        }
    }

    private void Update() // Visual feedback
    {
        if (isGazed)
        {

            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * focusScale, scaleSpeed * Time.deltaTime);
 
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleSpeed * Time.deltaTime);

        }
    }

    public void OnFocusEnter()
    {
        if (mat_enter != null)
            rend.material = mat_enter;
        isGazed = true;
    }

    public void OnFocusExit()
    {
        if (mat_exit != null)
            rend.material = mat_exit;
        isGazed = false;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Game Object is a status button, so handle event from MenuManager
        if (gameObject.tag == "MenuButton")
        {
            UIMenuManager.Instance.AppControlMenuButtonEventReceiver(gameObject.name);
        }

    }

    public void OnInputDown(InputEventData eventData)
    {
       
    }

    public void OnInputUp(InputEventData eventData)
    {
    }

}