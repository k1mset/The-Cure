using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: ElevatorUse
 * Purpose: Handles when the elevator can be used, and toggles lab lights
 */
public class ElevatorUse : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject firstFloorLights;
    [SerializeField] GameObject labLights;
    
    private int currentObjective;
    private bool isDown = false;
    private CurrentObjective curObj;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
    }

    // Ensures the object entering the collider is the player, checks the players current objective and handles
    // outcome
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            curObj = collider.GetComponent<CurrentObjective>();

            currentObjective = curObj.GetObjective();
            Debug.Log("Current Obj:" + currentObjective);
            
            if ((currentObjective == 4) && (isDown == false))
            {
                animator.speed = 0.2f;
                animator.Play("EleDown");
                Debug.Log("Elevator going down");
                labLights.SetActive(true);
                firstFloorLights.SetActive(false);
                isDown = true;
            } else if ((currentObjective == 5) && (isDown == true))
            {
                animator.speed = 0.2f;
                animator.Play("EleUp");
                Debug.Log("Elevator going up");
                labLights.SetActive(false);
                firstFloorLights.SetActive(true);
            }
        }
    }
}
