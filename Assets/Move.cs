using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Move : MonoBehaviour {
	public float horizontalInput;
	public bool facingRight = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
		
		if (horizontalInput > 0 && !facingRight)
			flip();
		else if (horizontalInput <0 && facingRight)
			flip();
	
		transform.Translate(horizontalInput*.1f,0,0);
	
	}
	private void flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
}
