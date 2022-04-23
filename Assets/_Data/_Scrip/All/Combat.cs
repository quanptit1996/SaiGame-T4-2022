using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : OverideMonoBehaviour
{
    [Header("Combat")]
    public Transform strikePointRight;
    public Transform strikePointLeft;
    public float attacking = 0f;
    public bool canAttack = false;
    public bool skillReleased = false;
    public float attackTimer = 0f;
    public float attackSpeed = 2f;
    public float skillSpawnDelay = 0.2f;
    public float aniAttackTime = 0.5f;

    protected abstract Animator Animator();
    public abstract void SpawnSkill();
    public abstract CharCtrlMove CharCtrlMove();

    protected override void Update()
    {
        this.AttackDelay();
        this.Attacking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStrikePoint();
    }

    protected virtual void LoadStrikePoint()
    {
        if (this.strikePointRight != null) return;
        this.strikePointRight = transform.Find("StrikePointRight");
        this.strikePointLeft = transform.Find("StrikePointLeft");
    }

    protected virtual void AttackDelay()
    {
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.attackSpeed) return;

        this.canAttack = true;
    }

    protected virtual void Attacking()
    {
        this.Animator().SetBool("Attacking", this.IsAttacking());
    }

    /// <summary>
    /// Call from Invoke
    /// </summary>
    public virtual void AttackFinish()
    {
        this.canAttack = false;
        this.attackTimer = 0;
        this.skillReleased = false;
    }

    public virtual bool IsAttacking()
    {
        return this.attacking != 0 && this.canAttack;
    }

    protected virtual Vector3 GetStrikePoint()
    {
        if (this.CharCtrlMove().isTurnRight) return this.strikePointRight.position;
        return this.strikePointLeft.position;
    }
    
}
