using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanMaker : MonoBehaviour {

    public GameObject thingToMake;
    public int amount;

	// Use this for initialization
	void Start () {
		
        for(int i = 0; i < amount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-30f, 30f), 1f, Random.Range(-30f, 30f));
            Instantiate(thingToMake, pos, Quaternion.identity);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
