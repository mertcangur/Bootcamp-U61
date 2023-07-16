using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using Cinemachine;


public class AnimCanvasScript : MonoBehaviour
{
    public int num = 0;
    public GameObject AnimCanvas;
    public Canvas gameCanvas;
    public Camera AnimCam;
    public Camera mainCam;
    public GameObject Player;
    
    public GameObject Doktor;
    public Collider coll;
    public Animator CamAnim;
    public TMP_Text dialog;
    List<string> dialogs = new List<string>();
    

    void Start(){
        dialog.enabled=false;
        //dialogs.Add("- THIS PLACE SEEMS ABANDONED");
        //dialogs.Add("- WAIT..." + "\n" + "- WH.. WHO ARE YOU?" + "\n" + "- IS IT A HUMAN!");
        dialogs.Add("+ HEY CALM DOWN DUDE." + "\n" + " +IM DOCTOR JONATHAN.");
        dialogs.Add("- WHAT ARE YOU DOING HERE!"+"\n"+ "\n" + "+ REMOVE THIS GUN!");
        dialogs.Add("+ OK... THIS PLACE IS LEFTED IM SEARCHING FOR SOME DRUGS." + "\n" + " + SO, WHY ARE YOU HERE?");
        dialogs.Add("- I.. IM LOOKING FOR MY SON." + "\n" + "\n" + " + PEOPLE LEFT THIS SHELTER A FEW MONTHS AGO. ALL PEOPLE STAYS AT THE SECRET GARDEN. BUT... BUT MOST OF THE CHILDREN HAVE BEEN TAKEN!" + "\n" + "\n" +"- GOD... WHAT WILL I DO");
        dialogs.Add("+ HERE IS A MAP, IT IS SO DANGEROUS BUT THERE IS A WEAPON IN THIS SHELTER. FIND IT AND BE AWARE! ");
    }

    public void Update()
    {
        if(AnimCam.enabled){
            CamAnim.SetBool("Opened", true);
            dialog.enabled=true;
            if(true && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("clicked");
                coll.enabled = false;
                Player.SetActive(false);
                if (num < 5)
                {
                    Destroy(Doktor);
                    dialog.text = dialogs[num];
                    GameObject child = AnimCanvas.transform.GetChild(num).gameObject;
                    child.SetActive(false);
                    num++;
                    print(num);
                }else{
                    CamAnim.SetBool("Opened", false);
                    dialog.enabled=false;
                    Player.transform.position = new Vector3(-4.10159779f,-0.765999973f,8.26251411f);
                    AnimCam.enabled = false;
                    mainCam.enabled = true;
                    Player.SetActive(true);
                    gameCanvas.enabled = true;
                }
        }
}
    }
}
