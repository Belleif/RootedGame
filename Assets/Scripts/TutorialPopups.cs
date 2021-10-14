using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TutorialPopups : EditorWindow
{
    [MenuItem("Example/PopupExample")]
    static void Init()
    {
        EditorWindow window = EditorWindow.CreateInstance<TutorialPopups>();
        window.Show();
    }

    Rect buttonRect;
    void OnGUI()
    {
        {
            GUILayout.Label("Editor window with Popup example", EditorStyles.boldLabel);
            if (GUILayout.Button("Popup Options", GUILayout.Width(200)))
            {
               // PopupWindow.Show(buttonRect, new PopupExample());
            }
            if (Event.current.type == EventType.Repaint) buttonRect = GUILayoutUtility.GetLastRect();
        }
    }



}
