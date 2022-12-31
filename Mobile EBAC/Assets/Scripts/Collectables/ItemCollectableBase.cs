using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase: MonoBehaviour
{
    public string compareTag = "CoinCollector";
    public float timeToHide = 3;
    public GameObject graphicItem;
   // public ParticleSystem _particleSystem;
   // [Header("Sounds")]
   // public AudioSource audioSource;
    private void Awake()
    {
        //if (_particleSystem != null)   _particleSystem.transform.SetParent(null);
      //  if (audioSource != null) audioSource.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        Debug.Log("Collect");
        if(graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        gameObject.SetActive(false);
        OnCollect();
    }
    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect()
    {
    //if (_particleSystem != null) _particleSystem.Play();
      // if (audioSource != null) audioSource.Play();




    }

}
