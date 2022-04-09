using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attacking = 0f;
    public bool canAttack = false;
    public float attackTimer = 0f;
    public float attackSpeed = 2f;

    protected void Update()
    {
        this.AttackDelay();
        this.Animation();
    }

    protected virtual void AttackDelay()
    {
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.attackSpeed) return;
        this.canAttack = true;
    }
    
    protected virtual void Animation()
    {
       PlayerController.instance.animator.SetBool("isAttacking",IsAttacking());
       if (this.IsAttacking()) Invoke("Attacked", 0.5f);
    }

    public virtual bool IsAttacking()
    {
        return this.attacking != 0 && this.canAttack;
    }
    
    protected virtual void Attacked()
    {
        this.canAttack = false;
        this.attackTimer = 0;
    }
    
}
