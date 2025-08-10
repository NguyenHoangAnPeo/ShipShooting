using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
public class ItemSO : ScriptableObject
{
    public string itemCode = "code"; // Mã định danh item
    public string itemName = "Item"; // Tên hiển thị của item
}
