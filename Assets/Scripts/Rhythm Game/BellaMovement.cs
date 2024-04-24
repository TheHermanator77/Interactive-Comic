using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellaMovement : MonoBehaviour
{

    public static BellaMovement instance; //makes the GameManager a singleton, so we can access it from other scripts

    //Render for Bella
    public Renderer rend;

    //Timer for Bella to be Shown
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if the timer is less than 0, hide Bella
        if(timer <= 0){
            rend = GetComponent<Renderer>();
            rend.enabled = false;
        } else {
            timer -= Time.deltaTime;
        }
        
    }

    void showBella(){
        //start the timer
        timer = 0.5f;

        rend.enabled = true;
    } 

    public void Green(){

        transform.position = new Vector3(-1.48f, -3.4211f, 0f); // Move the object down to the tempo Vector3(x, y, z))
        showBella();

        Debug.Log("Moved Bella to Green");
    }

    public void Blue(){
        transform.position = new Vector3(1.48f, -3.4211f, 0f); // Move the object down to the tempo Vector3(x, y, z))
        showBella();
    }

    public void Red(){
        transform.position = new Vector3(-0.51f, -3.4211f, 0f); // Move the object down to the tempo Vector3(x, y, z))
        showBella();
    }   

    public void Yellow(){
        transform.position = new Vector3(0.51f, -3.4211f, 0f); // Move the object down to the tempo Vector3(x, y, z))
        showBella();
    }


}
