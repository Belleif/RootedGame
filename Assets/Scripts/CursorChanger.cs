using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script contains 2 public Texture2D objects and 2 public functions to call to switch between cursors.
/// ---------------------------------------------------------------------------------------------------------
/// How do I use this in the scene?
/// --Put it on something. You should have a Game Manager object that just kinda floats around and is there
/// --every scene. That would be a good place.
/// --Drag the cursor images into the Texture2D variables.
/// --IT IS SUPER IMPORTANT THAT THEY BE SIZED AT 32x32. This can be set in their import settings.
/// ---------------------------------------------------------------------------------------------------------
/// Where do I access this in code?
/// --In your Island Control Point script, add a public variable to access the script: public CursorChanger variableName;
/// --MAKE SURE TO DRAG THE OBJECT WITH THE SCRIPT ON IT INTO THE APPROPRIATE PLACE IN THE INSPECTOR
/// --In the Island Control Point script, when you activate the island movement (switch camera to move islands)
/// --call variableName.theHandCursor()
/// --When you exit the camera view back to the normal game, make sure to call variableName.theArrowCursor()
/// ---------------------------------------------------------------------------------------------------------
/// This could easily be combined into one function and take the cursor you want as a parameter, but this might
/// be more understandable for now.
/// Additional cursors and functions could easily be added and called.
/// 
/// 
/// </summary>

public class CursorChanger : MonoBehaviour
{

    public Texture2D cursorArrow;
    public Texture2D cursorHand;
    
    // Start is called before the first frame update
    void Start()
    {
        //Make sure that the cursor is set to the arrow
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }


    //Set the cursor to the Arrow
    public void theArrowCursor()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);  
    }

    //Set the cursor to the Hand
    public void theHandCursor()
    {
        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
    }
}
