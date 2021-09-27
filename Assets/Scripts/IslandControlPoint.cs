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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is on Trigger.");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown("r"))
            {
                triggeractive = true;
                Debug.Log("Player has activated Trigger.");
                characterController.canMove = false;
                IslandMovement.islandMove = 1;
                if (CamMode == 1)
                {
                    CamMode = 0;
                }
                else
                {
                    CamMode += 1;
                }
                StartCoroutine(CamChange());
                //CameraControl.MainCamera.SetActive(false);
                //CameraControl.IslandCamera.SetActive(true);

            }
            else if (Input.GetKeyDown("f") && triggeractive == true)
            {
                triggeractive = false;
                Debug.Log("Player has deactivated Trigger.");
                characterController.canMove = true;
                IslandMovement.islandMove = 0;
                if (CamMode == 1)
                {
                    CamMode = 0;
                }
                else
                {
                    CamMode += 1;
                }
                //CameraControl.MainCamera.SetActive(true);
                //CameraControl.IslandCamera.SetActive(false);
            }
        }


        //CameraControl.CameraSwitch();
        //cameras.GetComponent<CameraControl>().CameraSwitch();
        //CameraControl.cameras[0].gameObject.SetActive(false);
        //CameraControl.cameras[1].gameObject.SetActive(true);
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);

        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
        }
    }
}
