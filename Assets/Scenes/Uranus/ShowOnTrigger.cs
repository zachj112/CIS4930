using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnTrigger : MonoBehaviour
{
    public GameObject obj;

    public void OnTriggerEnter(Collider other)
    {
        obj.SetActive(true);
    }
}
