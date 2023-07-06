using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundplayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
