using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public bool collect = false;
    public ParticleSystem coinVFX;
    public AudioSource coinSFX;

    public void Awake()
    {
        if (coinVFX != null) coinVFX.transform.SetParent(null);
        if(coinSFX != null) coinSFX.transform.SetParent(null);

    }
    protected override void OnCollect()
    {
        if (coinVFX != null) coinVFX. Play();
        if(coinSFX != null) coinSFX.Play();
        base.OnCollect();
        collect= true;
        PlayerController.Instance.Bounce();
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
