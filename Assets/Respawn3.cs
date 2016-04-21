using UnityEngine;
using System.Collections;

public class Respawn3 : MonoBehaviour {
	public static Respawn3 resp3 = new Respawn3();

	public  float setSpeed;
	// Use this for initialization
	void Start () {
		
       resp3.setSpeed = -0.03f;   
	}

	// Update is called once per frame
	void Update () {
		
		transform.Translate (0, resp3.setSpeed, 0);

		setSpeed = resp3.setSpeed;

		if (gameObject.name == "ThoughtBubble1")
		    gameObject.tag = GameManager.gm.tags [0];
		if (gameObject.name == "ThoughtBubble2")
			gameObject.tag = GameManager.gm.tags [1];
		if (gameObject.name == "ThoughtBubble3")
			gameObject.tag = GameManager.gm.tags [2];
		if (gameObject.name == "ThoughtBubble4")
			gameObject.tag = GameManager.gm.tags [3];
		if (gameObject.name == "ThoughtBubble5")
			gameObject.tag = GameManager.gm.tags [4];
		if (gameObject.name == "ThoughtBubble6")
			gameObject.tag = GameManager.gm.tags [5];
		
	}

	void OnBecameInvisible () {

		GameManager.gm.generateAddition ();

		if (gameObject.name == "ThoughtBubble1") {
			GameObject current = GameManager.gm.thoughtbubbles [0];
			current.transform.position = GameManager.gm.positions [0];
			current.tag = GameManager.gm.tags [0];
			current.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if (gameObject.name == "ThoughtBubble2") {
			GameObject current = GameManager.gm.thoughtbubbles [1];
			current.transform.position = GameManager.gm.positions [1];
			current.tag = GameManager.gm.tags [1];
			current.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if (gameObject.name == "ThoughtBubble3") {
			GameObject current = GameManager.gm.thoughtbubbles [2];
			current.transform.position = GameManager.gm.positions [2];
			current.tag = GameManager.gm.tags [2];
			current.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if (gameObject.name == "ThoughtBubble4") {
			GameObject current = GameManager.gm.thoughtbubbles [3];
			current.transform.position = GameManager.gm.positions [3];
			current.tag = GameManager.gm.tags [3];
			current.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if (gameObject.name == "ThoughtBubble5") {
			GameObject current = GameManager.gm.thoughtbubbles [4];
			current.transform.position = GameManager.gm.positions [4];
			current.tag = GameManager.gm.tags [4];
			current.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if (gameObject.name == "ThoughtBubble6") {
			GameObject current = GameManager.gm.thoughtbubbles [5];
			current.transform.position = GameManager.gm.positions [5];
			current.tag = GameManager.gm.tags [5];
			current.GetComponent<SpriteRenderer> ().color = Color.white;
		}

	}

}
