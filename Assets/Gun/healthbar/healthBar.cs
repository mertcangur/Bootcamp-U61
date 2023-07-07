using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthBar : MonoBehaviour
{
    [SerializeField] bool is_outside;
    [SerializeField] float health = 100f;
    [SerializeField] float danger = 100f;

    [SerializeField] Image healtfBar;
    [SerializeField] Image dangerBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_outside && danger>=0f)
        {
            danger -= Time.deltaTime;
        }
        else if(is_outside && danger<=0f && health>=0f)
        {
            health -= Time.deltaTime;
        }
        healtfBar.fillAmount = health / 100;
        dangerBar.fillAmount = danger / 100;

    }
}
