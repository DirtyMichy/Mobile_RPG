using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Battle : MonoBehaviour {

	public GameObject enemy;
	public Button buttonDMG, buttonRNGDMG;
	public Text text_PlayerHP;
	public GameObject[] enemies;
	/*
	// Use this for initialization
	void Start () {
		Player.currenthealth = Player.maxhealth;

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}

	// Update is called once per frame
	void Update () {
		buttonDMG.GetComponentInChildren<Text> ().text = Player.strength + 10 + " DMG";
		buttonRNGDMG.GetComponentInChildren<Text> ().text = Player.strength + 1 + "-" + (Player.strength+20) + " DMG";
		text_PlayerHP.text = "Hitpoints: " + Player.currenthealth + "/" + Player.maxhealth;

		if (Player.currenthealth <= 0) {
			Application.LoadLevel ("Town");
		}

		if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) {
			Application.LoadLevel ("Town");
		}
	}

	public void DMG(){
		if(enemy != null)
		enemy.GetComponent<Enemy>().health -= (10+Player.strength);

		EnemyTurn ();
	}

	public void RandomDMG(){
		int random = UnityEngine.Random.Range (1+Player.strength, 20+Player.strength);
		if(enemy != null)
		enemy.GetComponent<Enemy>().health -= random;

		EnemyTurn ();
	}

	void EnemyTurn(){
		for(int i = 0;i < enemies.Length;i++){
			if(enemies[i] != null)
			{
				//if(enemies[i].GetComponent<Enemy>().health > 0)
				//{
					Player.currenthealth-=10;
				//}
			}
		}
	}
	*/
	public void SetEnemy(GameObject chosen){
		enemy = chosen;
	}
}
