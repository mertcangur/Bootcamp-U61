using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = System.Random;

public class ChildScript : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject child;
    public void Start()
    {
        var r = new Random();
        int a = 1;
        var randomValues = Enumerable.Range(0,a)
            .Select(e => spawnPoints[r.Next(spawnPoints.Count)]);
            Debug.Log(randomValues.Count());
        foreach(var Transform in randomValues){
            Instantiate(child,transform);
        }
    }
}
