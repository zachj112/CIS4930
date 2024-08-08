using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetTemp : MonoBehaviour
{
    public GameObject messageText;
    public GameObject temperatureText;
    public GameObject objectiveController;
    public GameObject learningPanel;
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 3)
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
        if (isInside == true && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 3 &&  Input.GetKeyDown(KeyCode.E))
        {
            messageText.SetActive(false);
            messageText.GetComponent<TMP_Text>().text = "Press E to connect to the pressure module.";
            temperatureText.GetComponent<TMP_Text>().text = "70 °F";
            objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveController>().completionClip);
            objectiveController.GetComponent<ObjectiveController>().completedObjective = true;
            learningPanel.gameObject.SetActive(true);

        }
    }
}
