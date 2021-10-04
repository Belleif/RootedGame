using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandControlPoint : MonoBehaviour
{
    public float[] islands;
    private int currentIslandIndex;
    public SC_TPSController characterController;

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;
    private bool triggeractive = false;
    public GameObject triggerguiactive;
    public GameObject triggerguideactive;

    void Start()
    {
        triggerguiactive.SetActive(false);
        triggerguideactive.SetActive(false);
    }

    void Update()
    {
        if (triggeractive == true)
        {
            if (Input.GetKeyDown("e") && ThirdCam.activeSelf)
            {
                triggerguiactive.SetActive(false);
                triggerguideactive.SetActive(true);
                Debug.Log("Player has activated Trigger.");
                characterController.speed = 0.0f;
                characterController.jumpSpeed = 0.0f;
                IslandMovement.islandMove = 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
                ThirdCam.SetActive(false);
                FirstCam.SetActive(true);

            }
            else if (Input.GetKeyDown("e") && FirstCam.activeSelf)
            {
                triggerguiactive.SetActive(true);
                triggerguideactive.SetActive(false);
                Debug.Log("Player has deactivated Trigger.");
                characterController.speed = 15f;
                characterController.jumpSpeed = 15f;
                IslandMovement.islandMove = 0;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerguiactive.SetActive(true);
            triggeractive = true;
            Debug.Log("Player is on Trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerguiactive.SetActive(false);
            triggerguideactive.SetActive(false);
            triggeractive = false;
            Debug.Log("Player is on Trigger.");
        }
    }
}
