using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
   public float TimeLeft;
   public bool TimeOn = false;
   public TMP_Text TimerText;
   public TMP_Text TimeOut;

   void Start(){
        TimeOut.enabled = false;
        TimeOn = true;
   }
   void Update(){
    if(TimeOn){
        if(TimeLeft > 0){
            TimeLeft -= Time.deltaTime;
            UpdateTimer(TimeLeft);
        }else{
            StartCoroutine(Coroutine());
            TimeLeft = 0;
            TimeOn = false;
        }
    }
   }
   void UpdateTimer(float currentTime){
        currentTime += 1; 
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{0:00} : {1:00}", minutes,seconds);


   }
   
    IEnumerator Coroutine()
    {
        Debug.Log("coroutine");
        TimeOut.enabled = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Lose");
    }
}
