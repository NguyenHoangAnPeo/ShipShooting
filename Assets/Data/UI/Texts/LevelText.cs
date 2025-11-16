using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateLevelText();
    }
    protected virtual void UpdateLevelText()
    {
        int levelMax = Level.Instance.LevelMax;
        int level = Level.Instance.LevelCurrent;

        this.text.SetText("Level: "+ level + "/" + levelMax);
    }
    //protected override void OnEnable()
    //{
    //    if (Level.Instance != null)
    //    {
    //        Level.Instance.OnLevelChanged += UpdateUILevel;      
    //        UpdateUILevel(Level.Instance.LevelCurrent);
    //    }
    //}
    //protected virtual void OnDisable()
    //{
    //    if (Level.Instance != null)
    //        Level.Instance.OnLevelChanged -= UpdateUILevel;
    //}
    //protected virtual void UpdateUILevel(int newLevel)
    //{
    //    this.text.SetText("Level " + newLevel);
    //}
}
