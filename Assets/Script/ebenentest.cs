using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ebenentest : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed = 10f;
	private int count;
	public Text text;
	public GameObject ebenen, ebene; 
	
	// Use this for initialization
	void Start () {
		count = 0;
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0f);
		rb2d.AddForce (movement*speed);

		if(Input.GetKeyUp(KeyCode.UpArrow) && count<3 && text.text != ""){
			count++;
			text.text = "Ebene: " + count;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow) && count > 1 && text.text != "") {
			count--;
			text.text = "Ebene: " + count;
		}

		if (Input.GetKey (KeyCode.Alpha1)) {
			ebenen.gameObject.SetActive (false);
			ebene.gameObject.SetActive (true);
			text.text = "";
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			text.text = "Ebene: " + count;
			ebenen.gameObject.SetActive (true);
			ebene.gameObject.SetActive (false);
		}
	}
}
