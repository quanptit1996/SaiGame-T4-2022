using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallFly : OverideMonoBehaviour
{
    public bool isTurnRight = true;
    [SerializeField] protected float speed = 9f;
    [SerializeField] protected Transform model;
    [SerializeField] protected DamageSender damageSender;
    [SerializeField] protected Collider _collider;

    protected override void Awake()
    {
        base.Awake();
        //this.Turning(false);
    }

    protected override void Update()
    {
        Vector3 dir = transform.right;
        if (!this.isTurnRight) dir *= -1;
        transform.position += dir * this.speed * Time.deltaTime;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDamageSender();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.Find("DamageSender").GetComponent<DamageSender>();
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    public virtual void Turning(bool isTurnRight)
    {
        this.isTurnRight = isTurnRight;
        Vector3 scale = this.model.localScale;
        if (this.isTurnRight) scale.x = 1f;
        else scale.x = -1f;
        this.model.localScale = scale;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        DamageReceive damageReceiver = other.GetComponentInChildren<DamageReceive>();
        if (!damageReceiver) return;
        
        damageReceiver.Deduct(this.damageSender.Damage());
       // FXManager.instance.Despawn(transform);
    }

    
}
