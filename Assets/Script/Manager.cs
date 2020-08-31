using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager current;
    public List<GameObject> combatUnits = new List<GameObject>();
    public GameObject currentObjectsTurn;
    public int turn = 0;

    void Start()
    {
        if (current == null)
            current = this;
        else
            Destroy(gameObject);

        InitCombat();
    }

    public void InitCombat()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("CombatUnit"))
        {
            combatUnits.Add(item);
        }

        combatUnits[turn % combatUnits.Count].GetComponent<UnitObject>().TakeTurn();
    }

    public void RemoveDeadUnit(GameObject d)
    {
        combatUnits.Remove(d);

        if (combatUnits.Count == 1)
            Debug.Log("Combat endet at turn: " + turn);
    }

    public void NextTurn()
    {
        if (combatUnits.Count > 1)
        {
            turn++;

            currentObjectsTurn = combatUnits[turn % combatUnits.Count];

            combatUnits[turn % combatUnits.Count].GetComponent<UnitObject>().TakeTurn();

            Debug.Log("Turn: " + turn + " Unit: " + combatUnits[turn % combatUnits.Count].name);
        }

        //StartCoroutine(TurnDelay());
    }

    IEnumerator TurnDelay()
    {
        yield return new WaitForSeconds(1f);


    }

    void Update()
    {

    }
}