using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    [Header("PowerUp Height")]
    public float amountToFly;
    public float animationDuration = .1f; 
    public DG.Tweening.Ease ease =DG.Tweening.Ease.OutBack;


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeHeight(amountToFly, duration, animationDuration, ease);
    }
  
}
