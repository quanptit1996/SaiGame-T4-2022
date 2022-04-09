using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] protected float moveHorizontal;
    public bool isJump;
    public float attacking; 
    private void Update()
    {
        this.PlayerInput();
    }

    protected virtual void PlayerInput()
    {
        //Jump
        this.isJump = Input.GetButtonDown("Jump")
                      || Input.GetKeyDown(KeyCode.W)
                      || Input.GetKeyDown(KeyCode.UpArrow);
        PlayerController.instance.playerMovement.isJump = this.isJump;
        
        //walk
        this.moveHorizontal = Input.GetAxis("Horizontal");
        PlayerController.instance.playerMovement.moveHorizontal = this.moveHorizontal;

        //Attack
        this.attacking = Input.GetAxis("Fire1");
        PlayerController.instance.playerCombat.attacking = this.attacking;

    }
}
