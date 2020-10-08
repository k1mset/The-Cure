using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name:
 * Purpose:
 */
public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    // Ensures the game over canvas is not displayed at launch
    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // EnableCanvas turns the canvas back on and pauses the game.
    public void EnableCanvas()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
