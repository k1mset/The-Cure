using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: FlashLightSystem
 * Purpose: Handles the players flashlight
 */
public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] Image flashLightImage;

    private Light flashLight;
    private bool lightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle control to enable/disable the players flashlight
        if (Input.GetKeyDown(KeyCode.F)) {
            if (lightOn)
            {
                flashLight.enabled = false;
                lightOn = false;
            } else
            {
                flashLight.enabled = true;
                lightOn = true;
                }
        }

        // Begins decaying the light the flashlight puts out
        if ((lightOn) && (flashLight.enabled = true))
        {
            DecreaseLightIntesity();
        }

        UpdateUI();
    }

    // UpdateUI constantly updates the players flashlight ui
    private void UpdateUI()
    {
        float currInt = flashLight.intensity / 8;
        flashLightImage.fillAmount = currInt;
    }

    // RestoreFlashlight used in the battery pickup, restores the players flashlight to max.
    public void RestoreFlashlight() {
        flashLight.intensity = 8f;
    }

    // DecreaseLightIntensity slowly degrades the players flashlight during use
    private void DecreaseLightIntesity()
    {
        flashLight.intensity -= lightDecay * Time.deltaTime;
    }
}
