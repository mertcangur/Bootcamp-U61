using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    void OnMouseDown(){
        Debug.Log("clicked");
        StartCoroutine(Coroutine());
    }
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Winner");
    }
}
