using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    public Transform player;
    public float health;
    public bool playerSeen;
    public bool attackPlayer;
    public Transform target;
    GameObject playerDetect = new GameObject();

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States

    void Start()
    {
        playerSeen = false;
    }

    private void Update()
    {
        if (!playerSeen && !attackPlayer) 
            Idle();
        if (playerSeen && !attackPlayer)
            FollowPlayer();
        if (playerSeen && attackPlayer)
            AttackPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Set Bool of boss sees player to true and use it in boss movement to make the boss face player
            //Place this in detection script for playerSeen specifically and in this script check bool playerSeen
            playerSeen = true;
        }
    }
    

    private void Idle()
    {
        //Set Animation Controller in here for possible Idle stance
    }



    private void FollowPlayer()
    {
        //Once player is in range this method makes it so the boss faces towards them
        if(playerSeen == true)
        {
            transform.LookAt(target);
            Debug.Log("Boss sees Player.");
        }
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked)
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
    //Handles Boss Damage and Boss Defeat
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //Input Animation, Cutscene, whatever signals that the boss has been defeated.

            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
/* This script should handle boss' AI pathfinding
 * Need to make sure to link boss damage and islands being used to damage the boss*/

