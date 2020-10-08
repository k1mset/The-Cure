using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: WeaponSwitch
 * Purpose: Handles swapping the players weapons
 */
public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] Text weaponName;

    private Weapon weaponStatus;
    private bool reloading;
    private bool shooting;

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();
        ProcessWeaponSwitch(previousWeapon);
    }

    // ProcessWeaponSwitch sets whichever weapon active and renames the text in the ui
    private void ProcessWeaponSwitch(int previousWeapon)
    {
        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }

        if (currentWeapon == 0)
        {
            weaponName.text = "M4 Carbine";
        }

        if (currentWeapon == 1)
        {
            weaponName.text = "Handgun";
        }
    }

    // Used for when the player presses the 1 or 2 key, to swap to that weapon
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponStatus = GetComponentInChildren<Weapon>();
            shooting = weaponStatus.getShoot();
            reloading = weaponStatus.getReloading();

            if (!shooting || !reloading)
            {
                currentWeapon = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponStatus = GetComponentInChildren<Weapon>();
            shooting = weaponStatus.getShoot();
            reloading = weaponStatus.getReloading();

            if (!shooting || !reloading)
            {
                currentWeapon = 1;
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        */
    }

    // Used for when the player uses the scrool wheel to switch weapons
    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponStatus = GetComponentInChildren<Weapon>();
            shooting = weaponStatus.getShoot();
            reloading = weaponStatus.getReloading();

            if (!shooting || !reloading)
            {

                if (currentWeapon >= transform.childCount - 1)
                {
                    currentWeapon = 0;
                }
                else
                {
                    currentWeapon++;
                }
            }
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponStatus = GetComponentInChildren<Weapon>();
            shooting = weaponStatus.getShoot();
            reloading = weaponStatus.getReloading();

            if (!shooting || !reloading)
            {

                if (currentWeapon <= 0)
                {
                    currentWeapon = transform.childCount - 1;
                }
                else
                {
                    currentWeapon--;
                }
            }
        }


    }

    void Start()
    {
        SetWeaponActive();
    }

    // Used to set the weapon active
    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            } else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }
}
