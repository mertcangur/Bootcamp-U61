using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BookClick : MonoBehaviour
{
    
    [SerializeField] private Animator book_0001c;
    public GameObject KeyPad;

    private bool clickState = false;

    public void Start(){
        
        book_0001c.SetBool("Click", clickState);
        


    }
    void OnMouseDown(){

        clickState = !clickState;
        book_0001c.SetBool("Click", clickState);
        Debug.Log("clicked");
        KeyPad.gameObject.SetActive(!clickState);
        
        
    }
}
