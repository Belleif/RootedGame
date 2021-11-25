using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClicker : MonoBehaviour

{
    public GameObject currentIsle;
    public ParticleSystem particles;
    public ParticleSystem particlesGlow;
    public GameObject instructText;
    public GameObject emptyIsle;
    public GameObject pauseMenuUI;
    private Vector3 savedPosition;
    // Start is called before the first frame update
    void Start()
    {
        particles.Stop();
        particlesGlow.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuUI.activeSelf == false)
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
                                particlesGlow.Play();
                            }

                            Debug.Log("Moveable Island Hit");
                            currentIsle = hitInfo.transform.gameObject;
                            currentIsle.GetComponent<Rigidbody>().isKinematic = false;
                            currentIsle.GetComponent<IslandMovement>().isMoving = true;

                            if (currentIsle.GetComponent<IslandMovement>().moveY == true)
                            {
                                instructText.GetComponent<TMPro.TextMeshProUGUI>().text = "Click Isle to select \n Use 'W' & 'S' to move Isle \n Press E to exit control";
                            }
                            else if (currentIsle.GetComponent<IslandMovement>().moveX == true)
                            {
                                instructText.GetComponent<TMPro.TextMeshProUGUI>().text = "Click Isle to select \n Use 'W' & 'S' to move Isle \n Press E to exit control";
                            }
                            else if (currentIsle.GetComponent<IslandMovement>().moveZ == true)
                            {
                                instructText.GetComponent<TMPro.TextMeshProUGUI>().text = "Click Isle to select \n Use 'W' & 'S' to move Isle \n Press E to exit control";
                            }
                            else
                            {
                                instructText.GetComponent<TMPro.TextMeshProUGUI>().text = "Click Isle to select \n Press E to exit control";
                            }
                        }
                        else
                        {
                            Debug.Log("Not Moveable Island");
                            if (currentIsle != null)
                            {
                                currentIsle.GetComponent<Rigidbody>().isKinematic = true;
                                currentIsle.GetComponent<IslandMovement>().isMoving = false;
                                particles.Stop();
                                particlesGlow.Stop();
                                instructText.GetComponent<TMPro.TextMeshProUGUI>().text = "Click Isle to select \n Press E to exit control";
                                currentIsle = emptyIsle;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("No hit");
                    }
                }
        }
    }
    private void LateUpdate()
    {
        savedPosition = currentIsle.transform.position;
        particles.transform.position = savedPosition;
        particlesGlow.transform.position = savedPosition;
    }

}
