using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class OverrideFireBall : FireBallFly
{
    public static OverrideFireBall instance;
    private PlayerCombat playerCombat;
    public bool enemyTrigger;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void OnTriggerEnter(Collider col)
    {
        var fx  =ObjectPool.instance.GetPooledExplosion();
        fx.transform.position = col.transform.position + new Vector3(0,0.8f,0);
        fx.SetActive(true);
        gameObject.SetActive(false);
        enemyTrigger = true;
    }

  
}
