using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gm = null;
	public int score;
	public Text gameScore;
	public Text question;


	public GameObject[] thoughtbubbles = new GameObject[6];
	public Vector3[] positions = new Vector3[6];
	public int[] results = new int[6];
	public string[] tags = new string[6];
	public TextMesh[] answers = new TextMesh[6];


	void Awake (){
		if (gm == null) {
			//if not, set instance to this
			gm = this;
			score = 0;
		}
		//do not destroy when reloading scene
		DontDestroyOnLoad (transform.gameObject);
	}


	// Use this for initialization
	void Start (){
		gameScore = GameObject.Find("UIScore").GetComponent<Text>();
		gameScore.text =  "Score: " + score.ToString();

	    thoughtbubbles[0] = GameObject.Find("ThoughtBubble1");
	    positions[0] = GameObject.Find("ThoughtBubble1").transform.position;
		answers [0] = GameObject.Find("answers1").GetComponent<TextMesh>();

		thoughtbubbles[1] = GameObject.Find("ThoughtBubble2");
		positions[1] = GameObject.Find("ThoughtBubble2").transform.position;
		answers [1] = GameObject.Find("answers2").GetComponent<TextMesh>();

		thoughtbubbles[2] = GameObject.Find("ThoughtBubble3");
		positions[2] = GameObject.Find("ThoughtBubble3").transform.position;
		answers [2] = GameObject.Find("answers3").GetComponent<TextMesh>();

		thoughtbubbles[3] = GameObject.Find("ThoughtBubble4");
		positions[3] = GameObject.Find("ThoughtBubble4").transform.position;
		answers [3] = GameObject.Find("answers4").GetComponent<TextMesh>();

		thoughtbubbles[4] = GameObject.Find("ThoughtBubble5");
		positions[4] = GameObject.Find("ThoughtBubble5").transform.position;
		answers [4] = GameObject.Find("answers5").GetComponent<TextMesh>();

		thoughtbubbles[5] = GameObject.Find("ThoughtBubble6");
		positions[5] = GameObject.Find("ThoughtBubble6").transform.position;
		answers [5] = GameObject.Find("answers6").GetComponent<TextMesh>();

	}
		

	// Update is called once per frame
	void Update () {

	}

	public void generateAddition() {
		
		//for (int i = 0; i < 1; i++)
		//{
			int number = 1;
		    
			
			int x = Random.Range(1, 25);
			int y = Random.Range(1, 25);

			if (number == 1) {
				int result = x + y;
				question = GameObject.Find ("Question1").GetComponent<Text>();
				question.text = "What is : " + x.ToString () + " + " + y.ToString() + " ?";


				for (int z = 0; z < 6; z++) {
				    results[z] = result + Random.Range(3, 15);
					tags [z] = "wrong";
				    answers [z].text = results[z].ToString ();    
				}

			 
			     int index = Random.Range(0,5);
				 results[index] = result;
			     tags[index] = "enemy";


			     for (int q = 0; q < 6; q++) {
				       answers[q].text = results[q].ToString();
			      }

			}

			/*
				if (user == result)
				    score++;
				else
					score--;
			}

			if (number == 2)
			{
				int result = x - y;
				cout << "\nEnter the answer to: " << x << " - " << y << endl;
				cin >> user;
				if (user == result)
					cout << "Correct!\n\n";
				else
					cout << "Incorrect!\n\n";
			}

			if (number == 3)
			{
				int result = x * y;
				cout << "\nEnter the answer to: " << x << " * " << y << endl;
				cin >> user;
				if (user == result)
					cout << "Correct!\n\n";
				else
					cout << "Incorrect!\n\n";
			}*/
		}
	//}

	public void displayScore () {
		gameScore = GameObject.Find("UIScore").GetComponent<Text>();
		gameScore.text = "Score: " + score.ToString ();
	}

}