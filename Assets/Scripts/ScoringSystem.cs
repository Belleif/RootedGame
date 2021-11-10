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
		theScore += 50;
		scoreText.GetComponent<Text>().text = "SCORE:" + theScore;
		Destroy(gameObject);
	}

}
