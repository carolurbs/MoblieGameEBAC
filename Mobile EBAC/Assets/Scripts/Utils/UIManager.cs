using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
public class UIManager : Singleton<UIManager>
{
    public AudioSource audioUI;
    
    public void PlayAudio()
    {
        if(audioUI != null)
        audioUI.Play();
    }
}
