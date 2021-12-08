using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {

	public AudioSource CollectSound;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            CollectSound.Play();
			Destroy(gameObject);
		}
	}

}
