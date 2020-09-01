using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour
{
    public GameObject menu;

    void Start()
    {
        menu = GameObject.Find("Canvas");
        //UI_BattleScript = menu.GetComponent<UI_Battle> ();

        Debug.Log("1");
    }

    void OnMouseDown()
    {
        Debug.Log("xD");

        //UI_Battle.enemy = GetComponent<Enemy> ();

        //UI_BattleScript.GetComponent <UI_Battle> ().SetEnemy(transform.root.gameObject);

        //rigidbody.AddForce(-transform.forward * 500f);
        //rigidbody.useGravity = true;
    }
}