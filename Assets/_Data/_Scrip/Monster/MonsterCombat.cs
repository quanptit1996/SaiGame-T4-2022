using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCombat : Combat
{
    [Header("Monster")] 
    public MonsterCtrl monsterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if(this.monsterCtrl != null) return;
        this.monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
    }

    public override void SpawnSkill()
    {
        
    }

    protected override void Attacking()
    {
        //this.Animator().SetBool("Attacking", this.IsAttacking());
    }

    protected override Animator Animator()
    {
        return this.monsterCtrl.animator;
    }

    public override CharCtrlMove CharCtrlMove()
    {
        return this.monsterCtrl.monterMoverment;
    }
}
