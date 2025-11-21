using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]
    protected override void Start()
    {
        base.Start();
        //Invoke(nameof(this.Test), 5);
    }
    protected virtual void Test()
    {
        Vector3 droPos = transform.position;
        droPos.x += 1;
        Quaternion droRot = transform.rotation;
        this.DropItemIndex(0,droPos,droRot);
    }
    protected virtual void DropItemIndex(int index,Vector3 droPos,Quaternion droRot)
    {
        ItemInventory itemInventory = this.inventory.Items[index];

        ItemDropSpawner.Instance.DropFromInventory(itemInventory, droPos, droRot);
        this.inventory.Items.Remove(itemInventory);
        Debug.Log(itemInventory.itemProfile.itemCode + " Da duoc drop");
    }
}
