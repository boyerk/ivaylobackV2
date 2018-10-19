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
            occlusionPlane.transform.position = new Vector3(-0.03f, 0.074f, 0.198f);
        }
        
        
    }
	// Use this for initialization
	void Start () {
        myBehaviour = GetComponent<TrackableBehaviour>();
        if (myBehaviour)
        {
            myBehaviour.RegisterTrackableEventHandler(this);
           
        }
        occlusionPlane.transform.position = new Vector3(-0.03f, 0.074f, 0.198f);
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
        
        occlusionPlane.transform.position = new Vector3(-0.03f, -0.001f, 0.198f);
        btnEnabled = false;
        buttonWasClicked = true;
        btnGo.SetActive(btnEnabled);
    }
}
