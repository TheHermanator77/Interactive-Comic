using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyControl : MonoBehaviour
{

    //cinemachine virtual camera
    public Cinemachine.CinemachineVirtualCamera vcam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveDolly(int waypoint){
        // Move the dolly to the waypoint
        vcam.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathPosition = waypoint;

    }

    private int GetDollyPosition(){
        // Get the current dolly position
        int dollyPosition = (int)vcam.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathPosition;
        return dollyPosition;
    }

    public void NextPosition(){
        // Get the current dolly position
        int dollyPosition = GetDollyPosition();
        if(dollyPosition == 16){
            return;
        }
        // Move the dolly to the next waypoint
        MoveDolly(dollyPosition + 1);
    }

    public void PreviousPosition(){
        // Get the current dolly position
        int dollyPosition = GetDollyPosition();
        if(dollyPosition == 0){
            return;
        }
        // Move the dolly to the previous waypoint
        MoveDolly(dollyPosition - 1);
    }
}
