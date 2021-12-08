using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    private PlayableDirector currentDirector;
    private GameObject controlPanel;
    public void GetDirector(PlayableDirector director)
    {
        currentDirector = director;
    }

private void Awake()
    {
        currentDirector = GetComponent<PlayableDirector>();
        currentDirector.played += Director_Played;
        currentDirector.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }

    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }

    public void StartTimeline()
    {
        currentDirector.Play();
    }
    public void StopTimeline()
    {
        currentDirector.Stop();
    }
}
