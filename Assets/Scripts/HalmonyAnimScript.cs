using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HalmonyAnimScript : MonoBehaviour
{
    Animator animator;
    public BossMovement bossMove;
    public BossAttacks bossAttack;
    private GameObject taurry;

    //public BossMovement 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //halmony = GameObject.Find("Halmony");
    }

    // Update is called once per frame
    void Update()
    {
        if (bossMove.playerSeen == true)
        {
            animator.SetBool("isStruggling", true);
        }
        else
        {
            animator.SetBool("isStruggling", false);
        }
    }

}
