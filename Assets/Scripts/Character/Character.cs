using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field: SerializeField] public GameController Game { get; private set; }
    [field: SerializeField] public CharacterController Controller;

    public CharacterConfig Config { get; private set; }
    protected Vector3 impact;
    float verticalVelocity;
    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    protected virtual void Awake()
    {
        if (Game == null) Game = FindObjectOfType<GameController>();
        if (Controller == null) Controller = GetComponent<CharacterController>();
    }

    public void SetNewConfig(CharacterConfig newConfig) { Config = newConfig; }

    protected void Move(Vector3 motion, float deltaTime)
    {
        Controller.Move((motion + Movement) * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Controller.Move((Movement) * deltaTime);
    }
}
