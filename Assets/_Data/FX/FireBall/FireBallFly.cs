using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallFly : OverideMonoBehaviour
{
    public bool isTurnRight = true;
    [SerializeField] protected float speed = 9f;
    [SerializeField] protected Transform model;
  //  [SerializeField]  private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        //this.Turning(false);
    }

    protected override void Update()
    {
        Vector3 dir = transform.right;
        if (!this.isTurnRight) dir *= -1;
        transform.position += dir * this.speed * Time.deltaTime;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
       
    }

    public virtual void Turning(bool isTurnRight)
    {
        this.isTurnRight = isTurnRight;
        Vector3 scale = this.model.localScale;
        if (this.isTurnRight) scale.x = 1f;
        else scale.x = -1f;
        this.model.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject explode = ObjectPool.instance.GetPooledExplosion();
        var animatorExplode = explode.transform.GetChild(0).GetComponent<Animator>();
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            explode.SetActive(true);
            //explode.transform.position = col.gameObject.transform.position;
            animatorExplode.SetTrigger("explode");
            gameObject.SetActive(false);
        }
    }

    private void Deactive()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
