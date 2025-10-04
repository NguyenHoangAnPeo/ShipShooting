using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExitGame : BaseBtn
{
    protected override void OnClick()
    {
        Debug.Log("On Click Exit Game");
        Application.Quit();
    }
}
