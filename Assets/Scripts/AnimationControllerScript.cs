using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("IsRunning", true);
        }
        if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey("space"))
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", true);
            
        }
        if (!Input.GetKey("space"))
        {
            animator.SetBool("IsJumping", false);
        }
        if (player.transform.position.y < 30)
            animator.SetBool("IsFalling", true);
        else
            animator.SetBool("IsFalling", false);
        //Fix to utilize isGrounded method
    }
}
