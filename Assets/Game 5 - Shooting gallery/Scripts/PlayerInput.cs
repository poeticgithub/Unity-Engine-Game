using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	public Rigidbody2D projectile, explosion;
	public Transform Spawnpoint;
	public AudioSource explosionSound, wrongAnswer;
	Rigidbody2D clone2;
	bool inc1 = false;
	bool inc2 = false;
    
        
	// Use this for initialization
	void Start () {

        GameManager.gm.displayShots();

	}

	// Update is called once per frame
	void Update ()
    {
        GameManager.gm.displayShots();


        if (Input.GetKeyDown (KeyCode.Space) && gameObject.name == "PlayerCharacter" && GameManager.gm.shots > 0)
        {
            GameManager.gm.shots--;

           	Rigidbody2D clone;
			clone = (Rigidbody2D)Instantiate (projectile, transform.position, Quaternion.identity);
            clone.tag = "neutron";
            clone.velocity = Spawnpoint.TransformDirection (Vector2.up * 10);
   		}
        
        if (gameObject.tag == "neutron" && gameObject.transform.position.y > 5 || gameObject.tag == "neutron" && gameObject.transform.position.y < -10 )
            Destroy(gameObject);
			
		if (Input.GetKey("escape"))
			Application.Quit();

	}

	void OnTriggerEnter2D (Collider2D col){
		//Debug.Log("collision name = " + col.gameObject.tag);

		if (col.gameObject.tag == "enemy" && gameObject.tag == "neutron")
        {
            GameManager.gm.shots++;

            col.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;

			Destroy (gameObject);
		
			clone2 = (Rigidbody2D)Instantiate(explosion, transform.position, Quaternion.identity);
			explosionSound.pitch = 1.5f;
			explosionSound.Play();
			clone2.tag = "explosion";

			GameManager.gm.score = GameManager.gm.score + 1;
			GameManager.gm.displayScore ();
        
			if (GameManager.gm.score > 5 && inc1 == false)
          {
			   inc1 = true;
			   Respawn3.resp3.setSpeed += -0.001f;
			}
			if ((GameManager.gm.score > 10) && inc2 == false)
          {
	         	inc2 = true;
			Respawn3.resp3.setSpeed += -0.001f;
			}
        }

		if (col.gameObject.tag == "wrong" && gameObject.tag == "neutron") {
			col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
			wrongAnswer.Play();
			Destroy (gameObject);

			GameManager.gm.score--;
            if (GameManager.gm.shots > 0)
            GameManager.gm.shots--;
			GameManager.gm.displayScore ();
		}


        if (col.gameObject.tag == "wrong" && gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            wrongAnswer.Play();

            GameManager.gm.score--;
            if (GameManager.gm.shots > 0)
                GameManager.gm.shots--;
            GameManager.gm.displayScore();
        }
    }

    //void incrementShot()
    //{
    //    shots = 1;
    //}

    //void decrementShot()
    //{
    //    shots--;
    //}

	void OnBecameInvisible ()
    {
		if (gameObject.tag == "neutron")
		    Destroy (gameObject);

		else if (gameObject.tag == "explosion")
			Destroy (gameObject);
	}		
}


