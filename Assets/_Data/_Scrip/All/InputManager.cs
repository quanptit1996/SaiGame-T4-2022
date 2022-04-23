using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Keyboard")]
    public static InputManager instance;
    public float moveHorizontal;
    public bool isJump = false;
    public float attacking = 0;

    
    [Header("Mouse")]
    public Vector3 mousePos;
    public Vector3 mouseInWorld;
    
    protected virtual void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow");
        InputManager.instance = this;
    }
    private void Update()
    {
        this.PlayerInput();
        this.MouseInput();
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
    
    protected virtual void MouseInput()
    {
        this.mousePos = Input.mousePosition;

        Vector3 vec3 = new Vector3(mousePos.x, mousePos.y, 0);
        this.mouseInWorld = Camera.main.ScreenToWorldPoint(vec3);
        PlayerController.instance.playerMovement.mouseInWorld = this.mouseInWorld;
    }
}
