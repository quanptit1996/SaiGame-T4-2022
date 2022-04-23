using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterMoverment : CharCtrlMove
{
    public MonsterCtrl monsterCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMonsterCtrl();
        lookAtMouse = false;
    }

    protected virtual void LoadMonsterCtrl()
    {
        if(monsterCtrl != null) return;
        monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
    }

    protected override Animator Animator()
    {
        return monsterCtrl.animator;
    }

    protected override Transform Model()
    {
        return this.monsterCtrl.model;
    }

    protected override CharacterController CharacterController()
    {
        return this.monsterCtrl.characterController;
    }

    protected override void TurnByMovement()
    {
        this.isTurnRight = true;
        Transform target = this.monsterCtrl.monsterTarget.Target();
        if(!this.monsterCtrl.monsterTarget.IsTargetAvail()) return;

        this.mouseToChar = target.position - transform.parent.position;
        if (this.mouseToChar.x != 0) this.lastDirection = this.mouseToChar.x;

        if (this.lastDirection < 0)
        {
            this.moveHorizontal = -1;
            this.isTurnRight = false;
        }
        else this.moveHorizontal = 1;
    }
}
