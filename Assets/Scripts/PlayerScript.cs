using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float Speed = 5f;
    //I found 3 to be good for your game
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    //This is an object placed right below the player object that doesn't need a collider on it all, just needs to be an empty
    public GameObject groundCheckerObj;
    //You need to create a new layer type. It's up with the tags
    //Then you add all your platforms to that layer and put it in this one
    public LayerMask Ground;


    private Rigidbody body;
    private Vector3 inputs = Vector3.zero;
    public bool isGrounded = true;
    private Transform groundChecker;

    void Start()
    {
        //getting the rigid body to move it and checking the transform of the object for the floor check
        body = GetComponent<Rigidbody>();
        groundChecker = groundCheckerObj.transform;
    }

    void Update()
    {
        //we check our inputs and our grounding in update
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        //you can disable or have it be a hard zero for whichever axis you're not moving on
        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
        if (inputs != Vector3.zero)
            transform.forward = inputs;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

    }


    void FixedUpdate()
    {
        //we apply the changes using the physics and rigid body inputs here
        body.MovePosition(body.position + inputs * Speed * Time.fixedDeltaTime);
    }
}
