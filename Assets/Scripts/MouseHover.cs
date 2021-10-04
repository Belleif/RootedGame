using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    //This script is placed directly on object(s) to be highlighted
    //Please note, this does not work for nested objects inside an empty
    //It has to be placed directly on an object that is on its own
    //If it has a parent, the mouse hover catches the parent and not the child
    //You could solve this by getting the children components or just not having it nested.
    private Color startColor;
    private Color highlightColor;
    private void Start()
    {
        startColor= this.gameObject.GetComponent<Renderer>().material.color;
        highlightColor = Color.cyan;
    }

    void OnMouseEnter()
    {
        this.gameObject.GetComponent<Renderer>().material.color = highlightColor;
    }
    void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = startColor;
    }
}
