using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<GameObject> spells = new List<GameObject>();

    public GameObject target;
    int strength, dexterity, intelligence;

    public void CastSpell(GameObject t, int s, int d, int i, string cs)
    {
        strength = s;
        dexterity = d;
        intelligence = i;
        target = t;

        Invoke(cs, 0f);
    }

    void Default()
    {
        Debug.Log("Default on: " + target);
        target.GetComponent<UnitObject>().ApplyDamage(strength);
    }
}