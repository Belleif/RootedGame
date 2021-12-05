using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    public Image theImage;//solid black image
    public float fadeSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //sets it to transparent
        theImage.color = new Color(theImage.color.r, theImage.color.g, theImage.color.b, 0f);

        //this code makes sure that it doesn't block raycasting to other things
        theImage.raycastTarget = false;
    }

    private void Update()
    {
   

    }
    private void OnTriggerEnter(Collider other)
    {
        
        StartCoroutine(FadeOutAndInCoroutine(true, fadeSpeed));
        
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
}
