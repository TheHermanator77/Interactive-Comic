using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind : MonoBehaviour
{

    public AudioSource theMusic;
    public BeatScroller theBS;

    public void Rewind()
    {
        //Rewind the game 5 seconds
        theMusic.time = theMusic.time - 10f;

        //Rewind the notes
        foreach (GameObject note in GameObject.FindGameObjectsWithTag("Note"))
        {
            note.SetActive(true);
        }

        theBS.Rewind5();
    }

    public void FastForward()
    {
        //Fast forward the game 5 seconds
        theMusic.time = theMusic.time + 10f;

        theBS.FastForward5();

        //Fast forward the notes
        foreach (GameObject note in GameObject.FindGameObjectsWithTag("Note"))
        {
            note.SetActive(true);
        }
    }

    public void Reset()
    {
        //Reset the game
        theMusic.time = 0f;

        theBS.Reset();

        //Reset the notes
        foreach (GameObject note in GameObject.FindGameObjectsWithTag("Note"))
        {
            note.SetActive(true);
        }
    } 


}
