using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{

    public float health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Island")
        {
            //Set Bool of boss sees player to true and use it in boss movement to make the boss face player
            //Place this in detection script for playerSeen specifically and in this script check bool playerSeen
            Destroy(other.gameObject);

            Debug.Log("Boss took damage");
        }
    }

}
