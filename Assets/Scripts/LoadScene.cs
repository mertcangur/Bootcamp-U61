using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject Puzzles;
    void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void Update(){
        Collider[] col;
        col = Puzzles.GetComponentsInChildren<Collider>();
        if(col.Length == 0){
            Debug.Log("working");
             StartCoroutine(Coroutine());
        }

    }
    IEnumerator Coroutine()
    {
        Debug.Log("corotunie");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("gizliSiginak");

    }

}
