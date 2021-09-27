using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float speed = 10;
    public float jumpforce = 11;

    public float gravity = -20;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        direction.x = hInput * speed;
        direction.z = vInput * speed;

        direction.y += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            //Jump
            direction.y = jumpforce;
        }
        controller.Move(direction * Time.deltaTime);
    }
}