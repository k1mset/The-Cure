using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: Ammo
 * Purpose: Handles the various different ammos for the player character, and keeps track of the stock
 */
public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmt;
    }

    // getCurrentAmmo takes in a ammotype and returns the ammount the player has
    public int getCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmt;
    }

    // reduceCurrentAmmo takes in the ammoType and removes 1 from the player
    public void reduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmt--;
    }

    // reduceCurrentAmmoAmt takes in the ammoType and an integer, reduces the players ammo by that amount
    public void reduceCurrentAmmoAmt(AmmoType ammoType, int amt)
    {
        GetAmmoSlot(ammoType).ammoAmt -= amt;
    }

    // emptyCurrentAmmo takes in an ammoType and sets the ammount the player has to 0
    public void emptyCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmt = 0;
    }

    // addCurrentAmmo takes in an ammoType and amount, then adds that much ammo to the player
    public void addCurrentAmmo(AmmoType ammoType, int ammoAmt)
    {
        GetAmmoSlot(ammoType).ammoAmt += ammoAmt;
    }

    // GetAmmoSlot returns that ammo type's slot
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
