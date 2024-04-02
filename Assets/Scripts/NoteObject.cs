using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();
            }
        }
    }

    //When the Note enters the activator, it can be pressed
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = true;
        }
    }

    //when the note exits the activator, it can't be pressed
    public void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = false;
        }
    }
}
