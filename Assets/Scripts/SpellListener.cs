using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellListener : MonoBehaviour, SpellReceiver {

    private Adventure spellCaster;

    // Use this for initialization
    void Start() {
        spellCaster = GameObject.Find("InternetExplorer").GetComponent<Adventure>();
        spellCaster.SpellCast += SpellCastEventReceived;
    }

    // Update is called once per frame
    void Update() {

    }

    public void SpellCastEventReceived(object sender, SpellEventArgs e)
    {
        float distance = Vector3.Distance(transform.position, e.pos);
        if(distance <= e.spellRange)
        {
            
            Vector3 dir = transform.position - e.pos;
            dir.Normalize();

            gameObject.GetComponent<Rigidbody>().AddForce(dir * e.strength + Vector3.up * e.strength, ForceMode.Impulse);
            gameObject.GetComponent<Renderer>().material.color = Color.red;

        }
    }

    private void OnDestroy()
    {
        spellCaster.SpellCast -= SpellCastEventReceived;

    }
}
