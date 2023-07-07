using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyYourSelf : MonoBehaviour
{

    void Update()
    {
        Invoke("destroy_it", 2f);
    }
    void destroy_it()
    {
        Destroy(gameObject);
    }
}
