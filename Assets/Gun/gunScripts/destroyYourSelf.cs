using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyYourSelf : MonoBehaviour
{
    [SerializeField] float destroyTime;
    void Update()
    {
        Invoke("destroy_it", destroyTime);
    }
    void destroy_it()
    {
        Destroy(gameObject);
    }
}
