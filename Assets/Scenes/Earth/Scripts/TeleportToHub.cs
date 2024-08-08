using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToHub : MonoBehaviour
{
    public GameObject interiorHubScene;
    public GameObject messageText;
    public GameObject objectiveController;
    public bool isInside = false;

    public void immediateTeleport()
    {
        SceneManager.LoadScene("SpaceshipInteriorHub");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 9)
        {
            messageText.SetActive(true);
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 9)
        {
            messageText.SetActive(false);
            isInside = false;
        }
    }

    void Update()
    {
        if (isInside && Input.GetKeyDown(KeyCode.E) && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 9)
        {
            SceneManager.LoadScene("SpaceshipInteriorHub");
        }
    }
}
