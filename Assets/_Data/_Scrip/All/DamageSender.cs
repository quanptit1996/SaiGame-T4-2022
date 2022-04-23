using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : OverideMonoBehaviour
{
    [Header("DamageSender")]
    [SerializeField] protected int damage = 1;

    public virtual int Damage()
    {
        return this.damage;
    }
}
