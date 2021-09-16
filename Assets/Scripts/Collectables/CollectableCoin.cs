using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : Collectable
{
    public Collider2D coinCollider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        coinCollider.enabled = false;
    }
}
