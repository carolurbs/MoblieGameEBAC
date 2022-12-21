using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt; 
    public TextMeshProUGUI uiTextValue;
    void Start()
    {

    }

    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
        
    }
}
