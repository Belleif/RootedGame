using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//////
/*
 * This script allows for the movement of a character with a Character Controller
 * along with the camera being moved along with the character.
 * 
 * REQUIREMENTS:
 *              - game object with a Character Controller for the character
 *              - a camera that can follow the character so it can be controlled
 * How to use:
 *              - Create a character and set the front.
 *              - Ensure that the character has a Character Controller.
 *              - Have a CameraParent empty that contains the cameras that will be used for the character.
 *              - Place the CameraParent in the Transform variable.
 *               (Make sure that you have a camera. A Cinemachine camera is also compatible with this.)
 * 
 */
//////

//This script will only work if a Character Controller is present.
[RequireComponent(typeof(CharacterController))]

public class SC_TPSController : MonoBehaviour
{
    //Public variables that control the speed and movement of the Character.
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public static float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    private float vSpeed = 0f;
    public bool turnRight;
    public bool turnLeft;

    public float GroundDistance = 0.2f;
    public LayerMask Ground;
    public bool isGrounded = true;
    private Transform groundChecker;

    //Variables set for the Character Controller and its direction and rotation.
    public static CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;
    Vector3 dwn;



    //Boolean that is meant to say if the character can move or not move.
    public bool canMove = true;

    public Transform followTrans;

    //Function meant to initialize anything below on start of the program.
    void Start()
    {
        groundChecker = transform.GetChild(0);
        dwn = transform.TransformDirection(Vector3.down);
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        turnRight = false;
        turnLeft = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        bool hit = Physics.Raycast(transform.position, dwn, 10);

        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            vSpeed = 0;

            if (Input.GetButton("Jump") && canMove)
            {
                vSpeed = jumpSpeed;

            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        vSpeed -= gravity * Time.deltaTime;
        moveDirection.y = vSpeed;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);


        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
            ////////
            ///THIS IS THE NEW STUFF FOR ROTATION!
            float mouse = Input.GetAxis("Mouse Y");
            followTrans.transform.Rotate(new Vector3(-mouse, 0, 0));
        }

       /* if (GetComponent<ThirdPersonCamera>().m_XAxis < 0)
        {
            turnRight = true;
        }
        else
        if (GetComponent<ThirdPersonCamera>().m_XAxis > 0)
        {
            turnLeft = true;
        }
        
        if (GetComponent<ThirdPersonCamera>().m_XAxis == 0)
        {
            turnRight = false;
            turnLeft = false;
        } */

    }

 

}