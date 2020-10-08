using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: EnemyHealth
 * Purpose: Handles the zombies health and taking damage
 */
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    private bool isDead = false;

    // create public method which reduces hitpoints by the amt of dmg
    public void takeDamage(float damage)
    {
        this.hitPoints -= damage;

        GetComponent<EnemyAI>().onDamageTaken();

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    // getDead returns the dead/not dead status of the zombie
    public bool getDead()
    {
        return isDead;
    }

    // Die animation event for setting the zombie to dead
    private void Die()
    {
        if (isDead)
        {
            return;
        }

        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }
}
