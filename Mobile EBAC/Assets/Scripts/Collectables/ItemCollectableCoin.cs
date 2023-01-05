using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;
    protected override void OnCollect()
    {
        base.OnCollect();
        collect= true;
    }
  
    protected virtual void HideItens()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
    }
    protected override void Collect()
    {
        HideItens();
        OnCollect();
    }
}
