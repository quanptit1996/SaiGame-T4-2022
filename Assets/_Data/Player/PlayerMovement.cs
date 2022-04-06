using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 movement = new Vector3(0, 0, 0);
    public Vector3 moveDirection = new Vector3(0, 0, 0);
    public float lastDirection = 0f;
    public bool isTurnRight = true;
    public bool isMoving = false;
    public bool groundedPlayer = false;
    public float speed = 2f;
    public float gravityValue = -9.81f;
    public float jumpHeight = 1.0f;

    protected virtual void Update()
    {
        this.Moving();
        this.Turning();
    }

    protected virtual void Moving()
    {

        this.groundedPlayer = this.IsGrounded();
        if (groundedPlayer && this.movement.y < 0)
        {
            this.movement.y = 0f;
        }

        this.moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        PlayerController.instance.characterController.Move(this.moveDirection * Time.deltaTime * this.speed);

        if (this.moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = this.moveDirection;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            this.movement.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        this.movement.y += gravityValue * Time.deltaTime;
        PlayerController.instance.characterController.Move(this.movement * Time.deltaTime);


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
        if (this.moveDirection.x != 0) this.isMoving = true;

        return this.isMoving;
    }

    protected virtual void Turning()
    {
        this.isTurnRight = true;
        if (this.moveDirection.x != 0) this.lastDirection = this.moveDirection.x;
        if (this.lastDirection < 0) this.isTurnRight = false;

        Vector3 scale = PlayerController.instance.playerModel.localScale;
        if (this.isTurnRight) scale.x = 1f;
        else scale.x = -1f;

        PlayerController.instance.playerModel.localScale = scale;
    }
}
