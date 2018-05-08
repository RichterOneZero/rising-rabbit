using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		setCountText();
		winText.text = "";
	}

	void FixedUpdate () {	//This event triggers after everything else, including physics!
		float moveHorizonal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizonal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText();
		}
	}

	void setCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 6) {
			winText.text = "YOU WIN!!";
		}
	}

}