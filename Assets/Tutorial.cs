using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    
    Text equation;
    public GameObject player, enemy, enemy2, enemy3, question;
    private bool animIdle = false, playerMade = false, leftKeyPressed = false, rightKeyPressed = false,
        enemyMade = false, bubbleShot = false;
    Animator anim;
    TextMesh text;
    ArrayList words;
    string[] line = { "Hello!", "Welcome to the Tutorial! Lets Start !", "See that guy that popped up?",
                    "Yea that's you", "Lets try moving him...", "Use arrow keys to move left and right",
                     "Good job!", "A Math problem just popped up", "You need to shoot the right answer...",
                     "Try shooting the answer(use spacebar)", "Great Job ! Your a natural!!", "You are now ready to play!"
                        ,"Press Enter to play the game"};
    StreamReader theReader;
    int j = 0;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        text = GetComponentInChildren<TextMesh>();
        equation = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animIdle = true;
            Debug.Log("Anim is playing");
        }
        if (animIdle == true)
        {
            text.text = line[j];
        }

        if (j == 2 && playerMade == false)
        {
            playerMade = true;
            Instantiate(player, new Vector2(0, -2.5f), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (j == 5 && leftKeyPressed && rightKeyPressed)
            {
                Debug.Log("Enter pressed");
                j++;
            } else if (j < 5)
            {
                j++;
            } else if (j > 5)
            {
                j++;
            } else
            {
                Debug.Log("Nothing");
            }
        }

        if (j == 5)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftKeyPressed = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightKeyPressed = true;
            }
            if (rightKeyPressed && leftKeyPressed)
            {
                j++;
            }

        }

        if (j == 7)
        {
            Debug.Log("question");
            Vector3 temp = new Vector3(1.55f, -2.0f, 0f);
            question.transform.position = temp;
        }

        if (j == 9 && enemyMade == false)
        {
            enemyMade = true;
            Instantiate(enemy, new Vector3(0, 3), Quaternion.identity);
            Instantiate(enemy2, new Vector3(-3, 3), Quaternion.identity);
            Instantiate(enemy3, new Vector3(3, 3), Quaternion.identity);

        }

        if(Projectile.projectile.shot == true) {
            Debug.Log("Hello");
            j++;
            Projectile.projectile.shot = false;
        }

        if( j == 12)
        {
            SceneManager.LoadScene("Level_1");

        }
    }

        
    }

   /* void readText()
    {
        theReader = new StreamReader("tutorial.txt", Encoding.Default);
        int i = 0;
        using (theReader)
        {
            while (!theReader.EndOfStream)
            {
                line[i] = theReader.ReadLine();
                Debug.Log(line[i]);
                i++;
            }
            theReader.Close();

        }
    }*/

