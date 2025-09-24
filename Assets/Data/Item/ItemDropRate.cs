using UnityEngine;
using System;
[Serializable] // Để hiển thị trong Inspector khi nằm trong List
public class ItemDropRate
{
    public ItemProFileSO itemProfileSO; // Tham chiếu đến dữ liệu item
    public float dropRate;  // Tỉ lệ rơi (%)
    public int minDrop;   // Số lượng tối thiểu rơi
    public int maxDrop;   // Số lượng tối đa rơi
}
