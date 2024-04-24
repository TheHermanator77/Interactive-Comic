using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEntanglement : MonoBehaviour
{

    public static EnableEntanglement instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void EntangleButton(){
        Debug.Log("Entangle Button Enabled");
        //Set scale to 3.1
        transform.localScale = new Vector3(3.1f, 3.1f, 3.1f);
    }

    public void DisableEntangleButton(){
        Debug.Log("Entangle Button Disabled");
        //Set scale to 0
        transform.localScale = new Vector3(0,0,0);
    }
}