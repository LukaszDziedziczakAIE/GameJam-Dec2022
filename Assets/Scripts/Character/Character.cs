using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public GameController Game { get; private set; }
    [field: SerializeField] public Transform HeadPos { get; private set; }
    [field: SerializeField] public CharacterController Controller;
    [field: SerializeField] public Animator Animator;
    [field: SerializeField] public CharacterAudio Audio;
    [field: SerializeField] public float Speed = 5;

    public int configRef;
    [SerializeField] protected float drag = 0.3f;
    protected Vector3 impact;
    protected Vector3 dampingVelocity;
    float verticalVelocity;
    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    protected virtual void Awake()
    {
        if (Game == null) Game = FindObjectOfType<GameController>();
        if (Controller == null) Controller = GetComponent<CharacterController>();
        if (Animator == null) Animator = GetComponentInChildren<Animator>();
        if (Audio == null) Audio = GetComponentInChildren<CharacterAudio>();
    }

    protected virtual void Start()
    {

    }

    private void Update()
    {
        ApplyPhysics();
        ResetToCenter();
    }

    private void ApplyPhysics()
    {
        //gravity
        if (verticalVelocity < 0f && Controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);

        if (impact.sqrMagnitude < 0.2f * 0.2f)
        {
            impact = Vector3.zero;
        }
    }

    private void ResetToCenter()
    {
        if (transform.position.z != Game.MapZCenter)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Game.MapZCenter);
        }
    }

    protected void Move(Vector3 motion)
    {
        Controller.Move((motion + Movement) * Time.deltaTime);
    }

    protected void Move()
    {
        Controller.Move((Movement) * Time.deltaTime);
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
