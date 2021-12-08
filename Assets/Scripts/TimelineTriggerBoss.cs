using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTriggerBoss : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool triggeractive = false;
    public bool AttackTrigger = false;
    public GameObject player;



    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }


    void OnTriggerExit(Collider other)
    {
        if (AttackTrigger == true)
        {
            if (other.gameObject.tag == "Player")
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
    }
}
