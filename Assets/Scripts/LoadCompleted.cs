using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCompleted : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Winner");
        
    }

}
