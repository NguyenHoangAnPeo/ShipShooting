using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : AnMonoBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.Log("AbilitiesCode: " + abilitiesCode.ToString());
    }
}
