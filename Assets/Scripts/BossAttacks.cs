using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{

    public bool alreadyAttacked;
    public bool attackPlayer;
    public float timeBetweenAttacks = 3;

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
        if (other.tag == "Player")
        {
            //Set Bool of boss sees player to true and use it in boss movement to make the boss face player
            //Place this in detection script for playerSeen specifically and in this script check bool playerSeen
            attackPlayer = true;
            Debug.Log("Attacking Player");
        }
    }

    private void AttackPlayer()
    {
        if (attackPlayer && !alreadyAttacked)
        {
            //Boss Attack Code Here

            Debug.Log("Boss Attacked");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


}
