using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolGet : MonoBehaviour
{
    public static float? musicVol;

    public Slider volSlider;

    // Set music volume
    public void onValueChanged(Slider volSlider)
    {
        musicVol = volSlider.value;
        Debug.Log(musicVol);
    }
}
