using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SampleSoil : MonoBehaviour
{

    public GameObject objectiveController;
    public GameObject messageText;
    public GameObject soilSamplerGround;
    public GameObject soilSamplerHeld;
    public GameObject learningPanel;
    public bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 7)
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInside && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 7 && Input.GetKeyDown(KeyCode.E))
        {
            messageText.SetActive(false);
            soilSamplerGround.SetActive(true);
            soilSamplerHeld.SetActive(false);
            objectiveController.GetComponent<ObjectiveController>().completedObjective = true;
            messageText.SetActive(false);
            messageText.GetComponent<TMP_Text>().text = "Press E to activate the water pump module.";
            objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveController>().completionClip);
            this.gameObject.SetActive(false);
            learningPanel.SetActive(true);
        }
    }
}
