using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Name: SceneLoader
 * Purpose: Used to quit/reboot the game. Only used for when the player dies
 */
public class SceneLoader : MonoBehaviour
{
    // Restart the game
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    // Exit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
