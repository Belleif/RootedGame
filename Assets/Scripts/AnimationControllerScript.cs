using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    Animator animator;
    public int fallHeight;
    private GameObject player;
    public SC_TPSController characterController;
    public bool canAnimate;
    public bool currentlyFalling;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        canAnimate = true;
        currentlyFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if character is controlling islands
        if (characterController.canMove == false)
            canAnimate = false;
        else 
            canAnimate = true;


        if (canAnimate == true)
        {
            if (currentlyFalling == false)
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
            }
            if (player.transform.position.y < fallHeight)
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsFalling", true);
                currentlyFalling = true;
            }
            else
            {
                animator.SetBool("IsFalling", false);
                currentlyFalling = false;
            }

        }
        //Fix to utilize isGrounded method
    }
}
