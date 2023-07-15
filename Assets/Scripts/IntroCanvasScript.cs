using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroCanvasScript : MonoBehaviour
{
    List<string> introText = new List<string>();
    public Canvas gameCanvas;
    public Canvas introCanvas;
    public GameObject Player;
    public TMP_Text text;
    private int num = 0;

    void Start(){
        gameCanvas.enabled = false;
        introCanvas.enabled = true;
        Player.SetActive(false);

        introText.Add("These is not a shelter...");
        introText.Add("Monsters have invaded this place!");
        introText.Add("I have to find my filius before they come.");
        introText.Add("I am gona search around for some tools and my son!");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){ 

            if(introCanvas.enabled == true && num < 4){
            Debug.Log("clicked");
                text.text = introText[num];
                num++;
            }
        }else if(num >= 4){
            gameCanvas.enabled = true;
            Player.SetActive(true);
            introCanvas.enabled = false;
        }

    }

}
