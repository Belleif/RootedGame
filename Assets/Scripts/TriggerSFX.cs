using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    
	public AudioSource playSound;
	
	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
        {
            playSound.Play();
        }
	}
}
