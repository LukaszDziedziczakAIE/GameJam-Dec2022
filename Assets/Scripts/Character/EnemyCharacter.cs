using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [Header("Attack")]
    const string ATTACK = "Attack";
    [SerializeField] float attackRange;

    [Header("Chase")]
    const string CHASE = "ChasePlayer";
    [SerializeField] float minChaseRange;
    [SerializeField] float maxChaseRange;

    const string CLIMB = "ClimbLadder";
    
    [Header("Health")]
    const string HEALTH = "ExtraHealth";
    [SerializeField] int extraHealth;

    [Header("Patrol")]
    const string PATROL = "Patrol";
    [SerializeField] float patrolRange;
    float Patrol_InitialPos = 0;
    float Patrol_EndPos = 0;
    float Patrol_TargetPos = 0;

    Vector3 EnemyMovement = Vector3.zero;
    [SerializeField] float RotationDamping = 24f;

    public Placeable Placeable { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Placeable = GetComponent<Placeable>();
    }

    protected override void Start()
    {
        CB_ExtraHealthBehaviour();
    }

    protected override void Update()
    {
        if (Placeable.Placing) return;
        base.Update();

        PlayMode();
    }

    private void PlayMode()
    {
        if (Game.TestingMode)
        {
            CB_PatrolBehaviour();
            CB_ChaseBehaviour();
            CB_ClimbBehaviour();
            
            CB_PatrolBehaviour();
        }
    }


    private void CB_AttackBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(ATTACK)) return;

        //print("ATTACK Behaviour Online");
    }

    private void CB_ChaseBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(CHASE)) return;

        if (distanceToPlayer < maxChaseRange && distanceToPlayer > minChaseRange)
        {
            if (Game.PlayerCharacter.transform.position.z < transform.position.z) MoveLeft();
            else MoveRight();
        }
        else Stop();
    }

    private void CB_ClimbBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(CLIMB)) return;

        //print("CLIMB Behaviour Online");
    }

    private void CB_ExtraHealthBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(HEALTH)) return;

        Health += extraHealth;
    }

    private void CB_PatrolBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(PATROL)) return;

        if(Patrol_InitialPos == 0) Patrol_InitialPos = transform.position.z;
        if (Patrol_EndPos == 0) Patrol_EndPos = Patrol_InitialPos + patrolRange;



    }


    private void ProcessMovement()
    {
        if (Game.TestingMode && EnemyMovement != Vector3.zero)
        {
            FaceMovementDirection(EnemyMovement);
            Move(Movement * Speed);
            Animator.SetFloat("MoveSpeed", 1);
        }
        else
        {
            Move();
            Animator.SetFloat("MoveSpeed", 0);
        }
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

    private float distanceToPlayer
    {
        get
        {
            return Vector3.Distance(transform.position, Game.PlayerCharacter.transform.position);
        }
    }

    private float distanceToTarget
    {
        get
        {
            if (Patrol_TargetPos != 0)
            {
                return Vector3.Distance(Patrol_TargetPos, transform.position);
            }
        }
    }

    private void Stop()
    {
        EnemyMovement = Vector3.zero;
    }

    private void MoveLeft()
    {
        EnemyMovement = new Vector3(-1, 0, 0);
    }

    private void MoveRight()
    {
        EnemyMovement = new Vector3(1, 0, 0);
    }
}
