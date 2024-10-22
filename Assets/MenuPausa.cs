using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaEsc : MonoBehaviour
{
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseGameplay();
        }
        else
        {
            ResumeGameplay();
        }
    }

    private void PauseGameplay()
    {
        Time.timeScale = 0;
    }

    private void ResumeGameplay()
    {
        Time.timeScale = 1;
    }

    private void OnGUI()
    {
        if (isPaused)
        {
            GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 40,
                alignment = TextAnchor.MiddleCenter
            };

            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 100), "Game paused", labelStyle);


            if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 10, 150, 40), "Resume"))
            {
                ResumeGameplay();

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 60, 150, 40), "Main Menu"))
            {

                Debug.Log("Returning to Main Menu...");
                ResumeGameplay();
            }
        }

    }
}

