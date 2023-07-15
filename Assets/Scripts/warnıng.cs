using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class warnıng : MonoBehaviour
{
    public TMP_Text warning;
    void Start(){
        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine(){
        warning.enabled = true;
        yield return new WaitForSeconds(3);
        warning.enabled = false;
    }
    
}
