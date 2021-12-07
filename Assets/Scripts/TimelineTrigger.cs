using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool playerActive = false;
    private bool FreezePlayer = false;
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
                }
                playerActive = true;
                StartCoroutine(PlayTimelineRoutine(timeline));
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