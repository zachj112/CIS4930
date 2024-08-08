using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PumpWater : MonoBehaviour
{
    public GameObject messageText;
    public GameObject objectiveController;
    public GameObject learningPanel;

    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 8)
        {
            messageText.SetActive(true);
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messageText.SetActive(false);
            isInside = false;
        }
    }

    public void Update()
    {
        if (isInside == true && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 8 && Input.GetKeyDown(KeyCode.E))
        {
            messageText.SetActive(false);
            objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveController>().completionClip);
            objectiveController.GetComponent<ObjectiveController>().completedObjective = true;
            learningPanel.gameObject.SetActive(true);
            messageText.GetComponent<TMP_Text>().text = "Press E to teleport to the hub.";
        }
    }
}
