using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 70f;
    }
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
}
