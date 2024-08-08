using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float dropSpeed = 1.0f;
    public GameObject objectiveController;

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            dropSpeed = 20.0f;
        }
        else
        {
            dropSpeed = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponentInChildren<Camera>().transform.RotateAround(this.transform.position, Vector3.up, 25.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponentInChildren<Camera>().transform.RotateAround(this.transform.position, Vector3.up, -25.0f * Time.deltaTime);
        }

        this.gameObject.transform.position += Vector3.down * dropSpeed * Time.deltaTime;
    }
}
