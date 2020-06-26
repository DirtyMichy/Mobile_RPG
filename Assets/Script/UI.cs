using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public GameObject town, forest; 
	public Text text_Strength,text_AttributePoints;
	public GameObject Player;
	public static int strength;
	public Button buttonStrength;

	// Update is called once per frame
	void Update () {
			//strength = player.GetComponent<Player> ().strength;
/*
		if (Player.attributePoints > 0){
			buttonStrength.interactable = true;
		}else{
			buttonStrength.interactable = false;
		}

		text_Strength.text = "Strength: " + Player.strength;
		text_AttributePoints.text = "Remaining AttributePoints: " + Player.attributePoints;

		if (Input.GetKey (KeyCode.Alpha0)) {
			Application.LoadLevel ("ebenen");
		}
		*/
	}

	public void EnterForest(){
		town.gameObject.SetActive(false);
		forest.gameObject.SetActive(true);
	}

	public void EnterTown(){
		town.gameObject.SetActive(true);
		forest.gameObject.SetActive(false);
	}

	public void EnterBattle(){
		Application.LoadLevel ("Battle");
	}
	/*
	public void AddStrength(){
		Player.strength++;
		Player.attributePoints--;
	}
	*/

}
