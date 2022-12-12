using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public Placeable Placeable { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Placeable = GetComponent<Placeable>();
    }

    protected override void Update()
    {
        base.Update();
        PlacingLogic();
    }

    public void PlacingLogic()
    {

    }
}
