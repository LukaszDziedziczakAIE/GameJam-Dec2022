using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    const string ATTACK = "Attack";
    const string CHASE = "ChasePlayer";
    const string CLIMB = "ClimbLadder";
    const string HEALTH = "ExtraHealth";
    const string PATROL = "Patrol";


    public Placeable Placeable { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Placeable = GetComponent<Placeable>();
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
            CB_ExtraHealthBehaviour();
            CB_PatrolBehaviour();
        }
    }


    private void CB_AttackBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(ATTACK)) return;

        print("ATTACK Behaviour Online");
    }

    private void CB_ChaseBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(CHASE)) return;

        print("CHASE Behaviour Online");
    }

    private void CB_ClimbBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(CLIMB)) return;

        print("CLIMB Behaviour Online");
    }

    private void CB_ExtraHealthBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(HEALTH)) return;

        print("HEALTH Behaviour Online");
    }

    private void CB_PatrolBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(PATROL)) return;

        print("PATROL Behaviour Online");
    }
}
