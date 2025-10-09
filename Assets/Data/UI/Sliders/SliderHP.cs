using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderHP : BaseSlider
{
    [Header("HP Slider")]
    [SerializeField] float maxHP = 100;
    [SerializeField] float currentHP = 70;

    protected override void FixedUpdate()
    {
        this.HPShowing();
    }
    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
        
    }
    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP = currentHP;
    }
}
