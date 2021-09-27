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

    void Update()
    {
        if (triggeractive == true)
        {
            if (Input.GetKeyDown("r"))
            {
                triggeractive = true;
                Debug.Log("Player has activated Trigger.");
                characterController.canMove = false;
                IslandMovement.islandMove = 1;
                ThirdCam.SetActive(false);
                FirstCam.SetActive(true);

            }
            else if (Input.GetKeyDown("f") && triggeractive == true)
            {
                triggeractive = false;
                Debug.Log("Player has deactivated Trigger.");
                characterController.canMove = true;
                IslandMovement.islandMove = 0;
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeractive = true;
            Debug.Log("Player is on Trigger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeractive = false;
            Debug.Log("Player is on Trigger.");
        }
    }
}
