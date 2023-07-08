using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private Animator Anim;
    [SerializeField] private Canvas keypad;
    [SerializeField] private Animator Sandık;
    [SerializeField] private Animator Canvas;
    public Collider coll;
    public GameObject KeyPad;
    private string Answer = "2013";
    public Scene _scene;


    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Update()
    {
        if(  Ans.text.Length > 4){
            Ans.text = null;
            Anim.SetBool("AnimState", true);
           
        }else if( Ans.text == Answer){
            Anim.SetBool("AnswerState", true);
            coll.enabled = !enabled;
            StartCoroutine(Coroutine());
            
            //Canvas.SetBool("Click", true);
        }
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2);
        Sandık.SetBool("TrueAnswer", true);
        KeyPad.gameObject.SetActive(false);
        Sandık.SetBool("AnswerState", true);
    }
}
