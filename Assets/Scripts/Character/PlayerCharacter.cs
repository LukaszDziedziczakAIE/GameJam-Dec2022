using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [Header("Player Character")]
    [SerializeField] Vector3 pos_levelStart;
    [SerializeField] Vector3 pos_characterCreator;

    InputReader InputReader;

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
            print("testing mode processing movement");
        }
    }


}
