using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProFileSO", menuName = "SO/ItemProFile")]
public class ItemProFileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
}
