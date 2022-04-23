using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTarget : OverideMonoBehaviour
{
    [SerializeField] protected Transform target;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.TargetFinding();
    }

    protected virtual void TargetFinding()
    {
        if (this.IsTargetAvail()) return;

        this.target = PlayerController.instance.transform;
    }

    public virtual bool IsTargetAvail()
    {
        if (this.target == null) return false;
        if (!this.target.gameObject.activeSelf) return false;
        return true;
    }

    public virtual Transform Target()
    {
        return this.target;
    }
}
