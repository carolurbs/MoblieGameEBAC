using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioSource uiSFX;
    public void Play()
    {
       if(uiSFX != null)uiSFX.Play();
    }
}
