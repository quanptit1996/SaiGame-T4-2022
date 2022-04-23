using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceive : MonoBehaviour
{
    [Header("DamageReceiver")]
    public int hp = 1;

    public virtual int Deduct(int amount)
    {
        this.hp -= amount;
        this.DieCheck();
        return this.hp;
    }

    protected virtual void DieCheck()
    {
        if (!this.IsDead()) return;
        Destroy(transform.parent.gameObject);//TODO: return to pool object
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
}
