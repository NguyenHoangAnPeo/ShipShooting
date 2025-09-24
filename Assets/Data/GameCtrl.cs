using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : AnMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance {get => instance;}
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera {get => mainCamera;}
    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null && GameCtrl.instance != this)
        {
            Debug.LogWarning("Only 1 GameCtrl allowed");
            Destroy(gameObject);
            return;
        }
        GameCtrl.instance = this;
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;

        this.mainCamera = Camera.main; // Ưu tiên MainCamera
        if (this.mainCamera == null)
            this.mainCamera = GameObject.FindObjectOfType<Camera>();

        if (this.mainCamera == null)
            Debug.LogError("Không tìm thấy camera trong scene!");
        else
            Debug.Log(transform.name + " LoadCamera", gameObject);
    }
}