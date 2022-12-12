using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField] public UI_HUD HUD { get; private set; }
    [field: SerializeField] public CameraController Camera { get; private set; }
    [field: SerializeField] public PlayerCharacter PlayerCharacter { get; private set; }
    [field: SerializeField] public InputReader InputReader { get; private set; }

    public List<Character> enemies = new List<Character>();
}