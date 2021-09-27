using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMovement : MonoBehaviour
{
    public CharacterController islandController;

    public float speed = 8f;
    public static int islandMove = 0;

    // Update is called once per frame
    void Update()
    {
        if (islandMove == 1)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            islandController.Move(move * speed * Time.deltaTime);

        }
    }
}