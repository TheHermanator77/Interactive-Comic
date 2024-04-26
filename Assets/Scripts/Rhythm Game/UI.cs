using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void StartGame(){
        Debug.Log("Game Started");
        //Load the Rhythm Game
        GameManager.instance.StartGame();
    }
}
