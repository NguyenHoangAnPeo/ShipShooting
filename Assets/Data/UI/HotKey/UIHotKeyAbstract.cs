using UnityEngine;

public abstract class UIHotKeyAbstract : AnMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl hotKeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIKeyCtrl();
    }

    protected virtual void LoadUIKeyCtrl()
    {
        if (this.hotKeyCtrl != null) return;
        this.hotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
        Debug.Log(transform.name + ": LoadUIKeyCtrl", gameObject);
    }
}
