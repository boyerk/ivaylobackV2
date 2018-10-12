using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARmanager : MonoBehaviour {



    public static ARmanager _instance = null;
    public static ARmanager Instance { get { return _instance;}}
    // Use this for initialization

    void Awake()
    {
       if(_instance == null)
        {
            _instance = this;
        } else if (_instance != this)
        {
            Destroy(this);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SomeMarkerMessage(string OBJECT)
    {
        Debug.Log(OBJECT);
    }
}
