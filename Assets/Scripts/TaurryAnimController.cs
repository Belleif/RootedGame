using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaurryAnimController : MonoBehaviour
{
    Animator animator;
    private GameObject taurry;
    public double idleTime;
    public double struggleTime;


    // Start is called before the first frame update
        void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        idleTime = 30;
        struggleTime = 8.342;
    }


    // Update is called once per frame
    void Update()
    {
        if(idleTime > 0)
        {
            animator.Play("Taurry_Idle");
            idleTime -= Time.deltaTime;
            Debug.Log(idleTime);
        }
        if(idleTime <= 0)
        {
            animator.Play("Taurry_Struggle");
            struggleTime -= Time.deltaTime;
            Debug.Log(struggleTime);
            if (struggleTime <= 0)
            {
                idleTime = 30;
                struggleTime = 8.342;
                Debug.Log("Reset");
            }
        }
    }
    

}
