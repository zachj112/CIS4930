using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlacePressure : MonoBehaviour
{
    public GameObject heldBarometer;
    public GameObject groundBarometer;
    public GameObject objectiveController;
    public GameObject messageText;
    public bool isInside = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 4)
        {
            messageText.SetActive(true);
            isInside = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        messageText.SetActive(false);
        isInside = false;
    }

    void Update()
    {
        if (isInside && Input.GetKey(KeyCode.E) && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 4)
        {
            heldBarometer.SetActive(false);
            groundBarometer.SetActive(true);
            this.gameObject.SetActive(false);
            objectiveController.GetComponent<ObjectiveController>().completedObjective = true;
            objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveController>().completionClip);
        }
    }
}
