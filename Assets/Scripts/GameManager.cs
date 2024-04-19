using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance; //makes the GameManager a singleton, so we can access it from other scripts

    public int currentScore;
    public int scorePerNote = 1;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;


    public Text scoreText;
    public Text multiText;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            //Start playing when the player presses a key
            if(Input.anyKeyDown)
            {
                startPlaying = true; //start the game, just a boolean for me :D
                theBS.hasStarted = true; //scroll the notes
                theMusic.Play(); //start the music
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit On Time");

        //we dont want an infinite multiplier, so we check if the currentMultiplier is less than the length of the array
        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            //multiplierThresholds is an array that holds the thresholds for each multiplier
            //if the multiplierTracker is greater than or equal to the current threshold, then the multiplier goes up
            if(multiplierTracker >= multiplierThresholds[currentMultiplier - 1])
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        //Update text and score
        multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NoteMissed()
    {
        //Debug.Log("Missed Note");

        //reset the multiplier
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
    }

}
