using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveControllerJupiter : MonoBehaviour
{
    public GameObject messageText;
    public AudioClip completionClip;
    private AudioSource textType;
    private string[] instructions = {
        "Welcome to Jupiter, the 4th planet of our solar system! (Press F to Continue)",
        "Once again, we are missing some information. Dive deeper to calibrate.",
        "Great! Each layer of this planet seems to be quite different. (Press F to Continue)",
        "Continue taking measurements for each layer as we move down. (Press F to Continue)",
        "Dive down to get to the Gaseous Hydrogen Layer",
        "Dive down to get to the Liquid Hydrogen Layer",
        "Dive down to get to the Metallic Hydrogen Layer",
        "Dive down to get to the Core",
        "Congrats!",
    };
    public int currentInstruction = 0;
    private int currentSymbol = 0;
    private bool textLoaded = false;
    public bool completedObjective = false;
    public GameObject pod;
    private TMP_Text label;



    void Start()
    {
        Screen.lockCursor = false;
        label = messageText.GetComponent<TMP_Text>();
        label.text = "";
        textType = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) && textLoaded == true && currentInstruction + 1 < instructions.Length 
            && (currentInstruction == 0 || currentInstruction == 2 || currentInstruction == 3)) || completedObjective == true)
        {
            label.text = "";
            currentInstruction++;
            textLoaded = false;
            textType.Play();
            completedObjective = false;

            if (currentInstruction == 1)
            {
                pod.GetComponent<Movement>().enabled = true;
            }
        }

        if (!textLoaded)
        {
            Invoke(nameof(TypeNext), 0.01f);
        }
    }

    void TypeNext()
    {
        print(currentInstruction);
        label.text += instructions[currentInstruction][currentSymbol];

        print(instructions[currentInstruction][currentSymbol] + " " + currentSymbol);
        currentSymbol++;

        if (currentSymbol == instructions[currentInstruction].Length)
        {
            textLoaded = true;
            currentSymbol = 0;
            textType.Stop();

            if (currentInstruction == 1)
            {

            }
        }
    }

    public void endCompletion()
    {
        completedObjective = false;
    }
}
