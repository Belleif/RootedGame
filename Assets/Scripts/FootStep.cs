//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof(AudioSource))]

public class FootStep : MonoBehaviour
{
    [SerializeField]
   private AudioClip[] clips;

    private AudioSource audioSource;
        
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //animation events 
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        // int index = Random.Range(0, audioClip.Length - 1);
        // return audioClip[index];
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}