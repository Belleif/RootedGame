using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 attackMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += attackMovement * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") < -.01f)
        {
            transform.localPosition = new Vector3(-4.1f, -0.05f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") > .01f)
        {
            transform.localPosition= new Vector3(4.1f, 0.05f, 0f);
        }
        else
        {

        }
    }
}
