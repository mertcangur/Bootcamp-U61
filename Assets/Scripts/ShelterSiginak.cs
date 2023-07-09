using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShelterSiginak : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("SampleScene");

    }

}
