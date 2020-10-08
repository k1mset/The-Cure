using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: Weapon
 * Purpose: All of the components used for each weapon. Firing, reloading, sounds, ammo, etc.
 */
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 70f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactSparks;
    [SerializeField] int ammoInMag;
    [SerializeField] int magSize;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] float timeForReload = 2f;
    [SerializeField] Text ammoText;
    [SerializeField] AudioClip weaponShootFX;
    [SerializeField] AudioClip weaponDryFireFX;
    [SerializeField] AudioClip weaponReloadFX;
    
    private AudioSource weaponAudio;
    private Animator animator;
    private bool canShoot = true;
    private bool reloading = false;
    private int remainAmmo;
    private int reqAmmo;

    // onEnable sets canShoot and reloading bools
    private void onEnable()
    {
        canShoot = true;
        reloading = false;
    }

    // getShoot returns the canShoot bool
    public bool getShoot()
    {
        return canShoot;
    }

    // getReloading returns the reloading bool
    public bool getReloading()
    {
        return reloading;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        weaponAudio = GetComponent<AudioSource>();
    }

    // WeaponReloadSound plays the weapon reloading sound effect
    void WeaponReloadSound()
    {
        weaponAudio.clip = weaponReloadFX;
        weaponAudio.Play();
    }

    // WeaponDryFireSound plays the weapon dry firing sound effect
    void WeaponDryFireSound()
    {
        weaponAudio.clip = weaponDryFireFX;
        weaponAudio.Play();
    }

    // WeaponFireSound plays the weapon firing sound effect
    void WeaponFireSound()
    {
        weaponAudio.clip = weaponShootFX;
        weaponAudio.Play();
    }

    void Update()
    {
        DisplayAmmo();

        // Shoots the weapon
        if ((Input.GetMouseButton(0)) && (canShoot) && (!reloading))
        {
            StartCoroutine(Shoot());
        }

        // Relods the weapon
        if (Input.GetKeyDown(KeyCode.R) && (!reloading))
        {
            remainAmmo = ammoSlot.getCurrentAmmo(ammoType);

            if ((ammoInMag < magSize) && (remainAmmo > 0))
            {
                StartCoroutine(Reload());
            }

        }
    }

    // DisplayAmmo is used by the UI to show the ammo in the mag and how much ammo the player has total
    private void DisplayAmmo()
    {
        ammoText.text = ammoInMag + "/" + ammoSlot.getCurrentAmmo(ammoType);
    }

    // Reload ienum used for the entire weapon reloading sequence
    // Notes: More realistic, if ammo is left in the clip that ammo is lost. Not a common feature in shooter
    // games.
    IEnumerator Reload()
    {
        reloading = true;

        reqAmmo = magSize - ammoInMag;
        animator.Play("Reload");

        yield return new WaitForSeconds(timeForReload);
        animator.Play("Idle");
        if (reqAmmo <= remainAmmo)
        {
            ammoInMag = magSize;
            ammoSlot.reduceCurrentAmmoAmt(ammoType, magSize);
        }
        else
        {
            ammoInMag = ammoSlot.getCurrentAmmo(ammoType);
            ammoSlot.emptyCurrentAmmo(ammoType);
        }
        reloading = false;
    }

    // Shoot ienum handles the weapon firing
    IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoInMag > 0)
        {
            PlayMuzzleFlash();

            try
            {
                calculateShot();
            }
            catch (NullReferenceException e)
            {
                Debug.Log("Nothing hit");
            }

            WeaponFireSound();

            ammoInMag--;
        } else
        {
            WeaponDryFireSound();
        }
        /*
        if (ammoSlot.getCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();

            try
            {
                calculateShot();
            }
            catch (NullReferenceException e)
            {
                Debug.Log("Nothing hit");
            }

            ammoSlot.reduceCurrentAmmo(ammoType);
        }
        */

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    // PlayMuzzleFlash plays the muzzle flashing effect
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    // calculateShot creates a raycast from the camera straight out on the first target hit
    private void calculateShot()
    {
        RaycastHit hit;
        Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range);

        Debug.Log("Shot : " + hit.transform.name);

        CreateImpactFX(hit);
        
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        target.takeDamage(weaponDamage);
    }

    // CreateImpactFX creates a small effect on impact of the ray
    private void CreateImpactFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(impactSparks, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
