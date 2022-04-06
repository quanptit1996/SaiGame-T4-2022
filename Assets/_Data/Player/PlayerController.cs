using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Transform playerModel;
    public CharacterController characterController;
    public Animator animator;

    protected virtual void Awake()
    {
        if (PlayerController.instance != null) Debug.LogError("Only 1 PlayerController allow");
        PlayerController.instance = this;
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        this.LoadChar();
    }

    protected virtual void LoadChar()
    {
        if (this.playerModel != null) return;
        this.playerModel = transform.Find("Model");
        this.animator = this.playerModel.GetComponent<Animator>();
        this.characterController = GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadChar", gameObject);
    }
}
