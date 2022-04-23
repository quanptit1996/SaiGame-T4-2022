using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : OverideMonoBehaviour
{
    public MonsterMovement monsterMovement;
    public MonsterTarget monsterTarget;
    public CharacterController characterController;
    public DamageReceive damageReceiver;
    public Transform model;
    public Animator animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterMovement();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadMonsterMovement()
    {
        if (this.monsterMovement != null) return;
        this.model = transform.Find("Model");
        this.animator = this.model.GetComponentInChildren<Animator>();
        this.monsterMovement = transform.Find("MonsterMovement").GetComponent<MonsterMovement>();
        this.monsterTarget = transform.Find("MonsterTarget").GetComponent<MonsterTarget>();
        this.damageReceiver = transform.Find("DamageReceive").GetComponent<DamageReceive>();
        this.characterController = GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadMonsterMovement", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.Find("DamageReceive").GetComponent<DamageReceive>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
