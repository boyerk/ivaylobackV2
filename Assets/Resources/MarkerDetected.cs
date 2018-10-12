using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MarkerDetected : MonoBehaviour, ITrackableEventHandler {


    private TrackableBehaviour myBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            Debug.Log("Hey! I found:" + gameObject.name);
            ARmanager.Instance.SomeMarkerMessage(gameObject.name);
        }
    }
	// Use this for initialization
	void Start () {
        myBehaviour = GetComponent<TrackableBehaviour>();
        if (myBehaviour)
        {
            myBehaviour.RegisterTrackableEventHandler(this);
           
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
