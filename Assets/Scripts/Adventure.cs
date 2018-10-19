using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//public class SpellEventArgs : System.EventArgs
//{
//    public int strength;
//    public float spellRange;
//    public Vector3 pos;
//}


public class Adventure : MonoBehaviour
{

    public event EventHandler<SpellEventArgs> SpellCast;

    //public enum CharacterType
    //{
    //    Adventurer,
    //    Wizard,
    //    Mage,
    //    Rogue
    //}

    public CharacterType charType = CharacterType.Adventurer;

    private Rigidbody rb;
    private float moveSpeed = 1f;

    public float spellRange = 10f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        switch (charType)
        {
            case CharacterType.Adventurer:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case CharacterType.Mage:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case CharacterType.Rogue:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case CharacterType.Wizard:
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                break;
            default:
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward, ForceMode.Impulse);
        }
        else if (Input.GetKey("a"))
        {
            rb.AddForce(transform.right * -1, ForceMode.Impulse);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right, ForceMode.Impulse);
        }
        else if (Input.GetKey("s"))
        {
            rb.AddForce(transform.forward * -1, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("c"))
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        //GameObject[] beans = GameObject.FindGameObjectsWithTag("Bean");

        //for (int i = 0; i < beans.Length; i++)
        //{
        //    GameObject g = beans[i];
        //}
        //foreach (GameObject g in beans)
        //{
        //    float distance = Vector3.Distance(transform.position, g.transform.position);

        //    if(distance <= spellRange)
        //    {
        //        Vector3 dir = g.transform.position - transform.position;
        //        dir.Normalize();
        //        g.GetComponent<Rigidbody>().AddForce(dir * 3 + Vector3.up * 2, ForceMode.Impulse);
        //        g.GetComponent<Renderer>().material.color = Color.red;

        //    }
        //}

        SpellEventArgs spellInfo = new SpellEventArgs();
        if(charType == CharacterType.Adventurer)
        {
            spellInfo.strength = 4;
            spellInfo.spellRange = spellRange;
            spellInfo.pos = transform.position;
        }
        else if(charType == CharacterType.Mage)
        {

        }

        if (SpellCast != null)
        {
            SpellCast(this, spellInfo);
        }


    }

}
