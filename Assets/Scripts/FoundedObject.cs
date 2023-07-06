using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoundedObject : MonoBehaviour
{
    [SerializeField] private TMP_Text ListBook;
    public GameObject List;
    int collectedObjectNum = 0;
    void OnMouseDown(){
        Destroy(this.gameObject);
        List.gameObject.SetActive(true);
        collectedObjectNum ++;
        print(collectedObjectNum);
        ListBook.fontStyle = FontStyles.Strikethrough;
    }

}
