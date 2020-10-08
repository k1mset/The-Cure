using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: BatteryPickup
 * Purpose: Used for the pickup of the Battery item
 */
public class BatteryPickup : MonoBehaviour
{
    private FlashLightSystem flashLight;

    // Called when the player runs into the object, takes their flashlight system and runs the restoreflashlight method, then deletes itself
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            flashLight = collider.GetComponentInChildren<FlashLightSystem>();
            flashLight.RestoreFlashlight();
            Destroy(gameObject);
        }
    }
}
