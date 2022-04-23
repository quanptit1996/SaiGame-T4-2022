using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharCtrlMove : OverideMonoBehaviour
{
    [Header("Move")]
    public bool grounded = false;
    public bool isMoving = false;
    public Vector3 movement = new Vector3(0, 0, 0);

    [Header("Walking")] 
    public float moveHorizontal = 0f;
    public float lastDirection = 0f;
    public float speed = 3f;
    public bool isTurnRight = true;

    [Header("Jumping")]
    public bool isJump = false;
    public float jumpHeight = 5.0f;
    public float fallingSpeed = 7f;

    [Header("Mouse")]
    public bool lookAtMouse = true;

    public Vector3 mouseInWorld;
    public Vector3 mouseToChar;


    protected abstract Animator Animator();
    protected abstract Transform Model();
    protected abstract CharacterController CharacterController();
    
    protected virtual void Update()
    {
        this.grounded = this.IsGrounded(); // check có đang đứng ở mặt đất hay k..
        this.Jumping();
        this.Falling();
        this.Moving();
        this.Turning();
        this.Animation(); 

        this.CharacterController().Move(this.movement * Time.deltaTime);
    }
    
    
    protected virtual void Jumping()
    {
        if (!this.grounded) return;
        if (this.isJump) this.movement.y = this.jumpHeight;

    }

    protected virtual void Falling()
    {
        this.movement.y -= this.fallingSpeed * Time.deltaTime;
    }
    protected virtual void Moving()
    {
        if(!this.grounded) return;

        this.movement.x = this.speed * this.moveHorizontal;
    }

    protected virtual void Animation()
    {
        if (this.IsMoving()) this.AniMoving();
        else this.AniIdle();
    }

    protected virtual void AniMoving()
    {
        Animator().SetInteger("Stage", 1);
    }

    protected virtual void AniIdle()
    {
        Animator().SetInteger("Stage", 0);
    }

    protected virtual bool IsGrounded()
    {
        return this.CharacterController().isGrounded;
    }

    public virtual bool IsMoving()
    {
        this.isMoving = false;
        if (this.isJump) this.isMoving = true;
        if (this.moveHorizontal != 0) this.isMoving = true;
        return this.isMoving;
    }
    
    protected virtual void Turning()
    {
        if (this.lookAtMouse) this.LookAtMouse();
        else this.TurnByMovement();

        Vector3 scale = Model().localScale;
        
        if (this.isTurnRight) scale.x = 1f;
        else scale.x = -1f;

        Model().localScale = scale;
    }
    
    protected virtual void TurnByMovement()
    {
        this.isTurnRight = true;
        if (this.moveHorizontal != 0) this.lastDirection = this.moveHorizontal;
        if (this.lastDirection < 0) this.isTurnRight = false;
    }
    
    protected virtual void LookAtMouse()
    {
        this.mouseToChar = this.mouseInWorld - this.Model().position;

        this.isTurnRight = true;
        if (this.mouseToChar.x != 0) this.lastDirection = this.mouseToChar.x;
        if (this.lastDirection < 0) this.isTurnRight = false;
    }

}
