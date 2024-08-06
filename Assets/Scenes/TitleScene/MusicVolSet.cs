using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolSet : MonoBehaviour
{
    public AudioSource music;

    public void OnSceneLoaded()
    {
        float? musicVol = MusicVolGet.musicVol;
        
        //Set volume level on scene start
        if (musicVol != null)
        {
            //music.volume = (float) musicVol;
            music.volume = (float) musicVol;
        }
    }
}
