using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnimCanvasScript : MonoBehaviour
{
    public int num = 0;
    public GameObject AnimCanvas;
    public Canvas gameCanvas;
    public Camera AnimCam;
    public Camera mainCam;
    public GameObject Player;
    public Collider coll;

    void Update()
    {
        if(AnimCam.enabled == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("clicked");
            coll.enabled = false;
            Player.SetActive(false);
            if (num < 6)
            {
                GameObject child = AnimCanvas.transform.GetChild(num).gameObject;
                child.SetActive(false);
                num++;
                print(num);
    }else{
        Player.transform.position = new Vector3(-4.10159779f,-0.765999973f,8.26251411f);
        AnimCam.enabled = false;
        mainCam.enabled = true;
        Player.SetActive(true);
        gameCanvas.enabled = true;
    }
}
    }
}
