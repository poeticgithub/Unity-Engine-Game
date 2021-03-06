using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager gm = null;
    public int score, highscore;
    public Text gameScore, HighScore, Hitpoints;
    public Text question;
    public Text shotCount;
    public int number;
    public int shots = 1 , hitpoints = 5;
    public int index;
    public bool canShoot = true;


    public GameObject[] thoughtbubbles = new GameObject[6];
    public Vector3[] positions = new Vector3[6];
    public int[] results = new int[6];
    public string[] tags = new string[6];
    public TextMesh[] answers = new TextMesh[6];


    void Awake()
    {
        if (gm == null)
        {
            //if not, set instance to this
            gm = this;
            score = 0;
            highscore = PlayerPrefs.GetInt("HighScore");
            HighScore = GameObject.Find("High Score").GetComponent<Text>();
            HighScore.text = "High Score: " + highscore.ToString();
        }
        //do not destroy when reloading scene
        DontDestroyOnLoad(transform.gameObject);
        
    }


    // Use this for initialization
    void Start()
    {
        gameScore = GameObject.Find("UIScore").GetComponent<Text>();
        gameScore.text = "Score: " + score.ToString();

        thoughtbubbles[0] = GameObject.Find("ThoughtBubble1");
        positions[0] = GameObject.Find("ThoughtBubble1").transform.position;
        answers[0] = GameObject.Find("answers1").GetComponent<TextMesh>();

        thoughtbubbles[1] = GameObject.Find("ThoughtBubble2");
        positions[1] = GameObject.Find("ThoughtBubble2").transform.position;
        answers[1] = GameObject.Find("answers2").GetComponent<TextMesh>();

        thoughtbubbles[2] = GameObject.Find("ThoughtBubble3");
        positions[2] = GameObject.Find("ThoughtBubble3").transform.position;
        answers[2] = GameObject.Find("answers3").GetComponent<TextMesh>();

        thoughtbubbles[3] = GameObject.Find("ThoughtBubble4");
        positions[3] = GameObject.Find("ThoughtBubble4").transform.position;
        answers[3] = GameObject.Find("answers4").GetComponent<TextMesh>();

        thoughtbubbles[4] = GameObject.Find("ThoughtBubble5");
        positions[4] = GameObject.Find("ThoughtBubble5").transform.position;
        answers[4] = GameObject.Find("answers5").GetComponent<TextMesh>();

        thoughtbubbles[5] = GameObject.Find("ThoughtBubble6");
        positions[5] = GameObject.Find("ThoughtBubble6").transform.position;
        answers[5] = GameObject.Find("answers6").GetComponent<TextMesh>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void generateAddition()
    {

        System.Random rnd = new System.Random(DateTime.Now.Millisecond);

        number = rnd.Next(1, 5);

        if (number == 1)
        {
			
			int x = rnd.Next(1, 10);
			int y = rnd.Next(1, 10);
			int w = rnd.Next(2, 6);

			 int result = (x + y) * w;
			 question = GameObject.Find("Question1").GetComponent<Text>();
			 question.text = "What is : " + x.ToString() + " + " + y.ToString() + " ?";
			 question.text = "What is : (" + x.ToString() + " + " + y.ToString() + ") * " + w.ToString() + "?";


            for (int z = 0; z < 6; z++)
            {
                results[z] = result + rnd.Next(3, 15);
                tags[z] = "wrong";
                answers[z].text = results[z].ToString();
            }

            index = rnd.Next(0, 6);
            results[index] = result;
            tags[index] = "enemy";

            for (int q = 0; q < 6; q++)
            {
                answers[q].text = results[q].ToString();
            }

        }


        else if (number == 2)
        {
			int x = rnd.Next(1, 15);
			int y = rnd.Next(1, 15);     
			int result = x + (2*y);
		    question = GameObject.Find("Question1").GetComponent<Text>();
			question.text = "What is : " + x.ToString() + " + 2 * " + y.ToString() + " ?";


            for (int z = 0; z < 6; z++)
            {
                results[z] = result + rnd.Next(3, 15);
                tags[z] = "wrong";
                answers[z].text = results[z].ToString();
            }

            index = rnd.Next(0, 6);
            results[index] = result;
            tags[index] = "enemy";


            for (int q = 0; q < 6; q++)
            {
                answers[q].text = results[q].ToString();
            }

        }


        else if (number == 3)
        {
			
			int x = rnd.Next(1, 10);
			int y = rnd.Next(1, 10);

			int result = (3*x) - (2*y);
			question = GameObject.Find("Question1").GetComponent<Text>();
			question.text = "What is : 3 * " + x.ToString() + " - 2 * " + y.ToString() + " ?";

            for (int z = 0; z < 6; z++)
            {
                results[z] = result + rnd.Next(3, 15);
                tags[z] = "wrong";
                answers[z].text = results[z].ToString();
            }

            index = rnd.Next(0, 6);
            results[index] = result;
            tags[index] = "enemy";


            for (int q = 0; q < 6; q++)
            {
                answers[q].text = results[q].ToString();
            }
        }

        else if (number == 4)
			
        {

		     int x = rnd.Next(1, 6);
		     int y = rnd.Next(1, 6);

			 int result = x * y;
			 double result1 = Math.Pow((double)(x + y), 2);
			 result = Convert.ToInt32(result1);
			 question = GameObject.Find("Question1").GetComponent<Text>();
			 question.text = "What is : (" + x.ToString() + " + " + y.ToString() + ")^2 ?";

            for (int z = 0; z < 6; z++)
            {
                results[z] = result + rnd.Next(3, 16);
                tags[z] = "wrong";
                answers[z].text = results[z].ToString();
            }

            index = rnd.Next(0, 6);
            results[index] = result;
            tags[index] = "enemy";


            for (int q = 0; q < 6; q++)
            {
                answers[q].text = results[q].ToString();
            }
        }
    }


    public void displayScore()
    {
        gameScore = GameObject.Find("UIScore").GetComponent<Text>();
        gameScore.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
        if (PlayerPrefs.GetInt("Score") > highscore)
        {
         PlayerPrefs.SetInt("HighScore", score);
         UnityEngine.SceneManagement.SceneManager.LoadScene("Reward");
        }
        HighScore = GameObject.Find("High Score").GetComponent<Text>();
        HighScore.text = "High Score: " + highscore.ToString();
           
    }

    public void displayShots()
    {

      
        shotCount = GameObject.Find("Shot Count").GetComponent<Text>();
        shotCount.text = "Shot Count: " + shots.ToString();
        Hitpoints = GameObject.Find("Hitpoints").GetComponent<Text>();
        Hitpoints.text = "Hitpoints: " + hitpoints.ToString();
        if (hitpoints == 1)
        {
            Hitpoints.color = Color.red;
            Hitpoints.text = "1 hitpoint left! Be careful!";
        }

        if (shots == 1)
        {
            shotCount.color = Color.red;
            shotCount.text = "1 shot left!";
        }
    }

}