using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTutorial : MonoBehaviour
{
    public PlayableDirector timeline;
    private bool playerOnTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnTrigger = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            timeline.Play();
        }
    }
}
