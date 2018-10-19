using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEventArgs : System.EventArgs
{
    public int strength;
    public float spellRange;
    public Vector3 pos;
}

public enum CharacterType
{
    Adventurer,
    Wizard,
    Mage,
    Rogue
}

public interface SpellReceiver
{
    void SpellCastEventReceived(object sender, SpellEventArgs e);
}