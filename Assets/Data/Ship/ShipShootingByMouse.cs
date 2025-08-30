using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingByMouse : ShipShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFire == 1;
        return this.isShooting;
    }
}