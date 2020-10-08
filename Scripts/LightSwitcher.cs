using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: LightSwitcher
 * Purpose: Script to get the status of lights from the player and then toggle various lights around the scene.
 * Notes: This was for optimization, and this is a HORRIBLE way to do it. I need to find a better way to optimize.
 */
public class LightSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] lights;
    [SerializeField] bool requireGenerator = true;

    private CurrentObjective objLights;
    private bool areLightsOn;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            objLights = collider.GetComponent<CurrentObjective>();

            areLightsOn = objLights.GetLights();

            if (requireGenerator)
            {
                if (areLightsOn)
                {
                    if (lights != null || lights.Length > 0)
                    {
                        for (int i = 0; i < lights.Length; i++)
                        {
                            lights[i].SetActive(!lights[i].activeSelf);
                        }
                    }
                }
            } else
            {
                if (lights != null || lights.Length > 0)
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(!lights[i].activeSelf);
                    }
                }
            }
        }
    }
}
