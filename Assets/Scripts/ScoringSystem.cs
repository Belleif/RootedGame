using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {

    public GameObject scoreText;
	public static int theScore = 0;
	public AudioSource CollectSound;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			CollectSound.Play();
			theScore++;
			scoreText.GetComponent<Text>().text = theScore.ToString();
			Debug.Log(theScore);
			Destroy(gameObject);
		}
	}

}
