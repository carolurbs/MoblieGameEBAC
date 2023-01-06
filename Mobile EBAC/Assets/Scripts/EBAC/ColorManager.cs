using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

[System.Serializable]
public class ColorManager : Singleton<ColorManager>
{
public List <Material> materials;
    public List <Color> colors;

    public void ChangeColor()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            materials[Random.Range(0,materials.Count)].SetColor("_Color", colors[Random.Range(0,colors.Count)]);
        }
                }

}
