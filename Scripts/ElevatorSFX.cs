using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: ElevatorSFX
 * Purpose: Adds animation events for the elevator to play/stop elevator sound effects.
 */
public class ElevatorSFX : MonoBehaviour
{
    private AudioSource eleSrc;

    // Start is called before the first frame update
    void Start()
    {
        eleSrc = GetComponent<AudioSource>();
    }
    
    // PlaySFX plays the elevator sound effect
    public void PlaySFX()
    {
        eleSrc.Play();
    }

    // StopSFX stops the elevator sound effect
    public void StopSFX()
    {
        eleSrc.Stop();
    }
}
