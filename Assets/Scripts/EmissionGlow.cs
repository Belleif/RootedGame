using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Place script on thing that needs to pulsate.
/// THEY MUST BE ON EACH ITEM THAT NEEDS IT. WITHOUT THE SCRIPT IT WILL GLOW BUT NOT PULSATE
/// Drag its material into the spot and modify as needed.
/// </summary>
public class EmissionGlow : MonoBehaviour
{
    public Material mat; //This is the material to be manipulated
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

        mat.SetColor("_EmissionColor", finalColor);
    }
}
