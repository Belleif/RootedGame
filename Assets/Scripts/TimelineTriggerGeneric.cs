using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTriggerGeneric : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool Interact = false;
    public bool triggeractive = false;
    public bool AttackTrigger = false;
    public GameObject triggerguiactive;
    public GameObject triggerguideactive;


    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }


    void OnTriggerExit(Collider c)
    {
        if (AttackTrigger == true)
        {
            if (c.gameObject.tag == "Player")
            {
                timeline.Stop();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeline.Play();
        }
        if (Interact == true)
        {
            if (other.tag == "Player")
            {
                triggerguiactive.SetActive(true);
                triggeractive = true;
                Debug.Log("Player is on Trigger.");
            }
        }
    }
}
