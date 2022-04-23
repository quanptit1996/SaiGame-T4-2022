using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : OverideMonoBehaviour
{
    public static FXManager instance;

    [SerializeField] protected List<Transform> fxs = new List<Transform>();

    protected override void Awake()
    {
        base.Awake();
        if (FXManager.instance != null) Debug.LogError("Only 1 FXManager allow");
        FXManager.instance = this;

        this.HideAll();
    }

    protected override void LoadComponents()
    {
        this.LoadFXS();
    }

    protected virtual void LoadFXS()
    {
        if (this.fxs.Count > 0) return;
        foreach (Transform child in transform)
        {
            this.fxs.Add(child);
        }
        Debug.Log(transform.name + ": LoadFXS", gameObject);
    }

    protected virtual void HideAll()
    {
        foreach (Transform fx in this.fxs)
        {
            fx.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string fxName)
    {
        Transform fx = Instantiate(this.fxs[0]);

        return fx;
    }

    public virtual void Despawn(Transform tranObj)
    {
        tranObj.gameObject.SetActive(false);
    }
    
    
}
