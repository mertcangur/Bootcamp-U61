using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShelterSiginak : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        StartCoroutine(Coroutine());

    }
    IEnumerator Coroutine()
    {
        Debug.Log("corotunie");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");

    }

}
