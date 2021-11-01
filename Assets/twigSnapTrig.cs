using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twigSnapTrig : MonoBehaviour
{

    AudioSource twigSnap;
    // Start is called before the first frame update
    void Start()
    {
        twigSnap = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        twigSnap.Play();
    }
}
