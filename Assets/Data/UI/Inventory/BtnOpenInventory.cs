using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenInventory : BaseBtn
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
}
