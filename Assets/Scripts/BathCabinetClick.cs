using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathCabinetClick : MonoBehaviour
{
   
    [SerializeField] private Animator Door;

    private bool clickState = false;

    public void Start(){
        
        Door.SetBool("Click", clickState);


    }
    void OnMouseDown(){

        clickState = !clickState;
        Door.SetBool("Click", clickState);
        Debug.Log("clicked");
        
        
    }
}
