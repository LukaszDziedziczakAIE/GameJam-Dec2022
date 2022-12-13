using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera { get; private set; }

    [SerializeField] Vector3 startingPos;
    [SerializeField] Vector3 programmingPos;
    [SerializeField] Vector3 programmingAngles;
    [SerializeField] Vector3 levelScreenAngles;
    [SerializeField] Vector3 characterScreenAngles;
    [SerializeField] float speed = 1f;
    [SerializeField] float minZ = -26;
    [SerializeField] float maxZ = 20;

    GameController game;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
        game = FindObjectOfType<GameController>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        CameraMovement();
        FollowPlayer();
    }

    public void FaceLevel()
    {
        transform.position = startingPos;
        transform.eulerAngles = levelScreenAngles;
        Camera.orthographic = true;
    }

    public void FaceCharacterCreator()
    {
        transform.position = startingPos;
        transform.eulerAngles = characterScreenAngles;
        Camera.orthographic = false;
    }

    public void FaceProgramming()
    {
        transform.position = programmingPos;
        transform.eulerAngles = programmingAngles;
    }

    public void SetPerspectiveProjection()
    {
        Camera.orthographic = false;
    }

    public void SetOtherpedicProjection()
    {
        Camera.orthographic = true;
    }

    private void CameraMovement()
    {
        if (game.HUD.LevelDesign.gameObject.activeSelf && game.InputReader.CameraMovement.x != 0)
        {
            float movement = game.InputReader.CameraMovement.x * Time.deltaTime * speed * -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movement);

            if (transform.position.z > maxZ) transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);

            if (transform.position.z < minZ) transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
    }

    private void FollowPlayer()
    {
        if (game.TestingMode)
        {
            transform.position = new Vector3(
                transform.position.x, 
                transform.position.y, 
                game.PlayerCharacter.transform.position.z);
        }
    }

}
