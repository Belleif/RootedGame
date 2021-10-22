using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicker : MonoBehaviour

{
    public GameObject currentIsle;
    public ParticleSystem particles;
    private Vector3 savedPosition;
    // Start is called before the first frame update
    void Start()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click it");
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                Debug.Log("Hit" + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Island")
                {
                    if (currentIsle != null)
                    {
                     currentIsle.GetComponent<IslandMovement>().isMoving = false;
                     currentIsle.GetComponent<Rigidbody>().isKinematic = true;
                     particles.Play();

                    }

                    Debug.Log("Moveable Island Hit");
                    currentIsle = hitInfo.transform.gameObject;
                    currentIsle.GetComponent<Rigidbody>().isKinematic = false;
                    currentIsle.GetComponent<IslandMovement>().isMoving = true;
                }
                else
                { 
                    Debug.Log("Not Moveable Island");
                    if (currentIsle != null)
                    {
                        currentIsle.GetComponent<Rigidbody>().isKinematic = true;
                        currentIsle.GetComponent<IslandMovement>().isMoving = false;
                    }
                }
            }
            else
            {
                Debug.Log("No hit");
            }
        }
    }
    private void LateUpdate()
    {

        savedPosition = currentIsle.transform.position;
        particles.transform.position = savedPosition;
    }

}
