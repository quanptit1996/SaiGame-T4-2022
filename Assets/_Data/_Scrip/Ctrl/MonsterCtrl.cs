using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : OverideMonoBehaviour
{
   public MonterMoverment monterMoverment;
   public MonsterTarget monsterTarget;
   public CharacterController characterController;
   public DamageReceive damageReceive;
   public Transform model;
   public Animator animator;

   protected override void LoadComponents()
   {
      base.LoadComponents();
      LoadMonsterMoverment();
   }

   protected virtual void LoadMonsterMoverment()
   {
      if(monterMoverment != null) return;
      model = transform.Find("Model");
      animator = model.transform.GetComponentInChildren<Animator>();
      monterMoverment = transform.Find("MonsterMovement").GetComponent<MonterMoverment>();
      monsterTarget = transform.Find("MonsterTarget").GetComponent<MonsterTarget>();
      damageReceive = transform.Find("DamageReceive").GetComponent<DamageReceive>();
      characterController = GetComponent<CharacterController>();

   }
   
   
   
}
