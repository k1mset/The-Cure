using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: AmmoPickup
 * Purpose: Used for item pickups that increase the players ammunition for certain weapons
 */
public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    [SerializeField] AmmoType ammoType;

    private AudioSource pickupSfx;

    // Start is called before the first frame update
    void Start()
    {
        pickupSfx = GetComponentInParent<AudioSource>();
    }

    // When the player enters the collider, adds the ammount to the players inventory, plays a sound then destroys itself
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Picked up ammo!");
            FindObjectOfType<Ammo>().addCurrentAmmo(ammoType, ammoAmount);
            pickupSfx.Play();
            Destroy(gameObject);
        }
    }
}
