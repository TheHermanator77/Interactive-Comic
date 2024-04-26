using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying = false;

    public BeatScroller theBS;

    public static GameManager instance; //makes the GameManager a singleton, so we can access it from other scripts

    public int currentScore;
    public int scorePerNote = 1;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    //the current keycode of touch button being pressed
    public KeyCode colorPressed;
    public Text scoreText;
    public Text multiText;
    public Button startButton;
    public TextMeshProUGUI instructions;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if(startPlaying == true){
            currentMultiplier = 1;
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

    public void PlayMusic()
    {
        Debug.Log("PlayMusic");
        theMusic.Play();
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        startButton.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        startPlaying = true;
        theBS.hasStarted = true;
        Debug.Log("Invoke PlayMusic");
        Invoke("PlayMusic", 1f);
    }


    //green pressed
    public void Green(){
        colorPressed = KeyCode.A;
        Invoke("Reset", 0.01f);
    }

    //red pressed   
    public void Red(){
        colorPressed = KeyCode.S;
        Invoke("Reset", 0.01f);
    }

    //yellow pressed
    public void Yellow(){
        colorPressed = KeyCode.D;
        Invoke("Reset", 0.01f);
    }

    //blue pressed
    public void Blue(){
        colorPressed = KeyCode.F;
        Invoke("Reset", 0.01f);
    }


    //reset colorPressed
    public void Reset(){
        colorPressed = KeyCode.None;
    }
    

}
