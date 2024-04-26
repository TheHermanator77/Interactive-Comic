using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTunnelling : MonoBehaviour
{

    public static EnableTunnelling instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void TunnellingButton(){
        Debug.Log("Tunnelling Button Enabled");
        //Set scale to 3.1
        transform.localScale = new Vector3(5f,5f,5f);
    }

    public void DisableTunnellingButton(){
        Debug.Log("Tunnelling Button Disabled");
        //Set scale to 0
        transform.localScale = new Vector3(0,0,0);
    }
}