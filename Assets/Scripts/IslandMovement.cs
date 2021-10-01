using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMovement : MonoBehaviour
{
    public CharacterController islandController;
    public GameObject controlPoint;

    public float speed = 8f;
    public static int islandMove = 0;
    
    public bool moveX;
    public bool moveY;

    private float x;
    private float z;

    


    // Update is called once per frame
    void Update()
    {
        
        if (islandMove == 1)
        {
            if (moveX)
            {
                x = Input.GetAxis("Horizontal");
                z = 0;
            }
            else if (moveY)
            {
                x = 0;
                z = Input.GetAxis("Vertical"); ;
            }

                Vector3 move = controlPoint.transform.right * x + controlPoint.transform.forward * z;

                islandController.Move(move * speed * Time.deltaTime);
            

        }
    }
}