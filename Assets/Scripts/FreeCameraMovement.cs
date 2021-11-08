using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                 Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0));
        }
    }
}
