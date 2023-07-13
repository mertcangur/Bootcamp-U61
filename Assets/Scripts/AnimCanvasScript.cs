using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class AnimCanvasScript : MonoBehaviour
{
    public int num = 0;
    public GameObject AnimCanvas;
    public Canvas gameCanvas;
    public Camera AnimCam;
    public Camera mainCam;
    public GameObject Player;
    public Collider coll;
    public TMP_Text dialog;
    List<string> dialogs = new List<string>();
    

    void Start(){
        dialogs.Add("- IT SEEMS LIKE ABANDONED THIS PLACE..");
        dialogs.Add("- EUWW.. I HOPE IT IS ALIVE.");
        dialogs.Add("- IM GONA SHOOT MY..." + "\n" + "WAIT WHO ARE YOU?" + "\n" + "IS IT A HUMAN!");
        dialogs.Add("+OH MY BACK..." + "\n" + " +BE CALM DUDE IM DOCTOR ELLY.");
        dialogs.Add("+REMOVE THIS GUN!" + "\n" + "+WHY ARE YOU HERE?" + "\n" + " -IM LOOKING FOR MY SON");
        dialogs.Add("+OH SORRY FOR YOU MAN. PEOPLE LEFT THIS SHELTER A FEW MONTHS AGO. ALL PEOPLE STAYS AT THE SECRET GARDEN. BUT... BUT MOST OF THE CHILDREN HAVE BEEN TAKEN!" + "\n" + "- GOD... WHAT WILL I DO");
        dialogs.Add("+ HERE IS A MAP, IT IS SO DANGEROUS BUT THERE IS A WEAPON IN THIS SHELTER. FIND IT AND BE AWARE! ");
    }

    void Update()
    {
        if(AnimCam.enabled == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("clicked");
            coll.enabled = false;
            Player.SetActive(false);
            if (num < 7)
            {
                dialog.text = dialogs[num];
                GameObject child = AnimCanvas.transform.GetChild(num).gameObject;
                child.SetActive(false);
                num++;
                print(num);
    }else{
        dialog.enabled = false;
        Player.transform.position = new Vector3(-4.10159779f,-0.765999973f,8.26251411f);
        AnimCam.enabled = false;
        mainCam.enabled = true;
        Player.SetActive(true);
        gameCanvas.enabled = true;
    }
}
    }
}
