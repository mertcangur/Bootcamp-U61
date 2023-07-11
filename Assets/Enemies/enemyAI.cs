using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class enemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private bool canAttack = true;
    private Animator anim;

    [SerializeField] GameObject forAnim;

    [Header("Zombie Settings")]
    [SerializeField] bool isShearch;
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = forAnim.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("speed", agent.velocity.magnitude);
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange && isShearch) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange && !anim.GetBool("isDead")) AttackPlayer();
    }
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
       
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        transform.LookAt(player);
        if (canAttack)
        {
            anim.SetTrigger("attack");
            canAttack = false;
            StartCoroutine(attack());
        }

        agent.SetDestination(player.position);


        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    IEnumerator attack()
    {
        agent.isStopped = true;

        yield return new WaitForSeconds(1.3f);
        RaycastHit hit;
        Debug.DrawRay(transform.position + new Vector3(0, 1.2f, 0), transform.TransformDirection(Vector3.forward),Color.red); ;
        if (Physics.Raycast(transform.position + new Vector3(0, 1.2f, 0), transform.TransformDirection(Vector3.forward), out hit, 1.5f))
        {
            if (hit.collider.CompareTag("Player"))
                GameObject.Find("health").GetComponent<healthBar>().health -= 15f;

        }
        yield return new WaitForSeconds(1.3f);

        canAttack = true;
        agent.isStopped = false;
        yield return null;
    }
}
