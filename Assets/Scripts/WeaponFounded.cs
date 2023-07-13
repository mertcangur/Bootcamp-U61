using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFounded : MonoBehaviour
{
    public GameObject rifle;
    public GameObject RifleImage;

    void Start(){
        RifleImage.SetActive(false);
    }
    void OnMouseDown(){
        Destroy(rifle);
        RifleImage.SetActive(true);
    }
}
