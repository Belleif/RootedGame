using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    /// <summary>
    /// This code fades a UI image in and out. There are two options provided.
    /// Where should I put this?
    /// --Put it anywhere. It has a public variable for the UI image that you want to fade.
    /// Anything special?
    /// --Make sure that Raycast Target is unclicked in the inspector on the image
    /// --There is code in here to force it, but it'd be good to doubley make sure in the project as well
    /// How does the code work?
    /// --The start function changes the image to transparent on start (so comment it out if you want it to be black
    /// --Start also sets it to ignore raycasts
    /// ------------------------------------------------------------------------------------------------
    /// Option 1: VOID FADEOUTANDINPINGPONG()
    /// This is a super simplified code that uses the pingpong function in the math class to ping pong between values
    /// (transparent to dark, to transparent again)
    /// Just put it where you want it.
    /// ------------------------------------------------------------------------------------------------
    /// Option 2: COROUTINE WITH FADEOUTANDINCOROUTINE
    /// This coroutine takes two parameter: whether we're going from transparent to black (true) or black to transparent (false)
    /// and a speed. It is defaulted to true and black.
    /// To call it, you use StartCoroutine(FadeOutAndInCoroutine(parameter1, parameter2)
    /// This gives you more control over fading out and in and allowing them to have differing speeds.
    /// </summary>
    /// 



    public Image theImage;
    // Start is called before the first frame update
    void Start()
    {
        //sets it to transparent
        theImage.color = new Color (theImage.color.r, theImage.color.g, theImage.color.b, 0f);

        //this code makes sure that it doesn't block raycasting to other things
        theImage.raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        //To fade to black use the following. You can adjust the .2 to a larger number for a faster fade
        //StartCoroutine(FadeOutAndInCoroutine(true, .2f));

        //To fade from black to clear use the following. Adjust the speed as needed
        //StartCoroutine(FadeOutAndInCoroutine(false, .2f));

    }

    public IEnumerator FadeOutAndInCoroutine(bool fadeToBlack = true, float fadeSpeed = 5)
    {
        Color objectColor = theImage.color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (theImage.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                theImage.color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (theImage.color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                theImage.color = objectColor;
                yield return null;
            }
        }
    }

    void FadeOutAndInPingPong()
    {
        theImage.color = new Color(theImage.color.r, theImage.color.g, theImage.color.b, Mathf.PingPong(Time.time, 2));
        Debug.Log(theImage.color.a);
    }

}
