using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public GameController Game { get; private set; }
    [field: SerializeField] public CharacterController Controller;
    [field: SerializeField] public Animator Animator;

    public int configRef;
    protected Vector3 impact;
    float verticalVelocity;
    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    protected virtual void Awake()
    {
        if (Game == null) Game = FindObjectOfType<GameController>();
        if (Controller == null) Controller = GetComponent<CharacterController>();
        if (Animator == null) Animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {

    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        Controller.Move((motion + Movement) * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Controller.Move((Movement) * deltaTime);
    }

    public CharacterConfig Config
    {
        get
        {
            return Game.CharacterConfig[configRef];
        }
    }

    public void UpdateCharacter()
    {

    }
}
