using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void StartGame(){
        Debug.Log("Game Started");
        //Load the Rhythm Game
        GameManager.instance.StartGame();
    }

    public void EndGame(){
        Debug.Log("Game Ended");
        //switch scenes
        SceneManager.LoadScene("Credits");
    }
}
