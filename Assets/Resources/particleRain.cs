using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class particleRain : MonoBehaviour {
    public ParticleSystem particlerain;
    private TrackableBehaviour myBehaviour;
  
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onClick() {
        particlerain.Play();
    }
}
