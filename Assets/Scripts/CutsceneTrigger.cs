using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject cutsceneCamera;
    public GameObject player;

    public void Start()
    {
        cutsceneCamera.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Need help implementing cinemachine and also what the cutscene will entail
        if (other.tag == "Player")
        {
            cutsceneCamera.SetActive(true);
            player.SetActive(false);
        }
    }

}
