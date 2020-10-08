using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Name: EndGame
 * Purpose: Handles the fadeing in and out of black screens
 */
public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject image;

    private Animator imgFade;

    // Start is called before the first frame update
    void Start()
    {
        if (image != null)
        {
            imgFade = image.GetComponent<Animator>();
        }
    }

    // FadeIn runs fade in animation (black to visable)
    void FadeIn()
    {
        Debug.Log("Start fade");
        imgFade.Play("FadeIn");
    }

    // FadeOut runs the fade out animation (visable to balck)
    void FadeOut()
    {
        Debug.Log("Start fade");
        imgFade.Play("FadeOut");
    }

    // ReturnToMainMenu returns the game to the main menu
    void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Used for the final game event, if the isFin objective true then loads the EndGame scene.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            CurrentObjective currObj = collider.GetComponent<CurrentObjective>();

            bool isFin = currObj.getComplete();

            if (isFin == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(4);
            }
        }
    }
}
