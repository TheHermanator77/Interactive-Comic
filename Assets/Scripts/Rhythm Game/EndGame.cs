using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on collider enter, end the game
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("End Game");
        if(other.tag == "Activator")
        {
            GameManager.instance.EndGame();
        }
    }
}
