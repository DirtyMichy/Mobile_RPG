using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : Unit
{
	public TextMesh text_EnemyHP;
	public GameObject playerRef;

	// Use this for initialization
	void Awake () {
		playerRef = GameObject.Find("Canvas");
		text_EnemyHP.text = "Hitpoints: " + GetComponent<Enemy> ().currenthealth;
	}
	
	// Update is called once per frame
	void Update () {		
	//	text_EnemyHP.text = "Hitpoints: " + GetComponent<Enemy>().health;
		if (currenthealth <= 0) {
			Destroy (gameObject);
			Debug.Log (GameObject.FindGameObjectsWithTag ("Enemy").Length);
		}
	}

}
