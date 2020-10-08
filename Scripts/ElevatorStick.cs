using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: ElevatorStick
 * Purpose: Childs the player to the elevator to ensure smooth movement with the elevator
 * KNOWN BUGS: For some reason the player faces a random direction when stepping into/out of the collider
 */
public class ElevatorStick : MonoBehaviour
{
    public GameObject player;
    public GameObject elevator;

    private Vector3 playerScale;

    // When the player enters the trigger, child the player to the elevator object
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {
            player.transform.parent = elevator.transform;
        }
    }

    // When the player leaves the trigger, unchild the player from the elevator object
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
