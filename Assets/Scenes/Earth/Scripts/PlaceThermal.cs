using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceThermal : MonoBehaviour
{
    public GameObject heldThermal;
    public GameObject groundThermal;
    public GameObject objectiveController;
    public GameObject messageText;
    public bool isInside = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && objectiveController.GetComponent<ObjectiveController>().currentInstruction == 2)
        {
            messageText.SetActive(true);
            isInside = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInside && Input.GetKey(KeyCode.E))
        {
            heldThermal.SetActive(false); 
            groundThermal.SetActive(true);
            this.gameObject.SetActive(false);
            objectiveController.GetComponent<ObjectiveController>().completedObjective = true;
            objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveController>().completionClip);
        }
    }
}
