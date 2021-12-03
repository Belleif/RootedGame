using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HalmonyKill1 : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool playerActive = false;
    public bool freezePlayer = false;
    public bool interact = false;
    private bool triggeractive = false;
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
                if (freezePlayer == true)
                {
                    if (interact == false)
                    {
                        charControl.canMove = false;
                        charAnim.SetBool("IsRunning", false);
                    }
                    else if (interact == true)
                    {
                        if (other.tag == "Player")
                        {
                            triggerguiactive.SetActive(true);
                            triggeractive = true;
                            Debug.Log("Player is on Trigger.");
                        }
                    }
                }
 //               if (interact == false)
                {
                    playerActive = true;
                    StartCoroutine(PlayTimelineRoutine(timeline));
                }
              
            }
            if (interact == false)
            {
                timeline.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (interact == true)
            {
                triggerguiactive.SetActive(false);
                triggerguideactive.SetActive(false);
                triggeractive = false;
                Debug.Log("Player is off Trigger.");
            }
        }
    }
    private void Update()
    {
        if (triggeractive = true && Input.GetKeyDown("e"))
        {
            charControl.canMove = false;
            charAnim.SetBool("IsRunning", false);
            triggerguiactive.SetActive(false);
            triggerguideactive.SetActive(false);
            triggeractive = false;
            playerActive = true;
            StartCoroutine(PlayTimelineRoutine(timeline));
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
