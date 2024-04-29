using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;

    public bool hasStarted;

    public float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
          /* if(Input.anyKeyDown){
                hasStarted = true;
            } */
        } else {
            currentTime += Time.deltaTime;
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f); // Move the object down to the tempo Vector3(x, y, z))
        }
    }

    public void Rewind5()
    {
        currentTime -= 10f;
        transform.position += new Vector3(0f, beatTempo * 10f, 0f);
    }

    public void FastForward5()
    {
        currentTime += 10f;
        transform.position -= new Vector3(0f, beatTempo * 10f, 0f);
    }
}
