using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimation : MonoBehaviour
{

    public static EnableAnimation instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void playAnimation(){
        Debug.Log("Play Animation");
        //Set scale to 3.1
        transform.localScale = new Vector3(3.1f, 3.1f, 3.1f);
    }

    public void stopAnimation(){
        Debug.Log("Stop Animation");
        //Set scale to 0
        transform.localScale = new Vector3(0,0,0);
    }
}