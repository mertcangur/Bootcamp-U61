using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoundedObject : MonoBehaviour
{
    [SerializeField] private TMP_Text ListBook;
    public GameObject List;
    public int collectedObjectNum = 0;
    private ShelterScript shelterScript;

    void Start(){
        shelterScript = FindObjectOfType<ShelterScript>();
    }
    void OnMouseDown(){
        Destroy(this.gameObject);
        List.gameObject.SetActive(true);
        collectedObjectNum ++;
        print(collectedObjectNum);
        shelterScript.UpdateCollectedObjectNum();
        ListBook.fontStyle = FontStyles.Strikethrough;

    }

}
