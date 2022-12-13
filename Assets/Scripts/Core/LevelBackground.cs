using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBackground : MonoBehaviour
{
    GameController game;

    private void Awake()
    {
        game = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        if (game.HUD.LevelDesign.gameObject.activeSelf || game.TestingMode)
        {
            transform.position = new Vector3(transform.position.x ,transform.position.y, game.Camera.Camera.transform.position.z);
        }
    }
}
