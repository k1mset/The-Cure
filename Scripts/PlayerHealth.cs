using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: PlayerHealth
 * Purpose: Maintains the players health and adjusts when needed.
 */
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] Text healthUI;

    private DisplayDamage displayDmg;

    void Start()
    {
        displayDmg = gameObject.GetComponent<DisplayDamage>();
    }

    // takeDamage method takes in a float and deals that much to the players total health.
    public void takeDamage(float damage)
    {
        this.hitPoints -= damage;
        Debug.Log("You take " + damage + " damage.");

        displayDmg.ShowDamage();
        updateHealthUI();

        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().EnableCanvas();
        }
    }

    // getHealth returns the players health
    public float getHealth()
    {
        return hitPoints;
    }

    // updateHealthUI updates the text of the health being displayed to the player
    void updateHealthUI()
    {
        healthUI.text = hitPoints.ToString();
    }
}
