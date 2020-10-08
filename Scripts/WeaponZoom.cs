using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/* Name: WeaponZoom
 * Purpose: Zoom effect used for the carbine weapon
 */
public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 30f;
    [SerializeField] float zoomedOutSens = 2f;
    [SerializeField] float zoomedInSens = 1f;

    private void onDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    // decreases camera fov
    private void ZoomOut()
    {
        playerCamera.fieldOfView = zoomedOut;
        fpsController.mouseLook.XSensitivity = zoomedOutSens;
        fpsController.mouseLook.YSensitivity = zoomedOutSens;
    }

    // Increases camera fov
    private void ZoomIn()
    {
        playerCamera.fieldOfView = zoomedIn;
        fpsController.mouseLook.XSensitivity = zoomedInSens;
        fpsController.mouseLook.YSensitivity = zoomedInSens;
    }
}
