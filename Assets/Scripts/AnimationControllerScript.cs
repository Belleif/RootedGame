using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AnimationControllerScript : MonoBehaviour
{
    Animator animator;
    public int fallHeight;
    private GameObject player;
    public SC_TPSController characterController;
    public bool canAnimate;
    public bool currentlyFalling;
    public bool isIdle;
    public double fallTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        canAnimate = true;
        currentlyFalling = false;
        fallTime = .6;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if character is controlling islands
        if (characterController.canMove == false)
        {
            canAnimate = false;
        } 
        else 
            canAnimate = true;


        if (canAnimate == true)
        {
            if (currentlyFalling == false)
            {
                if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) && characterController.isGrounded == true)
                {
                    animator.SetBool("IsRunning", true);
                }
                if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                {
                    animator.SetBool("IsRunning", false);
                }
                if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) && characterController.isGrounded == true)
                {
                    animator.SetBool("IsRunback", true);
                }
                if (!Input.GetKey("s") && !Input.GetKey(KeyCode.DownArrow))
                {
                    animator.SetBool("IsRunback", false);
                }
                if (characterController.isGrounded == false)
                {
                    if (fallTime > 0)
                    {
                     fallTime -= Time.deltaTime;
                    }
                    if (fallTime <= 0)
                    {
                        animator.SetBool("IsRunning", false);
                        animator.SetBool("IsFalling", true);
                        currentlyFalling = true;
                    }

                } 
                /*if (player.transform.position.y < player.transform.position.y - 5)
                {
                    if (fallTime > 0)
                    { //Setup Falltimer that counts up as soon as the falling is detected
                        fallTime -= Time.deltaTime;
                    }
                    if (fallTime <= 0)
                    {
                        animator.SetBool("IsRunning", false);
                        animator.SetBool("IsFalling", true);
                        currentlyFalling = true;
                    }

                } */


                if (Input.GetKey("space") && characterController.isGrounded == true)
                {
                    animator.SetBool("IsRunning", false);
                    //animator.SetBool("IsJumping", true);
                    animator.Play("Phoebe_Jump");
                }
                /*if (!Input.GetKey("space"))
                {
                    animator.SetBool("IsJumping", false);
                } */
                if (characterController.isGrounded == true)
                {
                    animator.enabled = false;
                    animator.enabled = true;
                }
                if (characterController.turnRight == true)
                {
                    animator.SetBool("IsRight", true);
                }
                else
                if (characterController.turnRight == false)
                {
                    animator.SetBool("IsRight", false);
                }

                if (characterController.turnLeft == true)
                {
                    animator.SetBool("IsLeft", true);
                }
                else
                if (characterController.turnLeft == false)
                {
                    animator.SetBool("IsLeft", false);

                }
            }

            if (characterController.isGrounded == true)
            {
                animator.SetBool("IsFalling", false);
                currentlyFalling = false;
                fallTime = .6;
            }
            /* if (player.transform.position.y < fallHeight)
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
            */

        }
    }
}
