using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {

    public GameObject scoreText;
	public static int theScore;
	public AudioSource CollectSound;
	
	void OnTriggerEnter(Collider other)
	{
		CollectSound.Play();
		scoreText.GetComponent<Text>().text = "1" +theScore;
		Destroy(gameObject);
		theScore++;
		Debug.Log(theScore);
	}

}
