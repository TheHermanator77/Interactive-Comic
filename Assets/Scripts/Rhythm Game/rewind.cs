using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind : MonoBehaviour
{

    public AudioSource theMusic;
    public BeatScroller theBS;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }


}
