using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	public UI_Battle UI_BattleScript;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Canvas");
		//UI_BattleScript = menu.GetComponent<UI_Battle> ();

        Debug.Log ("1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnMouseDown ()
	{
		Debug.Log ("xD");

		//UI_Battle.enemy = GetComponent<Enemy> ();

		//UI_BattleScript.GetComponent <UI_Battle> ().SetEnemy(transform.root.gameObject);

		//rigidbody.AddForce(-transform.forward * 500f);
		//rigidbody.useGravity = true;
	}
}
