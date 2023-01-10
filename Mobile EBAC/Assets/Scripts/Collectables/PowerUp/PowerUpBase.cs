using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("Power Up")]
    public float duration;
    public ParticleSystem powerUPVFX;
    public AudioSource PowerUpSFX;


    public void Awake()
    {
        if (powerUPVFX != null)powerUPVFX.transform.SetParent(null);
        if (PowerUpSFX != null) PowerUpSFX.transform.SetParent(null);

    }
    protected override void OnCollect()
    {
        if (powerUPVFX != null) powerUPVFX.Play();
        if (PowerUpSFX != null) PowerUpSFX.Play();
        base.OnCollect();
        StartPowerUp();
        PlayerController.Instance.Bounce();
    }
    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
    }
    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");

    }
}
