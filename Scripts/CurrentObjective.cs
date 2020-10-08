using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: CurrentObjective
 * Purpose: Handles the players current objective integer. Also allows the game to toggle if the generator is active
 * and if the game is completed.
 */
public class CurrentObjective : MonoBehaviour
{
    private int currentObjective = 0;
    private bool lightsOn = false;
    private bool gameComplete = false;

    // UpdateObjective increases the current objective by 1
    public void UpdateObjective()
    {
        currentObjective++;
    }

    // GetObjective returns the current objeective
    public int GetObjective()
    {
        return currentObjective;
    }

    // GetLights returns the bool of getlights, used for switching lights on and off (poor way to optimize)
    public bool GetLights()
    {
        return lightsOn;
    }

    // SetLights takes in a status bool and adjusts the players ability to toggle light switch triggers
    public void SetLights(bool status)
    {
        lightsOn = status;
    }

    // setComplete sets the game mode to complete
    public void setComplete()
    {
        gameComplete = true;
    }

    // getComplete checks if gameComplete is true or not
    public bool getComplete()
    {
        return gameComplete;
    }
}
