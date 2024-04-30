using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellaMovement : MonoBehaviour
{
    //makes the GameManager a singleton, so we can access it from other scripts
    public static BellaMovement instance;

    //canvas renderer
    private CanvasRenderer rend;

    private RectTransform rt;

    //Timer for Bella to be Shown
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rt = (RectTransform)transform;

        //hide Bella 
        rend = GetComponent<CanvasRenderer>();
        //set alpha to 0
        rend.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        //if the timer is less than 0, hide Bella
        if(timer <= 0){
            rend = GetComponent<CanvasRenderer>();
            rend.SetAlpha(0);
        } else {
            timer -= Time.deltaTime;
        }
        
    }

    void showBella(){
        //start the timer
        timer = 0.5f;

        rend.SetAlpha(1);
    } 

    public void Green(){
        
        rt.anchoredPosition = new Vector2(-216f, -639f); 
        showBella();
    }

    public void Blue(){
        rt.anchoredPosition = new Vector2(-216f, -639f); 
        showBella();
    }

    public void Red(){
        rt.anchoredPosition = new Vector2(-75f, -639f); 
        showBella();
    }   

    public void Yellow(){
        rt.anchoredPosition = new Vector2(75F, -639f); 
        showBella();
    }


}
