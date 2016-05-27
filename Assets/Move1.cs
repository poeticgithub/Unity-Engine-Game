using UnityEngine;
using System.Collections;

public class Move1 : MonoBehaviour {
    public float moveSpeed = 5f;
    public float padding = 1f;
    public GameObject shootingNeuron;
    public float neuronSpeed;
    public float repeatRate = 0.5f;
    public AudioClip Shoot;
    float xmin, xmax;
    
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
	}

    // Update is called once per frame
    void Update()
    
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.0001f, repeatRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire"); 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-moveSpeed*Time.deltaTime, 0,0);
        } else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.position += new Vector3(moveSpeed*Time.deltaTime, 0, 0);
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void Fire()
    {
        GameObject neuron = Instantiate(shootingNeuron, transform.position, Quaternion.identity) as GameObject;
        neuron.GetComponent<Rigidbody2D>().velocity = new Vector3(0, neuronSpeed);
        AudioSource.PlayClipAtPoint(Shoot, transform.position);

    }
}

