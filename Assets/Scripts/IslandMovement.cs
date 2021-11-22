using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMovement : MonoBehaviour
{
    public Rigidbody islandController;
    public GameObject controlPoint;

    public float speed = 8f;
    public static int islandMove = 0;
    public bool isMoving = false;
    
    public bool moveX;
    public bool moveZ;
    public bool moveY;

    private float x;
    private float z;
    private float y;

    void Start()
    {
        islandController.constraints = RigidbodyConstraints.FreezePosition;
        islandController.constraints = RigidbodyConstraints.FreezeRotation;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMoving)
        {
            islandController.constraints = RigidbodyConstraints.FreezePosition;
            islandController.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            islandController.constraints = RigidbodyConstraints.None;
            islandController.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (islandMove == 1 && isMoving)
        {
            if (moveX)
            {
                x = Input.GetAxis("Vertical");
                z = 0;
                y = 0;
            }
            else if (moveZ)
            {
                x = 0;
                z = Input.GetAxis("Vertical");
                y = 0;
            }
            else if (moveY)
            {
                x = 0;
                z = 0;
                y = Input.GetAxis("Vertical");
            }

            Vector3 move = controlPoint.transform.right * x + controlPoint.transform.up * y + controlPoint.transform.forward * z;
            islandController.MovePosition(transform.position + move * speed * Time.deltaTime);
            

        }
    }
}