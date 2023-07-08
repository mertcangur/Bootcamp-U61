using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleScript : MonoBehaviour
{
   
   void OnMouseDown(){
      Debug.Log("clicked");
        SceneManager.LoadScene("PuzzleScene");
    
   }
}
