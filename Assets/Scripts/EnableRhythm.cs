using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRhythm : MonoBehaviour
{

    public static EnableRhythm instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void RhythmButton(){
        Debug.Log("Rhythm Button Enabled");
        //Set scale to 3.1
        transform.localScale = new Vector3(5f,5f,5f);
    }

    public void DisableRhythmButton(){
        Debug.Log("Rhythm Button Disabled");
        //Set scale to 0
        transform.localScale = new Vector3(0,0,0);
    }
}