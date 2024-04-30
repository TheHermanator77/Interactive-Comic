using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class EnableAnimation : MonoBehaviour
{
    public VideoPlayer vp;
    private bool hasStarted = false;

    public static EnableAnimation instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(hasStarted){
            CheckIfFinished();
        }
        
    }
    public void ShowAnimation(){
        Debug.Log("show Animation");
        //Set scale to 3.1
        transform.localScale = new Vector3(5f,5f,5f);
    }

    public void PlayAnimation(){
        Debug.Log("Play Animation");
        vp.Play();
        Invoke("CheckIfFinished", 3f);
    }

    public void CheckIfFinished(){
        hasStarted = true;
        if(vp.isPlaying){
            return;
        }
        vp.enabled = false;
        hasStarted = false;
    }

    public void stopAnimation(){
        Debug.Log("Stop Animation");
        //Set scale to 0
        transform.localScale = new Vector3(0,0,0);
    }
}