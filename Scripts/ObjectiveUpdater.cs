using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: ObjectiveUpdater
 * Purpose:  Used for deleting game objects when an objective is picked up. Used for elevator doors and other
 * game blockages.
 */
public class ObjectiveUpdater : MonoBehaviour
{
    [SerializeField] GameObject[] destroyedObjects;

    void OnTriggerEnter(Collider collider)
    {
        for (int i=0; i<destroyedObjects.Length; i++)
        {
            Destroy(destroyedObjects[i]);
        }
    }
}
