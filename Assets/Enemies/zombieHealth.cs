using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class zombieHealth : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private AudioSource au;
    float zombieH = 1f;

    [SerializeField] GameObject forAnim;

    private void Start()
    {
        anim = forAnim.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        au = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if(zombieH <= 0f)
        {
            anim.SetBool("isDead", true);
            au.Stop();
            agent.isStopped = true;
            Invoke(nameof(destroyIt),6f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rbullet"))
            takeDamage(0.2f);
    }

    private void takeDamage(float damage)
    {
        zombieH -= damage;
    }
    private  void destroyIt()
    {
        GameObject.Destroy(gameObject);
    }
}
