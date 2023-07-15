using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Camera;
    public GameObject keypad;
    [SerializeField] private Animator Canvas;
    public GameObject List;
    public bool list = false;
    
    void Start(){
        List.gameObject.SetActive(true);
        keypad.gameObject.SetActive(false);
        //Canvas.SetBool("Click", true);
        MainCamera.gameObject.SetActive(true);
        Camera.gameObject.SetActive(false);
        

    }

    void OnMouseDown()
    {
            keypad.gameObject.SetActive(true);
            MainCamera.gameObject.SetActive(false);
            Camera.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Canvas.SetBool("Click", false);
        
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            keypad.gameObject.SetActive(false);
            MainCamera.gameObject.SetActive(true);
            Camera.gameObject.SetActive(false);
            Cursor.visible = false;
            //Canvas.SetBool("Click", true);
    }
    if(Input.GetKeyDown(KeyCode.L)){
        List.gameObject.SetActive(list);
        list = !list;
    }
}
}
