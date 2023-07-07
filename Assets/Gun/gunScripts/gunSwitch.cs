using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] guns;
    //[SerializeField] Image[] gunsUI;
    
    int index;

    private void Start()
    {
        index = 1;
        change(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && index != 1)
        {
            change(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && index != 2)
        {
            change(2);
        }
    }

    private void change(int number)
    {
        guns[number - 1].GetComponent<gun>().resetPos();


        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
            //gunsUI[i].gameObject.SetActive(false);
        }
        guns[number - 1].SetActive(true);
        //gunsUI[number - 1].gameObject.SetActive(true);
        index = number;
    }
}
