using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TunnellingUI : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //switch scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("ComicBook");
    }

    //hide UI
    public Canvas canvas;

    public void hide()
    {
        canvas.enabled = false;
    }
}
