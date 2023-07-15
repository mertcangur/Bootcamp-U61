using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterScript : MonoBehaviour
{
    public Collider coll;
    public Animator animator;
    private int collectedObjectNum;

    public void Start()
    {
        coll.enabled = false;
        collectedObjectNum = 0;
    }

    public void UpdateCollectedObjectNum()
    {
        collectedObjectNum++;
        Debug.Log(collectedObjectNum);
        if (collectedObjectNum == 6)
        {
            coll.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        animator.SetBool("SceneCompleted", true);
    }
}
