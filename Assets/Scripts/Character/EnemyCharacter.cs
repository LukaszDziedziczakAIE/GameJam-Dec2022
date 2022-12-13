using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
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

        }
    }

    private void CB_PatrolBehaviour()
    {
        if (!Game.CharacterConfig[configRef].HasCodeBlock(PATROL)) return;

        print("Patrol Behaviour Online");
    }
}
