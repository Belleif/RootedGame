using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandControlPoint : MonoBehaviour
{
    public float[] islands;
    private int currentIslandIndex;
    public SC_TPSController characterController;
    public MouseClicker rayClick;

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;
    public bool triggeractive = false;
    public GameObject triggerguiactive;
    public GameObject triggerguideactive;
    public ParticleSystem particles;
    public ParticleSystem particlesGlow;
    public CursorChanger curseChange;

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
                characterController.canMove = false;
                IslandMovement.islandMove = 1;
                curseChange.theHandCursor();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                ThirdCam.SetActive(false);
                FirstCam.SetActive(true);

            }
            else if (Input.GetKeyDown("e") && FirstCam.activeSelf)
            {
                triggerguiactive.SetActive(true);
                triggerguideactive.SetActive(false);
                Debug.Log("Player has deactivated Trigger.");
                characterController.canMove = true;
                rayClick.currentIsle.GetComponent<Rigidbody>().isKinematic = true;
                rayClick.currentIsle.GetComponent<IslandMovement>().isMoving = false;
                IslandMovement.islandMove = 0;
                curseChange.theArrowCursor();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
                particles.Stop();
                particlesGlow.Stop();
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
