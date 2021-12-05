using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBlackOut : MonoBehaviour
{
    public Transform player; //The player object
    public Transform blackout; //an object (can be empty) to denote where it should be at total darkness
    private bool startDistanceCheck = false; //you will need an object to start the fade.
    private float opacity; //this holds the value to change the a
    private float step; //math to create how much you need to ramp up the opacity each step

    public Image blackImage; //The UI image/element that you need to fade to black.
    // Start is called before the first frame update
    void Start()
    {
        //sets it to transparent
        blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, 0f);

        //this code makes sure that it doesn't block raycasting to other things
        blackImage.raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startDistanceCheck)
        {
            //color is on a 0-1 scale. So we take 255 (which is the full color possibility) and subtract the distance
            //Multiply by the step (which is a division problem to see how much it needs to ramp each step
            //based on the distance between the "start point" and "end point"
            //Then we divide the whole thing by 255 to get it into the 0-1 range
            opacity = (255 - (Vector3.Distance(player.position, blackout.position) * step))/255;
            //Debug.Log(opacity);
            blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, opacity);

            //If you want it to stay black once it's all the way black, you could set startDistance check to false if opacity > .9
        }
    }
    //You need an object for this. This is your Start trigger that says "yes, start ramping the opacity"
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startDistanceCheck = true;
            //Debug.Log("hit start");
            step = Mathf.Round(256 / (Vector3.Distance(player.position, blackout.position)));
            //Debug.Log(step);
        }
    }
}
