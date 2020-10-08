using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Name: EnemyAI
 * Purpose: Handles all of the zombies AI
 */
public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] bool isSpawned = false;
    [SerializeField] AudioClip[] zombieScream;
    [SerializeField] AudioClip[] zombieAttack;
    [SerializeField] AudioClip zombieHit;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private EnemyHealth health;
    private CapsuleCollider collider;
    private Transform target;
    private AudioSource zombieAud;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private bool chaseFXPlayed = false;
    private bool los;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        collider = GetComponent<CapsuleCollider>();
        target = FindObjectOfType<PlayerHealth>().transform;
        zombieAud = GetComponent<AudioSource>();
    }

    // PlayAttackFX toggles a random attack sound of an array of sound effects when the zombie begins chasing
    // the player
    void PlayAttackFX()
    {
        chaseFXPlayed = true;
        int fx = UnityEngine.Random.Range(0, zombieAttack.Length);
        zombieAud.clip = zombieAttack[fx];
        zombieAud.Play();
    }

    // PlayScreamFX toggles a random scream sound from an array of sound effects when the zombie dies
    void PlayScreamFX()
    {
        int fx = UnityEngine.Random.Range(0, zombieScream.Length);
        zombieAud.clip = zombieScream[fx];
        zombieAud.Play();
    }

    // PlayHitFX toggles a set sound effect for animation event, for use of notifying the player they took damage
    void PlayHitFX()
    {
        zombieAud.clip = zombieHit;
        zombieAud.Play();
    }
    
    void Update()
    {
        // Players the death sound and toggles off the zombies colliders upon death
        if (health.getDead())
        {
            PlayScreamFX();
            enabled = false;
            navMeshAgent.enabled = false;
            collider.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        los = CheckLOS();
        if (los || isSpawned == true || isProvoked)
        {
            if (isProvoked || isSpawned == true)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;
            }
        }
    }

    // CheckLOS checks the direction from the zombie to the player and determines if anything is inbetween the
    // two. If so, return the apropriate bool
    private bool CheckLOS()
    {
        Vector3 playerDirection = (target.transform.position - transform.position);

        RaycastHit hit;
        Physics.Raycast(transform.position, playerDirection, out hit, 100f);

        if (hit.transform.tag != "Player")
        {
            Debug.Log("DID NOT HIT PLAYER");
            return false;
        } else
        {
            Debug.Log("HIT PLAYER");
            return true;
        }
    }

    // setSpawned sets the zombie to spawned or not. If spawned it will chase the player no matter what
    public void setSpawned(bool setter)
    {
        isSpawned = setter;
    }

    // onDamageTaken sets the isProvoked bool to true
    public void onDamageTaken()
    {
        isProvoked = true;
    }

    // EngageTarget tells the zombie to attack or chase the target
    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance) 
        {
            ChaseTarget();
        }

        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    // AttackTarget is used when the zombie is in range of the player, animates an attack and deals damage
    private void AttackTarget()
    {
        animator.SetBool("attack", true);
        Debug.Log("Enemy is attacking player");
    }

    // ChaseTarget tells the zombie ai to chase downt he target
    private void ChaseTarget()
    {
        if (!chaseFXPlayed)
        {
            PlayAttackFX();
        }
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    // FaceTarget tells the zombie AI to look at the target
    // TODO: Make it look more normal. Right now just looks and runs at the target.
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    // Shows the chase range inside of the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
