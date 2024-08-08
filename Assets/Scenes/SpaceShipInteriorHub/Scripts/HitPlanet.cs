using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitPlanet : MonoBehaviour
{
    public GameObject teleportMessage;
    public GameObject welcomeMessage;
    public string currentPlanet;
    private bool isIn = false;

    private void OnTriggerEnter(Collider other)
    {
        teleportMessage.GetComponent<TMP_Text>().text = "Press F to teleport to " + currentPlanet + ".";
        teleportMessage.gameObject.SetActive(true);
        teleportMessage.GetComponent<AudioSource>().Play();
        welcomeMessage.gameObject.SetActive(false);
        isIn = true;

    }
    private void OnTriggerExit(Collider other)
    {
        teleportMessage.gameObject.SetActive(false);
        welcomeMessage.gameObject.SetActive(true);
        isIn = false;
    }

    public void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(currentPlanet);
        }
    }
}
