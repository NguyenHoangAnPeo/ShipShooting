using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
   protected static ItemDropSpawner instance;
   public static ItemDropSpawner Instance{get => instance;}
    protected override void Awake()
    {
        base.Awake();
         if(ItemDropSpawner.instance != null)Debug.Log("Only 1 ItemDropSpawner is exits");
        ItemDropSpawner.instance = this;
    }
    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
