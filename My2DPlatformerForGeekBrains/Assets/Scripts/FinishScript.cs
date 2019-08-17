using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    // Only show it if needed.
    private bool show = false;

    void OnGUI()
    {
        if (show) //Is it Open?
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 -100, 200, 200), "Restart")) //Display and use the Yes button
            {
                Application.LoadLevel(0);
                show = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Open();
    }

    // To open the dialogue from outside of the script.
    public void Open()
    {
        show = true;
    }
}
