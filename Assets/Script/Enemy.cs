using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int health = 100;
	public TextMesh text_EnemyHP;

	// Use this for initialization
	void Start () {
		text_EnemyHP.text = "Hitpoints: " + GetComponent<Enemy> ().health;
	}
	
	// Update is called once per frame
	void Update () {		
		text_EnemyHP.text = "Hitpoints: " + GetComponent<Enemy>().health;
		if (health <= 0) {
			Destroy (gameObject);
			Debug.Log (GameObject.FindGameObjectsWithTag ("Enemy").Length);
		}
	}

}
