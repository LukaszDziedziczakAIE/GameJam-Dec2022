using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    InputReader InputReader;
    [SerializeField] float RotationDamping = 0.1f;

    Vector3 lastPos = Vector3.zero;

    protected override void Awake()
    {
        base.Awake();
        InputReader = Game.InputReader;
    }

    protected override void Start()
    {
        base.Start();
        configRef = 0;
    }

    protected override void Update()
    {
        base.Update();
        ProcessMovement();
    }

    public void SetPos_LevelStart()
    {
        transform.position = Game.LevelStartPos;
        if (lastPos != Vector3.zero) transform.eulerAngles = lastPos;
        else transform.eulerAngles = Game.LevelStartRot;
        Controller.enabled = true;
        inLevel = true;
    }

    public void SetPos_CharacterCreator()
    {
        Controller.enabled = false;
        lastPos = transform.position;
        transform.position = Game.CharacterDesignPos;
        transform.eulerAngles = Game.CharacterDesignRot;
        inLevel = false;
    }

    private void ProcessMovement()
    {
        if (Game.TestingMode && InputReader.Movement.x != 0)
        {
            Vector3 Movement = CalculateMovement();
            FaceMovementDirection(Movement);
            Move(Movement * Speed);
            Animator.SetFloat("MoveSpeed", 1);
        }
        else
        {
            Move();
            Animator.SetFloat("MoveSpeed", 0);
        }
    }

    protected Vector3 CalculateMovement()
    {
        Vector3 forward = Game.Camera.transform.forward;
        Vector3 right = Game.Camera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        float yOverride = 0;

        return forward * /*Game.InputReader.Movement.y*/ yOverride + right * Game.InputReader.Movement.x;
    }

    protected void FaceMovementDirection(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(movement),
            Time.deltaTime * RotationDamping);
        }
    }

    public void MapControls(bool maping = true)
    {
        if (maping)
        {
            InputReader.JumpEvent += OnJump;
            InputReader.InteractEvent += OnInteract;
            InputReader.AttackEvent += OnAttack;
        }
        else
        {
            InputReader.JumpEvent -= OnJump;
            InputReader.InteractEvent -= OnInteract;
            InputReader.AttackEvent -= OnAttack;
        }
    }

    private void OnJump()
    {
        Jump();
    }

    private void OnInteract()
    {
        Interact();
    }

    private void OnAttack()
    {
        Attack();
    }
}
