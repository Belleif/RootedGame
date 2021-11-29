using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {

    public GameObject scoreText;
	public int theScore;
	public AudioSource CollectSound;
	
	void OnTriggerEnter(Collider other)
	{
		CollectSound.Play();
		Destroy(gameObject);
	}

}
