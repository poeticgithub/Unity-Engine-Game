using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public static Projectile projectile = new Projectile();
    public bool shot = false;
    public void Hit()
    {
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            projectile.shot = true;
        }
    }
}
