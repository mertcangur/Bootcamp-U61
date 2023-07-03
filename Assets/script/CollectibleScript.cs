using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    int collectedObjectNum = 0;
    void OnMouseDown(){
        Destroy(this.gameObject);
        collectedObjectNum ++;
        print(collectedObjectNum);

    }
    
}
