using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadRhythm(){
        Debug.Log("Loading Rhythm Game");
        SceneManager.LoadScene("RhythmGame");
    }

    public void loadEntanglement(){
        Debug.Log("Loading Entanglement Game");
        SceneManager.LoadScene("EntanglementGame");
    }

    public void loadTunnelling(){
        Debug.Log("Loading Tunnelling Game");
        SceneManager.LoadScene("TunnelGame");
    }  

   
}
