using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerilimAudio : MonoBehaviour
{
    public GameObject Player;
    public Camera mainCam;
    public Camera AnimCam;
    public Canvas gameCanvas;
    public Canvas AnimCanvas;

    void Start(){
        mainCam.enabled = true;
        AnimCam.enabled = false;
        gameCanvas.enabled = true;
        AnimCanvas.enabled = false;
    }

    void OnTriggerEnter(Collider col){
        
        if (col.gameObject.tag == "Anim"){
            mainCam.enabled = false;
            AnimCam.enabled = true;
            gameCanvas.enabled = false;
            AnimCanvas.enabled = true;

        }
    }
}
