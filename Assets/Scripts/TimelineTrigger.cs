using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool playerActive = false;
    public Animator charAnim;
    public AnimationControllerScript charAnimScript;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeline.Play();
        }
        if (other.tag == "Player")
        {
            if (playerActive == false)
            {
                charAnim.SetBool("IsRunning", false);
                playerActive = true;
            }

        }
        
    }
}
