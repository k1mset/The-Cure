using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Name: SceneHandler
 * Purpose: Used in the main menus to move around the scenes
 */
public class SceneHandler : MonoBehaviour
{
    /*
     * Scene Index
     * 0 - Main Menu
     * 1 - Play Game
     * 2 - How To Play
     * 3 - Credits
     * 4 - Ending
     */

    [SerializeField] GameObject musicPlayer;

    // Play button, loads the game
    public void Play()
    {
        Destroy(musicPlayer);
        if (musicPlayer == null)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Loads the how to play scene
    public void HowToPlay()
    {
        SceneManager.LoadScene(2);
    }

    // Loads the credits scene
    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    // Exits the game
    public void Quit()
    {
        Application.Quit();
    }

    // Laods the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
