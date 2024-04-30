using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideUI : MonoBehaviour
{

    public Canvas canvas;

    public void hide(){
        canvas.enabled = false;
    }
}
