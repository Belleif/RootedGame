using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSFX : MonoBehaviour
{
    
	public AudioSource playSound;
	
	void OnCollisionEnter3D(Collider other)
	{
		playSound.Play();
	}
}
