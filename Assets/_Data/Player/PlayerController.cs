using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : OverideMonoBehaviour
{
    public static PlayerController instance;

    public Transform playerModel;
    public CharacterController characterController;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Animator animator;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerController.instance != null) Debug.LogError("Only 1 PlayerController allow");
        PlayerController.instance = this;
    }

   

    protected override void LoadComponents()
    {
        this.LoadChar();
        this.LoadCharCtrl();
    }

    protected virtual void LoadChar()
    {
        if (this.playerModel != null) return;
        this.playerModel = transform.Find("Model");
        this.animator = this.playerModel.GetComponent<Animator>();
        
        this.characterController = GetComponent<CharacterController>();
        this. playerMovement = transform.Find("PlayerMovement").GetComponent<PlayerMovement>();
        this.playerCombat = transform.Find("PlayerCombat").GetComponent<PlayerCombat>();
        Debug.Log(transform.name + ": LoadChar", gameObject);
        
    }

    protected virtual void LoadCharCtrl()
    {
        if (this.characterController != null) return;
        this.characterController = GetComponent<CharacterController>();
        this.characterController.center = new Vector3(0, -0.37f, 0);
        this.characterController.height = 1.5f;
        Debug.Log(transform.name + ": LoadCharCtrl", gameObject);
        
    }
}
