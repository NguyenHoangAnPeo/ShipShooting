using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum AbilitiesCode
{
    NoAbility = 0,
    Missle = 1,
    Laze = 2,
}
public class AbilitiesCodeParser
{
    public static AbilitiesCode FromString(string abilityName)
    {
        try
        {
            return (AbilitiesCode)System.Enum.Parse(typeof(AbilitiesCode), abilityName);
        }
        catch(ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return AbilitiesCode.NoAbility;
        }
    }
}
