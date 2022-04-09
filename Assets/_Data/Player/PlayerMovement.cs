using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    public bool groundedPlayer = false;
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

    protected virtual void Update()
    {
        this.groundedPlayer = this.IsGrounded(); // check có đang đứng ở mặt đất hay k..
        this.Jumping();
        this.Falling();
        this.Moving();
        this.Turning();
        this.Animation();

        PlayerController.instance.characterController.Move(this.movement * Time.deltaTime);
    }

    protected virtual void Jumping()
    {
        if (!this.groundedPlayer) return;
        if (this.isJump) this.movement.y = this.jumpHeight;

    }

    protected virtual void Falling()
    {
        this.movement.y -= this.fallingSpeed * Time.deltaTime;
    }
    protected virtual void Moving()
    {
        if(!this.groundedPlayer) return;
        // if (PlayerController.instance.)
        // {
        //     
        // }

        this.movement.x = this.speed * this.moveHorizontal;
    }

    protected virtual void Animation()
    {
        if (this.IsMoving()) this.AniMoving();
        else this.AniIdle();
    }

    protected virtual void AniMoving()
    {
        PlayerController.instance.animator.SetInteger("Stage", 1);
    }

    protected virtual void AniIdle()
    {
        PlayerController.instance.animator.SetInteger("Stage", 0);
    }

    protected virtual bool IsGrounded()
    {
        return PlayerController.instance.characterController.isGrounded;
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
        this.isTurnRight = true;
        if (this.movement.x != 0) this.lastDirection = this.movement.x;
        if (this.lastDirection < 0) this.isTurnRight = false;

        Vector3 scale = PlayerController.instance.playerModel.localScale;
        
        if (this.isTurnRight) scale.x = 1f;
        else scale.x = -1f;

        PlayerController.instance.playerModel.localScale = scale;
    }
}
