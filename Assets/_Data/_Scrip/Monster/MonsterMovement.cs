using UnityEngine;

public class MonsterMovement : CharCtrlMove
{
    public MonsterCtrl monsterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterCtrl();
        this.lookAtMouse = false;
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (this.monsterCtrl != null) return;
        this.monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
        Debug.Log(transform.name + ": LoadMonsterCtrl", gameObject);
    }

    protected override Animator Animator()
    {
        return this.monsterCtrl.animator;
    }

    protected override CharacterController CharacterController()
    {
        return this.monsterCtrl.characterController;
    }

    protected override Transform Model()
    {
        return this.monsterCtrl.model;
    }

    protected override void Moving()
    {
        base.Moving();
    }

    protected override void TurnByMovement()
    {
        this.isTurnRight = true;
        Transform target = this.monsterCtrl.monsterTarget.Target();
        if (!this.monsterCtrl.monsterTarget.IsTargetAvail()) return;

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
