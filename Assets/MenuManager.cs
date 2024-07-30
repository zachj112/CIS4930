using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menyu : MonoBehaviour
{
    public static bool gameIsPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else
        {
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
