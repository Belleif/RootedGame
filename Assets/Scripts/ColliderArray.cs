using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderArray : MonoBehaviour
{
    public GameObject[] colliders;
    public GameObject ThirdCam;
    // Start is called before the first frame update
    void Start()
    {
        colliders = GameObject.FindGameObjectsWithTag("Collider");
    }

    // Update is called once per frame
    void Update()
    {
        

        for (int i = 0; i < colliders.Length; i++)
        {
            if (ThirdCam.activeSelf)
            {
                colliders[i].GetComponent<BoxCollider>().isTrigger = true;
            }
            else
            {
                colliders[i].GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
