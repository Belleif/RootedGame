using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Place script on your game manager or something external
/// Public array to hold all the materials needed to pulsate in the same way
/// change values as needed.
/// </summary>
public class EmissionGlow : MonoBehaviour
{
    public Material[] mats; //These are the materials to be manipulated
    public float speedModifier = 3f; //larger the number, slower the speed
    public Color baseColor = Color.yellow; //This is your color at full blast
    
    
    // Start is called before the first frame update
    void Start()
    {
        //mat = GetComponent<Renderer>().material; //You'd use this if the script was private
    }

    // Update is called once per frame
    void Update()
    {
        float emission = Mathf.PingPong(Time.time, 1.0f * speedModifier);

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        foreach (Material mat in mats)
        {
            mat.SetColor("_EmissionColor", finalColor);
        }
    
    }
}
