using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : OverideMonoBehaviour
{
     public Transform strikePointRight;
    public Transform strikePointLeft;
    public float attacking = 0f;
    public bool canAttack = false;
    public bool attackLaunched = false;
    public bool skillReleased = false;
    public float attackTimer = 0f;
    public float attackSpeed = 2f;
    public float skillSpawnDelay = 0.2f;
    public float aniAttackTime = 0.5f;

    protected virtual void Update()
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
        Debug.Log(transform.name + ": LoadStrikePoint", gameObject);
    }

    protected virtual void AttackDelay() // set Time chờ cho lần skill tiếp theo
    {
        this.attackTimer += Time.deltaTime;
        if (this.attackTimer < this.attackSpeed) return;

        this.canAttack = true;
    }

    protected virtual void Attacking()//Hàm attack
    {
        PlayerController.instance.animator.SetBool("isAttacking", this.IsAttacking());
        if (this.IsAttacking() && !this.attackLaunched)
        {
            Debug.Log("IsAttacking");
            this.attackLaunched = true;
            Invoke("SpawnSkill", this.skillSpawnDelay);
            Invoke("AttackFinish", this.aniAttackTime);
        }
    }

    protected virtual void SpawnSkill()
    {
        if (this.skillReleased) return;
        this.skillReleased = true;

        Debug.Log("SpawnSkill");

        GameObject fx = ObjectPool.instance.GetPooledObject();
        if (fx != null)
        {
            fx.transform.position = this.GetStrikePoint();
            fx.SetActive(true);
            FireBallFly fireballFly = fx.GetComponent<FireBallFly>();
            fireballFly.Turning(PlayerController.instance.playerMovement.isTurnRight);
        }
       
       
        //  fx.gameObject.SetActive(true);
    }

    protected virtual void AttackFinish()
    {
        this.canAttack = false;
        this.attackTimer = 0;
        this.skillReleased = false;
        this.attackLaunched = false;
    }

    public virtual bool IsAttacking()
    {
        return this.attacking != 0 && this.canAttack;
    }

    protected virtual Vector3 GetStrikePoint() // lấy vị trí spwan
    {
        if (PlayerController.instance.playerMovement.isTurnRight) return this.strikePointRight.position;
        return this.strikePointLeft.position;
    }
}
