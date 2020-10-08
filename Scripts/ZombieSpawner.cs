using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: ZombieSpawner
 * Purpose: Gameobject that spawns zombies for the final act of the game
 */
public class ZombieSpawner : MonoBehaviour
{
    public bool isActive = false;
    public GameObject zombieObj;

    private GameObject spawned;
    private EnemyAI spawnedAI;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            SpawnZombies();
        }
    }

    // SpawnZombies being ienum to spawn zombies
    private void SpawnZombies()
    {
        isActive = false;
        StartCoroutine(ZSpawner());
    }

    // ZSpawner spawns 3 zombies that charge the player every 25 seconds
    IEnumerator ZSpawner()
    {
        yield return new WaitForSeconds(17);

        for (int i = 0; i < 3; i++)
        {
            spawned = Instantiate(zombieObj, transform.parent);
            spawnedAI = spawned.GetComponent<EnemyAI>();
            spawnedAI.setSpawned(true);
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(ZSpawner());        
    }

    public void setActive()
    {
        isActive = true;
    }

    public bool checkActive()
    {
        return isActive;
    }
}
