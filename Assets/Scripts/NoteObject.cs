using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    private bool wasHit;
    public bool canBePressed;

    public KeyCode keyToPress;

    //Renderer to show the note
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //hide the note
        rend = GetComponent<Renderer>();
        rend.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                wasHit = true;
                gameObject.SetActive(false);

                //Generate a number 1-3 to choose the animation
                int rand = UnityEngine.Random.Range(1, 4);
                //Debug.Log(rand);

                //move Bella to respective position
                if(gameObject.name.Contains("green") ){
                    switch(rand){
                        case 1:
                            BellaMovement.instance.Red();
                            break;
                        case 2:
                            BellaMovement.instance.Yellow();
                            break;
                        case 3:
                            BellaMovement.instance.Blue();
                            break;
                    }
                } else if(gameObject.name.Contains("blue")){
                    switch(rand){
                        case 1:
                            BellaMovement.instance.Red();
                            break;
                        case 2:
                            BellaMovement.instance.Yellow();
                            break;
                        case 3:
                            BellaMovement.instance.Green();
                            break;
                    }
                } else if(gameObject.name.Contains("red")){
                    switch(rand){
                        case 1:
                            BellaMovement.instance.Green();
                            break;
                        case 2:
                            BellaMovement.instance.Yellow();
                            break;
                        case 3:
                            BellaMovement.instance.Blue();
                            break;
                    }
                } else if(gameObject.name.Contains("yellow")){
                    switch(rand){
                        case 1:
                            BellaMovement.instance.Red();
                            break;
                        case 2:
                            BellaMovement.instance.Green();
                            break;
                        case 3:
                            BellaMovement.instance.Blue();
                            break;
                    }
                }
                

                GameManager.instance.NoteHit(); //calls the NoteHit method from the GameManager
            }
        }
    }

    //When the Note enters the activator or the collider, it can be pressed
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = true;
        }

        if(other.tag == "Collider"){

            //show the note
            rend.enabled = true;

            //Check note color and call the respective method
            if(gameObject.name.Contains("green") ){
                //Debug.Log("Green");
                ProfMovement.instance.Green();
            } else if(gameObject.name.Contains("blue")){
                //Debug.Log("Blue");
                ProfMovement.instance.Blue();
            } else if(gameObject.name.Contains("red")){
                //Debug.Log("Red");
                ProfMovement.instance.Red();
            } else if(gameObject.name.Contains("yellow")){
                //Debug.Log("Yellow");
                ProfMovement.instance.Yellow();
            }
        }
    }

    //when the note exits the activator, it can't be pressed
    public void OnTriggerExit2D(Collider2D other){

        if(other.tag == "Activator" && !wasHit){
            canBePressed = false;

            GameManager.instance.NoteMissed(); //calls the NoteMissed method from the GameManager
        }
    }


}
