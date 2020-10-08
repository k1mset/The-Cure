using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: EnemyAttack
 * Purpose: Used for dealing damage to the player
 */
public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    // AttackHitEvent used by animation events to deal damage
    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }

        Debug.Log("BOOP!");
        target.takeDamage(40f);
    }
}
