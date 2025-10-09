using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : BaseBtn
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
