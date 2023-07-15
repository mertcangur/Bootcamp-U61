using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera mapCamera;
    [SerializeField] private GameObject map;
    public Canvas canvas;
    public Canvas canvas2;

    void Start(){
            mainCamera.enabled = true;
            mapCamera.enabled = false;
            canvas.enabled = true;
            canvas2.enabled = true;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            mainCamera.enabled = false;
            mapCamera.enabled = true;
            canvas.enabled = false;
            canvas2.enabled = false;
        }else if(Input.GetKeyDown(KeyCode.Escape)){
            mainCamera.enabled = true;
            mapCamera.enabled = false;
            canvas.enabled = true;
            canvas2.enabled = true;
        }
    }

}
