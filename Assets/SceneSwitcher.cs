using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "G" key is pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Load the new scene
            SceneManager.LoadScene("SpaceshipInteriorHub");
        }
    }
}
