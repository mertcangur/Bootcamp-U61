using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthBar : MonoBehaviour
{
    [SerializeField] bool is_outside;
    public float health = 100f;
    public float danger = 0f;

    [SerializeField] Image healtfBar;
    [SerializeField] Image dangerBar;

    float heal = 100f;
    float dang = 0f;


    
    // Update is called once per frame
    void Update()
    {
        
        if(is_outside && danger<=100f)
        {
            danger += Time.deltaTime * 1f;
        }
        else if(is_outside && danger>=100f && health>=0f)
        {
            health -= Time.deltaTime * 1f;
        }
        dang = danger / 100;

        heal = health / 100;
        dangerBar.fillAmount = dang;
        healtfBar.fillAmount = heal;

        if (danger < 0f)
            danger = 0f;
        if (health > 100f)
            health = 100f;

        if(health<=0)
        {
            SceneManager.LoadSceneAsync("Lose");
        }
    }

}
