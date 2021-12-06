using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    public bool playerDead = false;
    //public Transform target;
    

    // Start is called before the first frame update
    void Start()
    {
       // target = respawn.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            playerDead = true;
            Debug.Log(playerDead);
            
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().transform.position = respawn.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            

        }
    }
}
