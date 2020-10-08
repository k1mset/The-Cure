using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: MusicPlayer
 * Purpose: Handles the menu music at the start of the game
 */
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer _instance;

    // Makes the music player an instance and ensures it stays during scene transition in the menus
    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Reenables the mouse, for when the game goes from ending to main menu
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Used to kill the music player
    void KillObject()
    {
        Destroy(this.gameObject);
    }
}
