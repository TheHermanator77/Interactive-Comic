using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfMovement : MonoBehaviour
{

    public static ProfMovement instance; //makes the GameManager a singleton, so we can access it from other scripts

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Green(){
        transform.position = new Vector3(-1.56f, 3.9f, 0f); // Move the object down to the tempo Vector3(x, y, z))
    }

    public void Blue(){
        transform.position = new Vector3(1.41f, 3.9f, 0f); // Move the object down to the tempo Vector3(x, y, z))
    }

    public void Red(){
        transform.position = new Vector3(-0.7f, 3.9f, 0f); // Move the object down to the tempo Vector3(x, y, z))
    }   

    public void Yellow(){
        transform.position = new Vector3(0.28f, 3.9f, 0f); // Move the object down to the tempo Vector3(x, y, z))
    }


}
