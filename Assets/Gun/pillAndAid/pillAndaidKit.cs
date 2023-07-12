using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pillAndaidKit : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject pill;
    [SerializeField] GameObject aidKit;
    [SerializeField] GameObject Weapons;
    [SerializeField] GameObject forAnim;

    [Header("Images")]
    [SerializeField] Image danger;
    [SerializeField] Image health;

    [Header("Clips")]
    [SerializeField] AudioClip pillAu;
    [SerializeField] AudioClip firstAu;

    private AudioSource au;
    private Animator anim;
    private float dangerData;
    private float healthData;
    private bool forUsing = false;
    void Start()
    {
        au = GetComponent<AudioSource>();
        anim = forAnim.GetComponent<Animator>();
        dangerData = GameObject.Find("healthhh").GetComponent<healthBar>().danger;
        healthData = GameObject.Find("healthhh").GetComponent<healthBar>().health;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && forUsing == false && danger.fillAmount<1f)
            UsePill();
        if (Input.GetKeyDown(KeyCode.X) && forUsing == false && health.fillAmount<1f)
            UseAidKit();
    }

    void UsePill()
    {
        forUsing = true;
        Weapons.gameObject.SetActive(false);
        forAnim.gameObject.SetActive(true);
        pill.gameObject.SetActive(true);
        au.PlayOneShot(pillAu);
        anim.Play("Pill");
        dataSet(2);
        Invoke(nameof(weaponsBack), 1f);
    }

    void UseAidKit()
    {
        forUsing = true;
        Weapons.gameObject.SetActive(false);
        forAnim.gameObject.SetActive(true);
        aidKit.gameObject.SetActive(true);
        anim.Play("aidKit");
        dataSet(1);
        au.PlayOneShot(firstAu);
        au.PlayOneShot(firstAu);
        Invoke(nameof(weaponsBack), 3f);
    }

    void weaponsBack()
    {
        anim.Rebind();
        aidKit.gameObject.SetActive(false);
        pill.gameObject.SetActive(false);
        forAnim.gameObject.SetActive(false);
        Weapons.gameObject.SetActive(true);
        forUsing = false;
    }
    void dataSet(int num)
    {
        if(num == 1)
            GameObject.Find("healthhh").GetComponent<healthBar>().health += 25f;
        else
            GameObject.Find("healthhh").GetComponent<healthBar>().danger += 40f;

    }

}
