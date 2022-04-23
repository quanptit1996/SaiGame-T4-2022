using System;
using UnityEngine;

public class PlayerMovement : CharCtrlMove
{


    public PlayerController playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerController();
        this.speed = 3f;
    }

    protected virtual void LoadPlayerController()
    {
        if (playerController != null)return;
        this.playerController = transform.parent.GetComponent<PlayerController>();
    }

    protected override Animator Animator()
    {
        return this.playerController.animator;
    }

    protected override Transform Model()
    {
        return this.playerController.playerModel;
    }

    protected override CharacterController CharacterController()
    {
        return this.playerController.characterController;
    }



    
}
