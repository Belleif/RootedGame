using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool playerActive = false;
    public bool FreezePlayer = false;
    public bool Interact = false;
    public bool triggeractive = false;
    public GameObject triggerguiactive;
    public GameObject triggerguideactive;
    //public bool ExitTimeline = false;
    public Animator charAnim;
    public AnimationControllerScript charAnimScript;
    public SC_TPSController charControl;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerActive == false)
            {
                if (FreezePlayer == true)
                {
                    charControl.canMove = false;
                    charAnim.SetBool("IsRunning", false);
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
                playerActive = true;
                StartCoroutine(PlayTimelineRoutine(timeline));
            }
        }
        if (other.gameObject.tag == "Player")
        {
            timeline.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Interact == true)
            {
                triggerguiactive.SetActive(false);
                triggerguideactive.SetActive(false);
                triggeractive = false;
                Debug.Log("Player is off Trigger.");
            }
        }
    }

    private IEnumerator PlayTimelineRoutine(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        Debug.Log("Timeline is playing");
        float timelineDuration = (float)timeline.duration;
        yield return new WaitForSeconds(timelineDuration);
        Debug.Log("Director is Done.");
        charControl.canMove = true;
        Debug.Log("{Player can move.");
    }
}
