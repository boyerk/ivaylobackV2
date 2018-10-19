using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class MarkerDetected : MonoBehaviour, ITrackableEventHandler {
    
    bool btnEnabled = false;
    bool buttonWasClicked = false;
    public GameObject btnGo;
    public GameObject particlerainButton;
    public GameObject occlusionPlane;
    private TrackableBehaviour myBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            Debug.Log("Hey! I found:" + gameObject.name);
            ARmanager.Instance.SomeMarkerMessage(gameObject.name);
            btnEnabled = true;
            particlerainButton.SetActive(false);
            btnGo.SetActive(btnEnabled);
            if (buttonWasClicked == true)
            {
                particlerainButton.SetActive(true);

                buttonWasClicked = false;
            }
        }
        else
        {
            btnEnabled = false;
            btnGo.SetActive(btnEnabled);
            particlerainButton.SetActive(false);
            occlusionPlane.transform.localPosition = new Vector3(-0.03f, 0.481f, 0.198f);
        }
        
        
    }
	// Use this for initialization
	void Start () {
        myBehaviour = GetComponent<TrackableBehaviour>();
        if (myBehaviour)
        {
            myBehaviour.RegisterTrackableEventHandler(this);
           
        }
        occlusionPlane.transform.localPosition = new Vector3(-0.1959593f, 0.481f, 1.293332f);
        particlerainButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (buttonWasClicked == true)
        {
            particlerainButton.SetActive(true);

            buttonWasClicked = false;
        }
    }
    public void onButtonClick() {
        
        occlusionPlane.transform.localPosition = new Vector3(-0.1959593f, -0.017f, 1.293332f);
        btnEnabled = false;
        buttonWasClicked = true;
        btnGo.SetActive(btnEnabled);
    }
}
