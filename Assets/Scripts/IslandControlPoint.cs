using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandControlPoint : MonoBehaviour
{
    public float[] islands;
    private int currentIslandIndex;
    public SC_TPSController characterController;
    public Animator charAnim;
    public MouseClicker rayClick;
    public EmissionGlow emissionGlow;
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public GameObject pauseMenuUI;
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
        if (triggeractive == true && pauseMenuUI.activeSelf == false)
        {
            if (Input.GetKeyDown("e") && ThirdCam.activeSelf)
            {
                triggerguiactive.SetActive(false);
                triggerguideactive.SetActive(false);
                Debug.Log("Player has activated Trigger.");
                characterController.canMove = false;
                charAnim.SetBool("IsRunning", false);
                IslandMovement.islandMove = 1;
                curseChange.theHandCursor();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                ThirdCam.SetActive(false);
                FirstCam.SetActive(true);
                emissionGlow.glowStart = true;
            }
            else if (Input.GetKeyDown("e") && FirstCam.activeSelf)
            {
                triggerguiactive.SetActive(false);
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
                emissionGlow.glowStart = false;
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
            if (ThirdCam.activeSelf)
            {
                triggerguiactive.SetActive(false);
                triggerguideactive.SetActive(false);
                triggeractive = false;
                Debug.Log("Player is off Trigger.");
            }
        }
    }
}
