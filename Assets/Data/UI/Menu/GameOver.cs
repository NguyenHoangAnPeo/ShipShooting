using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : AnMonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        transform.gameObject.SetActive(false);
    }
}
