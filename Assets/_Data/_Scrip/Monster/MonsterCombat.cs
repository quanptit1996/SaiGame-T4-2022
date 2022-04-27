using UnityEngine;

public class MonsterCombat : Combat
{
    [Header("TargetPlayer")]
   
    [Header("Monster")]
    public MonsterCtrl monsterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (this.monsterCtrl != null) return;
        this.monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
        Debug.Log(transform.name + ": LoadMonsterCtrl", gameObject);
    }

    public override void SpawnSkill()
    {
        
    }

    protected override void Attacking()
    {
        Transform target = PlayerController.instance.transform;

        float distance = Vector2.Distance(gameObject.transform.position, target.position);
        if (distance < 3 )
        {
            Debug.Log("distance"+distance);
            // this.Animator().SetBool("isAttacking", this.IsAttacking());
            this.Animator().Play("attack");
        }
    }

    protected override Animator Animator()
    {
        return this.monsterCtrl.animator;
    }

    public override CharCtrlMove CharCtrlMove()
    {
        return this.monsterCtrl.monsterMovement;
    }
}
