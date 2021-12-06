using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineSkip : MonoBehaviour
{
    private PlayableDirector _currentDirector;
    private bool _sceneSkipped = true;
    private float _timeToSkipTo;
    public void GetDirector(PlayableDirector director)
    {
        _sceneSkipped = false;
        _currentDirector = director;
    }

    public void GetSkipTime(float skipTime)
    {
        _timeToSkipTo = skipTime;
    }

//    private void Awake()
//    {
//        _instance = this;
//    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_sceneSkipped)
        {
            _currentDirector.time = _timeToSkipTo;
            _sceneSkipped = true;
        }
    }
}
