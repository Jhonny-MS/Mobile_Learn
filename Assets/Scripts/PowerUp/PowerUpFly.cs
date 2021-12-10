using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amoutToFly = 2;
	public float animationDuration = .1f;
	public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

	protected override void StartPowerUp()
	{
		base.StartPowerUp();
		PlayerController.Instance.ChangeHeight(amoutToFly, duration, animationDuration, ease);
	}

}
