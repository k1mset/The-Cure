using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: ObjectivePickups
 * Purpose: Handles all of the objectives in the game and what to do when the player picks them up
 */
public class ObjectivePickups : MonoBehaviour
{
    [SerializeField] Text objectiveText;
    [SerializeField] string objName;
    [SerializeField] GameObject player;
    [SerializeField] GameObject basementLights;
    [SerializeField] GameObject stairLights;
    [SerializeField] GameObject flare;
    //[SerializeField] GameObject sliderUI;
    [SerializeField] GameObject helicopter;
    [SerializeField] GameObject audioObj;
    [SerializeField] GameObject ZombieSpawner;

    CurrentObjective curObj;
    //private Slider sliderScript;
    ZombieSpawner zSpawner;

    // Start is called before the first frame update
    void Start()
    {
        curObj = player.GetComponent<CurrentObjective>();
    }

    // AudioPlayer plays a source from a game object
    void AudioPlayer()
    {
        AudioSource source = audioObj.GetComponent<AudioSource>();
        source.Play();
    }

    // Survive begins the final transition of the game. Starts spawning zombies and starts the helicopter
    void Survive()
    {
        //sliderUI.SetActive(true);
        zSpawner = ZombieSpawner.GetComponent<ZombieSpawner>();
        zSpawner.setActive();
        Animator heliAnimator = helicopter.GetComponent<Animator>();
        heliAnimator.Play("HeliFly");
        //sliderScript = sliderUI.GetComponent<Slider>();
        //StartCoroutine(sliderDisplay());
    }

    // sliderDisplay updates a visual slider on the screen for the player to know when the chopper arrives
    // Notes: Commented all of it out, some issues with trying to get it to work.
    /*
    IEnumerator sliderDisplay()
    {
        Debug.Log("Current Slider: " + sliderScript.value);
        sliderScript.value++;

        yield return new WaitForSeconds(1);

        if (sliderScript.value != 120)
        {
            StartCoroutine(sliderDisplay());
        } else
        {
            objectiveText.text = "- Get on the Helicopter";
            curObj.setComplete();
        }
    }
    */

    // Handles what todo for certain game objectives
    void OnTriggerEnter(Collider collider)
    {
        int currentObj = curObj.GetObjective();

        if (collider.CompareTag("Player"))
        {
            switch(objName)
            {
                case "Cure":
                    if (currentObj == 4)
                    {
                        objectiveText.text = "- Find a Radio";
                        curObj.UpdateObjective();
                        Destroy(gameObject);
                    }
                    break;
                case "Entrance":
                    if (currentObj == 0)
                    {
                        objectiveText.text = "- Locate Keys";
                        curObj.UpdateObjective();
                        Destroy(gameObject);
                    }
                    break;
                case "FlaregunPickup":
                    if (currentObj == 6)
                    {
                        objectiveText.text = "- Get to the Roof and Fire Flaregun";
                        curObj.UpdateObjective();
                        Destroy(gameObject);
                    }
                    break;
                case "FlaregunShot":
                    if (currentObj == 7)
                    {
                        objectiveText.text = "- Survive until Helicopter Arrives";
                        curObj.UpdateObjective();
                        flare.SetActive(true);
                        Animator flareAnim = flare.GetComponent<Animator>();
                        flareAnim.Play("FlareAnimation");
                        Survive();
                        Destroy(gameObject);
                    }
                    break;
                case "Generator":
                    if (currentObj == 2)
                    {
                        objectiveText.text = "- Override the Elevator";
                        curObj.SetLights(true);
                        curObj.UpdateObjective();
                        basementLights.SetActive(true);
                        stairLights.SetActive(true);
                        AudioPlayer();
                        Destroy(gameObject);
                    }
                    break;
                case "Keys":
                    if (currentObj == 1)
                    {
                        objectiveText.text = "- Turn on the Generator";
                        AudioPlayer();
                        curObj.UpdateObjective();
                        Destroy(gameObject);
                    }
                    break;
                case "RadioPickup":
                    if (currentObj == 5)
                    {
                        objectiveText.text = "- Find a Flare Gun";
                        curObj.UpdateObjective();
                        Destroy(gameObject);
                    }
                    break;
                case "SecurityRoom":
                    if (currentObj == 3)
                    {
                        objectiveText.text = "- Get the Cure from the Lab";
                        AudioPlayer();
                        curObj.UpdateObjective();
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }
}
