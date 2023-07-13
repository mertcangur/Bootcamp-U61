using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DepoCikis : MonoBehaviour
{
    public GameObject rifle;

    void OnTriggerEnter(Collider other)
    {
        if (rifle == null)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}