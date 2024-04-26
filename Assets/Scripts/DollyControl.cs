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
        // Check if the waypoint is within the range
        if(waypoint < 0 || waypoint > 16){
            return;
        }
        // Move the dolly to the waypoint
        vcam.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathPosition = waypoint;

    }

    private int GetDollyPosition(){
        // Get the current dolly position
        int dollyPosition = (int)vcam.GetCinemachineComponent<Cinemachine.CinemachineTrackedDolly>().m_PathPosition;
        return dollyPosition;
    }

    // Show the buttons based on the dolly position
    private void ShowButtons(){
        int dollyPosition = GetDollyPosition();

        switch(dollyPosition){
            case 9:
                Debug.Log("Dolly Position: 0");
                EnableEntanglement.instance.DisableEntangleButton();
                break;
            case 10:
                Debug.Log("Dolly Position: 10");
                Invoke("Entangle", 0.25f);
                EnableAnimation.instance.stopAnimation();
                break;
            case 11:
                Debug.Log("Dolly Position: 11");
                EnableEntanglement.instance.DisableEntangleButton();
                Invoke("Animation", 0.25f);
                break;
            case 12:
                Debug.Log("Dolly Position: 12");
                EnableAnimation.instance.stopAnimation();
                EnableTunnelling.instance.DisableTunnellingButton();
                break;
            case 13:
                Debug.Log("Dolly Position: 13");
                Invoke("Tunnelling", 0.25f);
                break;
            case 14:
                Debug.Log("Dolly Position: 14");
                EnableTunnelling.instance.DisableTunnellingButton();
                EnableRhythm.instance.DisableRhythmButton();
                break;
            case 16:
                Debug.Log("Dolly Position: 16");
                Invoke("Rhythm", 0.25f);
                break;
            default:
                Debug.Log("Dolly Position: Default");
                EnableEntanglement.instance.DisableEntangleButton();
                EnableAnimation.instance.stopAnimation();
                EnableTunnelling.instance.DisableTunnellingButton();
                EnableRhythm.instance.DisableRhythmButton();
                break;
        }
    }

    public void NextPosition(){
        // Get the current dolly position
        int dollyPosition = GetDollyPosition();
        // Move the dolly to the next waypoint
        MoveDolly(dollyPosition + 1);

        // Show the buttons based on the dolly position
        ShowButtons();
    }

    public void PreviousPosition(){
        // Get the current dolly position
        int dollyPosition = GetDollyPosition();
        if(dollyPosition == 0){
            return;
        }
        // Move the dolly to the previous waypoint
        MoveDolly(dollyPosition - 1);
        ShowButtons();
    }

    public void Animation(){
        EnableAnimation.instance.playAnimation();
    }

    public void Entangle(){
        EnableEntanglement.instance.EntangleButton();
    }

    public void Tunnelling(){
        EnableTunnelling.instance.TunnellingButton();
    }

    public void Rhythm(){
        EnableRhythm.instance.RhythmButton();
    }

}
