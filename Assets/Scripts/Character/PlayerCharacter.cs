using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [Header("Player Character")]
    [SerializeField] Vector3 pos_levelStart;
    [SerializeField] Vector3 pos_characterCreator;

    InputReader InputReader;
    [SerializeField] float RotationDamping = 0.1f;

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

    private void Update()
    {
        ProcessMovement();
    }

    public void SetPos_LevelStart()
    {
        transform.position = pos_levelStart;
    }

    public void SetPos_CharacterCreator()
    {
        transform.position = pos_characterCreator;
    }

    private void ProcessMovement()
    {
        if (Game.TestingMode && InputReader.Movement.magnitude > 0)
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

        return forward * Game.InputReader.Movement.y + right * Game.InputReader.Movement.x;
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
}
