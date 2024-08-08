using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetPressure : MonoBehaviour
{
    public GameObject messageText;
    public GameObject pressureText;
    public GameObject objectiveController;
    public GameObject learningPanel;
    public GameObject soilSamplerHeld;
    public GameObject soilSamplerArea;
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 5)
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
        if (isInside == true && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 5 && Input.GetKeyDown(KeyCode.E))
        {
            messageText.SetActive(false);
            messageText.GetComponent<TMP_Text>().text = "Press E to sample the local soil.";
            pressureText.GetComponent<TMP_Text>().text = "14.7 psi";
            objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveController>().completionClip);
            objectiveController.GetComponent<ObjectiveController>().completedObjective = true;
            soilSamplerArea.SetActive(true);
            soilSamplerHeld.SetActive(true);
            learningPanel.gameObject.SetActive(true);

        }
    }
}
