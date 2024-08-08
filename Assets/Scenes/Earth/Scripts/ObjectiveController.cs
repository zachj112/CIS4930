using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    public GameObject messageText;
    public AudioClip completionClip;
    private AudioSource textType;
    private string[] instructions = {
        "Welcome to Earth, the 3rd planet of our solar system! (Press F to Continue)",
        "It appears we are missing important information.. (Press F to Continue)",
        "Let's get our temperature. Go to the green area to place the thermal module.",
        "Press E on the thermal module to measure the current temperature.",
        "Now, let's measure pressure. Go to green area to place the pressure module.",
        "Press E on the pressure module to measure the current pressure.",
        "Great. Let's take a sample of the soil of this planet. (Press F to Continue)",
        "Go to the green area to sample the local soil.",
        "Finally, let's get sample of the water. Go to the water pump module and sample the water.",
        "Good job! Let's go back to the hub!"
    };
    public int currentInstruction = 0;
    private int currentSymbol = 0;
    private bool textLoaded = false;
    public bool completedObjective = false;
    public GameObject heldThermal;
    public GameObject thermalArea;
    public GameObject heldBarometer;
    public GameObject pressureArea;
    private TMP_Text label;



    void Start()
    {
        label = messageText.GetComponent<TMP_Text>();
        label.text = "";
        textType = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) && textLoaded == true && currentInstruction + 1 < instructions.Length && (currentInstruction == 0 || currentInstruction == 1 || currentInstruction == 6)) || completedObjective == true)
        {
            currentInstruction++;
            if (currentInstruction == 2)
            {
                heldThermal.SetActive(true);
                thermalArea.SetActive(true);
            }
            if (currentInstruction == 4)
            {
                pressureArea.SetActive(true);
                heldBarometer.SetActive(true);
            }
            label.text = "";
            textLoaded = false;
            textType.Play();
            completedObjective = false;
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
        }
    }
}
