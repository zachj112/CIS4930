using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPod : MonoBehaviour
{
    public AudioSource wind;
    public AudioClip windClip2;
    public GameObject pod;
    public GameObject layer1Info;
    public GameObject layer2Info;
    public GameObject layer3Info;
    public GameObject layer4Info;
    public GameObject layer5Info;
    public Material layer1Skybox;
    public Material layer2Skybox;
    public Material layer3Skybox;
    public Material layer4Skybox;
    public Material layer5Skybox;
    public GameObject objectiveController;
    private void OnTriggerEnter(Collider other)
    {
        pod.GetComponent<Movement>().enabled = false;
        objectiveController.GetComponent<ObjectiveControllerJupiter>().completedObjective = true;
        objectiveController.GetComponent<AudioSource>().PlayOneShot(objectiveController.GetComponent<ObjectiveControllerJupiter>().completionClip);

        if (this.name == "layer1")
        {
            wind.clip = windClip2;
            wind.Play();
            layer1Info.SetActive(true);
            RenderSettings.skybox = layer1Skybox;
            pod.GetComponent<Movement>().enabled = false;
        }
        else if (this.name == "layer2")
        {
            layer2Info.SetActive(true);
            RenderSettings.skybox = layer2Skybox;
            pod.GetComponent<Movement>().enabled = false;
        }
        else if (this.name == "layer3")
        {
            layer3Info.SetActive(true);
            RenderSettings.skybox = layer3Skybox;
            pod.GetComponent<Movement>().enabled = false;
        }
        else if (this.name == "layer4")
        {
            layer4Info.SetActive(true);
            RenderSettings.skybox = layer4Skybox;
            pod.GetComponent<Movement>().enabled = false;
        }
        else if (this.name == "layer5")
        {
            layer5Info.SetActive(true);
            RenderSettings.skybox = layer5Skybox;
            pod.GetComponent<Movement>().enabled = false;

        }
    }
}
