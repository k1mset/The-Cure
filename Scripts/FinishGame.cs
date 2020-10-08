using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: FinishGame
 * Purpose: Used for the ingame ending cinematic
 * Notes: This was scrapped
 */
public class FinishGame : MonoBehaviour
{

    [SerializeField] GameObject[] gameUI;
    [SerializeField] GameObject[] interiorLights;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject player;
    [SerializeField] GameObject endCam;

    private CurrentObjective curObj;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) {
            curObj = collider.GetComponent<CurrentObjective>();

            if (curObj.getComplete())
            {
                for (int i =0; i<gameUI.Length; i++)
                {
                    gameUI[i].SetActive(false);
                }

                for (int j = 0; j<interiorLights.Length; j++)
                {
                    Destroy(interiorLights[j]);
                }

                Destroy(enemies);
                Destroy(player);
                endCam.SetActive(true);
            }
        }
    }
}
