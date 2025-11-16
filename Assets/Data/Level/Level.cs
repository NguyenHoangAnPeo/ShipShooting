using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : AnMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 1;
    [SerializeField] protected int levelMax = 20;
    public static Level instance;
    public static Level Instance => instance;

    public event System.Action<int> OnLevelChanged;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;
    protected override void Awake()
    {
        base.Awake();
        if (Level.instance != null && Level.instance != this)
        {
            Debug.LogWarning("Only 1 GameCtrl allowed");
            Destroy(gameObject);
            return;
        }
        Level.instance = this;
    }
    public virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }
    public virtual void LevelSet(int newLevel)
    {
        if(newLevel != this.levelCurrent)
        {
            this.levelCurrent = newLevel;
            this.LimitLevel();
            OnLevelChanged?.Invoke(this.levelCurrent);
        }
        //this.levelCurrent = newLevel;
        //this.LimitLevel();
    }
    protected virtual void LimitLevel()
    {
        if (this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if(this.levelCurrent < 1) this.levelCurrent = 1;
    }
    public float GetSpawnDelay(float baseInterval)
    {
        //baseInterval : khoang thoi gian co ban
        return Mathf.Max(0.5f, baseInterval - levelCurrent * 0.2f);
    }
    public int GetSpawnLimit(int baseLimit)
    {
        //baseLimit: so luong toi da ban dau;
        return baseLimit + levelCurrent / 2;
    }
}
