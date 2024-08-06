using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnPress : MonoBehaviour
{

    void Update()
    {
        // Check if the Y key is pressed
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Remove the rock from the scene
            Destroy(gameObject);
        }
    }
}