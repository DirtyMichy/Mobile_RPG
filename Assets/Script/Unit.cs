using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int currenthealth = 100, maxhealth = 100, strength, dexterity, intelligence, attributePoints = 40;
    public GameObject targetedUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("xD");

        //targetedUnit.GetComponent<Player>().targetedUnit = transform.root.gameObject;
    }
}
